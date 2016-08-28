﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DNADisplayGrid : MonoBehaviour {

	public DNAChunkButtonDisplay ChunkButtonPrefab;
	public RectTransform ChunkRowPrefab;

	private RectTransform _transformComp;

	private List<RectTransform> _textRows;
	private List<DNAChunkButtonDisplay> _allChunks;

	private DNAChunkButtonDisplay _SelectedChunk;

	// Use this for initialization
	void Start () {

		_transformComp = GetComponent<RectTransform>();

		_textRows = new List<RectTransform>();
		_allChunks = new List<DNAChunkButtonDisplay>();

		
	}
	
	public void setPersonToDisplay(PersonVisual visual)
	{
		StartCoroutine("BuildChunksCoroutine", visual);
	}

	IEnumerator BuildChunksCoroutine(PersonVisual visual)
	{
		// I can't figure out how to update the sizeDelta values of layout groups at runtime
		// Unity seems to need the LateUpdate call before setting the values
		// so I have to use a co-routine.  Fortunately, it looks nice.

		clearAllRows();
		clearAllChunks();

		RectTransform currentRow = ReviveDeadRow();

		foreach (Gene item in visual.Data.Genes)
		{
			foreach(DNAChunk chunk in item.DNAMarker.Chunks)
			{
				DNAChunkButtonDisplay freshBtn = ReviveDeadChunk();
				freshBtn.SetChunk(chunk);
				freshBtn.transform.SetParent(currentRow.transform);

				yield return new WaitForEndOfFrame();
				
				//Debug.Log(currentRow.sizeDelta.x);
				
				if (currentRow.sizeDelta.x > 500)
				{
					currentRow = ReviveDeadRow();
					freshBtn.transform.SetParent(currentRow.transform);
				}
				//yield return new WaitForEndOfFrame();
			}
		}
	}

	private DNAChunkButtonDisplay ReviveDeadChunk()
	{
		foreach(DNAChunkButtonDisplay btn in _allChunks)
		{
			if(btn.gameObject.activeSelf == false)
			{
				btn.gameObject.SetActive(true);
				return btn;
			}
		}

		DNAChunkButtonDisplay newButton = GameObject.Instantiate(ChunkButtonPrefab);
		newButton.initialize();
		//newButton.transform.SetParent(transform);
		_allChunks.Add(newButton);

		return newButton;
	}

	private void clearAllChunks()
	{
		foreach (DNAChunkButtonDisplay btn in _allChunks)
		{
			btn.gameObject.SetActive(false);
		}
	}

	private void clearAllRows()
	{
		foreach (RectTransform row in _textRows)
		{
			row.gameObject.SetActive(false);
		}
	}

	private RectTransform ReviveDeadRow()
	{
		foreach (RectTransform row in _textRows)
		{
			if (row.gameObject.activeSelf == false)
			{
				row.gameObject.SetActive(true);
				return row;
			}
		}

		RectTransform newRow = GameObject.Instantiate(ChunkRowPrefab);
		newRow.transform.SetParent(transform);
		_textRows.Add(newRow);

		return newRow;
	}

	// Update is called once per frame
	void Update()
	{

		foreach (RectTransform btn in _textRows)
		{
			//Debug.Log(btn.sizeDelta.x);
		}
	}
}
