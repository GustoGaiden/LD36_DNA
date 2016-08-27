using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	public static Dictionary<string, Gene> TheHumanGenome;
	public static HumanGenomeConfig genomeConfig;

	// Use this for initialization
	void Start () {
		TheHumanGenome = new Dictionary<string, Gene>();
		foreach(GeneConfig protoGene in genomeConfig.HumanGenome)
		{
			foreach(GeneStatusProb geneType in protoGene.Types)
			{
				Gene newGene = new Gene(protoGene.Attribute, geneType.Status);
				TheHumanGenome.Add(newGene.IndexName, newGene);
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
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
		

	*/
}
