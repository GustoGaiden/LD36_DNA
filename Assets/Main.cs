using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// COnfigs
	public HumanGenomeConfig genomeConfig;
	public HumanSpriteAtlasConfig spriteAtlasConfig;

	//Statics
	public static Dictionary<string, Sprite> SpriteAtlas;
	public static EventManager eventManager;
	public static Main instance { get; private set; }

	public Dictionary<string, Gene> TheHumanGenome;
	public List<PersonData> Humans;
	public GameObject PersonPrefab;

	public DNADisplayGrid TopGrid;
	public DNADisplayGrid BottomGrid;

	public int numPeople = 100;
	// COntainers
	public Transform PeopleContainer;

	private Coroutine _matchRoutine;

	private bool _usePrimary;
	// Use this for initialization
	void Start ()
	{
		initialize();
	}
	

	void initialize()
	{
		Debug.Log("Time Begin: " + Time.realtimeSinceStartup);
		instance = this;
		eventManager = GetComponent<EventManager>();
		TheHumanGenome = new Dictionary<string, Gene>();
		_usePrimary = true;

		SpriteAtlas = new Dictionary<string, Sprite>();
		foreach (SpriteIdentifier identifier in spriteAtlasConfig.SpriteAtlas)
		{
			SpriteAtlas.Add(identifier.ID, identifier.sprite);
		}

		foreach (GeneConfig protoGene in genomeConfig.HumanGenome)
		{
			foreach (GeneStatusConfig geneType in protoGene.Types)
			{
				Gene newGene = new Gene(protoGene.Attribute, geneType.Status, protoGene.VisualModifierSlot, geneType.ModifierID);
				TheHumanGenome.Add(newGene.IndexName, newGene);
			}
		}

		Humans = new List<PersonData>();
		for (int i = 0; i < numPeople; i++)
		{
			Humans.Add(PersonData.MakePersonDataFromConfig());
		}

		foreach (PersonData person in Humans)
		{
			GameObject NewHumanVis = GameObject.Instantiate(PersonPrefab);
			NewHumanVis.transform.SetParent(PeopleContainer);
			PersonVisual VisComp = NewHumanVis.GetComponent<PersonVisual>();
			VisComp.initialize(person);

		}
		
		eventManager.AddListener<HumanSelectPrimaryEvent>(selectPrimary);
		eventManager.AddListener<DNADisplayCompleteEvent>(CheckMatchesInGrids);

		Debug.Log("Time End: " + Time.realtimeSinceStartup);
	}
	// Update is called once per frame
	void Update () {
	
	}

	private void CheckMatchesInGrids(DNADisplayCompleteEvent e)
	{
		if(TopGrid.LayoutInProgress || BottomGrid.LayoutInProgress)
		{
			// Wait until both are done
			return;
		}

		foreach (DNAChunkButtonDisplay topBtn in TopGrid.AllChunks) 
		{
			foreach (DNAChunkButtonDisplay botBtn in BottomGrid.AllChunks)
			{
				if (topBtn.chunk.isJunk || botBtn.chunk.isJunk)
				{
					// Don't even bother with Junk
					continue;
				}
				
				if (topBtn.chunk.DNASequence == botBtn.chunk.DNASequence)
				{
					topBtn.setMatch(true);
					botBtn.setMatch(true);
				}
			}
		}
	}

	private void SelectChunkInBothGrids(DNADisplayCompleteEvent e)
	{
		if (TopGrid.LayoutInProgress || BottomGrid.LayoutInProgress)
		{
			// Wait until both are done
			return;
		}

		foreach (DNAChunkButtonDisplay topBtn in TopGrid.AllChunks)
		{
			foreach (DNAChunkButtonDisplay botBtn in BottomGrid.AllChunks)
			{
				if (topBtn.chunk.isJunk || botBtn.chunk.isJunk)
				{
					// Don't even bother with Junk
					continue;
				}

				if (topBtn.chunk.DNASequence == botBtn.chunk.DNASequence)
				{
					topBtn.setMatch(true);
					botBtn.setMatch(true);
				}
			}
		}
	}

	private void selectPrimary(HumanSelectPrimaryEvent e)
	{
		TopGrid.resetHighlights();
		BottomGrid.resetHighlights();
		if (_usePrimary)
		{
			TopGrid.setPersonToDisplay(e.visual);
		}
		else
		{
			BottomGrid.setPersonToDisplay(e.visual);
		}

		_usePrimary = !_usePrimary;
	}
	
	
	/*
	 
	Select group of people
	Compare their DNA

	DNA dictates Attributes
	Attributes iunclude hair color, eye color, height, muscle mass, metabolism, lung capacity, heart speed,

	Game shows you the common strands of DNA
	Isolate a particular Genome strand by selecting as diverse a population as possible, but that all share the same trait
	For example, everyone has brown hair, but has completely different nose size, lung capacity, height, predisposition to diabetes, etc.

	Select and save Genome chunk templates into your Genome Dictionary
	

	Serums
	A serum is a set of enzyme instructions
	Enzymes are simple DNA manipulating rules:
			Cut: Find Pattern and cut at that point (Before, or After Pattern)
			Join: Find a loose end with Pattern, and re-connect (Before or After Pattern)
			Destroy : Destroy all DNA Before or After Pattern, until it reaches the End
			Add : Add a specific DNA sequence, or Junk, Before or After Pattern
			



	The Disease is a serum that is applied to everyone in the Infected group
	The Disease will always create a fatal condition in an otherwise healthy person (critically low lung capacity, stopped heart speed)
	You must modify the DNA of your infected group to prevent them from dying from the Disease






	Gene:
		Attribute: Thing that is modified
		Status : Status of Thing

		Example: Hair, Brown.  Lung Capacity , Low. Insulin Resistance, High. Metabolism, Fast.

		Gene produces a person's DNA string
		




	Problems:
		How do you compare several people at once?
		How do you tell the difference between Junk and DNA id's


		How do you determine What the targeted Gene is




	*/
}
