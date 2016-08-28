using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class PersonData
{
	//https://en.wikipedia.org/wiki/Nucleic_acid_sequence#/media/File:AMY1gene.png


	// All data about a person is contained here.
	// All people have a shared set of Genes

	
	[SerializeField]
	public List<Gene> Genes;

	public PersonData ()
	{
		
	}

	public static PersonData MakePersonDataFromConfig()
	{
		List<string> DNAList = new List<string>();
		PersonData newData = new PersonData();
		newData.Genes = new List<Gene>();
		string aString = "";
		foreach (GeneConfig geneConfig in Main.instance.genomeConfig.HumanGenome)
		{
			// Get randomized status, based on probability
			List<GeneStatusConfig> probList = new List<GeneStatusConfig>();
			int totalProbs = 0;
			for (int i = 0; i < geneConfig.Types.Count; i++)
			{
				probList.Add(geneConfig.Types[i]);
				totalProbs += geneConfig.Types[i].Chances;
			}
			//Debug.Log("Prob COunt: " + probList.Count);
			string status = probList[Random.Range(0, probList.Count)].Status;
			string searchIndex = geneConfig.Attribute + "::" + status;
			aString += searchIndex + "\n";
			newData.Genes.Add(Main.instance.TheHumanGenome[searchIndex]);

		}


		// Debug.Log("DNA: " + aString);
		return newData;
	}

	public string DNAString
	{
		get
		{
			StringBuilder builder = new StringBuilder();
			foreach(Gene item in Genes)
			{
				builder.Append(item.DNAMarker.Sequence);
			}

			return builder.ToString();
		}
	}
	
}
