using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class DNASequence
{
	private static readonly string[] DNACHARS = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
	public string Sequence { get; private set; } // Hex String
	
	private int _minChunks = 3; // number of chunks that uniquely ID this sequence. Does not include Start/End chunks, which are mandatory
	private int _maxChunks = 10;

	private int _minChunkSize = 4; // number of characters per chunk
	private int _maxChunkSize = 10;

	private int _minJunkSize = 0; // Number of Junk characters to separate IDS chunks
	private int _maxJunkSize = 10;

	private StringBuilder _builder;

	public DNASequence()
	{
		_builder = new StringBuilder();
		generateSequenceString();
		Sequence = _builder.ToString();
	}

	private void generateSequenceString()
	{
		
		
		string returnSequence = "";

		generateIDChunk(); // Starting Chunk
		int numChunks = Random.Range(_minChunks, _maxChunks);
		
		for (int i = 0; i < numChunks; i++)
		{
			
		}

		generateIDChunk(); // EndingChunk
		
	}

	private void generateIDChunk()
	{
		int chunkSize = Random.Range(_minChunkSize, _maxChunkSize);
		generateChunk(chunkSize);
	}

	private void generateJunkChunk()
	{
		int chunkSize = Random.Range(_minJunkSize, _maxJunkSize);
		generateChunk(chunkSize);
	}

	private void generateChunk(int chunkSize)
	{

		for (int i = 0; i < chunkSize; i++)
		{
			_builder.Append(GetDNAChar());
		}
	}

	private static string GetDNAChar()
	{
		int charIndex = Random.Range(0, DNACHARS.Length);
		return DNACHARS[charIndex];
	}
}
