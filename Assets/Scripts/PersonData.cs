using UnityEngine;
using System.Collections.Generic;

public class PersonData
{
	//https://en.wikipedia.org/wiki/Nucleic_acid_sequence#/media/File:AMY1gene.png


	// All data about a person is contained here.
	// All people have a shared set of Genes

	
	public PersonData ()
	{
		
	}

	public static PersonData MakePersonDataFromConfig(HumanGenomeConfig genome)
	{
		List<string> DNAList = new List<string>();

		PersonData newData = new PersonData();
		foreach(GeneConfig geneConfig in Main.genomeConfig.HumanGenome)
		{
			// Get randomized status, based on probability
			List<GeneStatusProb> probList = new List<GeneStatusProb>();
			int totalProbs = 0;
			for(int i = 0; i < geneConfig.Types.Count; i++)
			{
				probList.Add(geneConfig.Types[i]);
				totalProbs += geneConfig.Types[i].Chances;
			}

			//DNASequence = 
			//DNAList.Add
		}

		return newData;
	}

	
}
