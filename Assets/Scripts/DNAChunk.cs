using UnityEngine;
using System.Collections;

public class DNAChunk {

	public string DNASequence { get; private set; }
	public string IndexName { get; private set; }
	public bool isJunk { get; private set; }

	public DNAChunk(string sequence, string index, bool junk)
	{
		DNASequence = sequence;
		IndexName = index;
		isJunk = junk;
	}
	
}
