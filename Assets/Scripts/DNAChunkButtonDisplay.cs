using UnityEngine;
using UnityEngine.UI;

public class DNAChunkButtonDisplay : MonoBehaviour {

	public string groupID;
	public bool isSelected;

	private Text _textComp;
	private Image _imageComp;
	private RectTransform _transformComp;
	private LayoutElement _layoutElementComp;

	private DNAChunk _chunk;
	// Use this for initialization
	void Start () {
		
	}
	
	public void initialize()
	{
		_imageComp = GetComponentInChildren<Image>();
		_textComp = GetComponentInChildren<Text>();
		_transformComp = GetComponent<RectTransform>();
		_layoutElementComp = GetComponent<LayoutElement>();
	}

	public void SetChunk(DNAChunk newChunk)
	{
		_chunk = newChunk;
		_textComp.text = _chunk.DNASequence;
	}

	// Update is called once per frame
	public void Update () {
		_imageComp.rectTransform.sizeDelta = _textComp.rectTransform.sizeDelta;
		_transformComp.sizeDelta = _textComp.rectTransform.sizeDelta;
		_layoutElementComp.preferredWidth = _textComp.rectTransform.sizeDelta.x;
		_layoutElementComp.preferredHeight = _textComp.rectTransform.sizeDelta.y;
	}
}
