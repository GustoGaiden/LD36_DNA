using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class DNAMarker
{
	private static readonly string[] DNACHARS = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
	private static readonly string[] JUNKCHARS = { "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" };
	public string Sequence { get; private set; } // Hex String
	
	private int _minChunks = 3; // number of chunks that uniquely ID this sequence. Does not include Start/End chunks, which are mandatory
	private int _maxChunks = 10;

	private int _minChunkSize = 4; // number of characters per chunk
	private int _maxChunkSize = 10;

	private int _minJunkSize = 0; // Number of Junk characters to separate IDS chunks
	private int _maxJunkSize = 10;

	private StringBuilder _builder;
	public List<DNAChunk> Chunks;
	public string IndexName { get; private set; }

	public DNAMarker(string index)
	{
		IndexName = index;
		Chunks = new List<DNAChunk>();
		_builder = new StringBuilder();
		generateAllChunks();
		Sequence = _builder.ToString();
	}

	private void generateAllChunks()
	{
		clearBuilder();

		generateJunkChunk();
		generateIDChunk(); // Starting Chunk
		int numChunks = Random.Range(_minChunks, _maxChunks);
		
		for (int i = 0; i < numChunks; i++)
		{
			generateJunkChunk();
			generateIDChunk();
			generateJunkChunk();
		}

		generateIDChunk(); // EndingChunk
		generateJunkChunk();
	}

	private void generateIDChunk()
	{
		int chunkSize = Random.Range(_minChunkSize, _maxChunkSize);
		generateChunk(chunkSize);
		AddChunkToList(false);


	}

	private void generateJunkChunk()
	{
		int chunkSize = Random.Range(_minJunkSize, _maxJunkSize);
		generateJunk(chunkSize);
		AddChunkToList(true);
	}

	private void generateChunk(int chunkSize)
	{
		for (int i = 0; i < chunkSize; i++)
		{
			_builder.Append(GetDNAChar());
		}
	}

	private void generateJunk(int chunkSize)
	{

		for (int i = 0; i < chunkSize; i++)
		{
			_builder.Append(GetJunkChar());
		}
	}

	private void AddChunkToList(bool isJunk)
	{
		DNAChunk newChunk = new DNAChunk(_builder.ToString(), IndexName, isJunk);
		//Debug.Log("Adding Chunk Sequence: " + _builder.ToString());
		Chunks.Add(newChunk);
		clearBuilder();
	}

	private void clearBuilder()
	{
		_builder.Remove(0, _builder.Length);
	}

	private static string GetDNAChar()
	{
		int charIndex = Random.Range(0, DNACHARS.Length);
		return DNACHARS[charIndex];
	}

	private static string GetJunkChar()
	{
		int charIndex = Random.Range(0, JUNKCHARS.Length);
		return JUNKCHARS[charIndex];
	}
}
