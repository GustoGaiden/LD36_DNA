using UnityEngine;
using System.Collections;

public class DNAChunk {

	public string DNASequence { get; private set; }
	public bool isJunk { get; private set; }

	public DNAChunk(string sequence, bool junk)
	{
		DNASequence = sequence;
		isJunk = junk;
	}
	
}
