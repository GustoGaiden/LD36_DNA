using UnityEngine;
using UnityEngine.UI;

public class DNAChunkButtonDisplay : MonoBehaviour {

	public string groupID;
	public bool isMatched { get; private set; }
	public bool isSelected{ get; private set; }

	private Text _textComp;
	private Image _imageComp;
	private RectTransform _transformComp;
	private LayoutElement _layoutElementComp;
	
	private Color _matchedColor = Color.green;
	private Color _selectedColor = Color.cyan;
	private Color _neutralColor = new Color(.8f, .8f, .8f, .2f);

	public DNAChunk chunk { get; private set;  }
	// Use this for initialization
	void Start () {
		
	}
	
	public void initialize()
	{
		_imageComp = GetComponentInChildren<Image>();
		setMatch(false);
		_textComp = GetComponentInChildren<Text>();
		_transformComp = GetComponent<RectTransform>();
		_layoutElementComp = GetComponent<LayoutElement>();
		Main.eventManager.AddListener<SetChunkSelectionEvent>(onSelectionChanged);
	}

	public void SetChunk(DNAChunk newChunk)
	{
		chunk = newChunk;
		_textComp.text = chunk.DNASequence;
	}

	// Update is called once per frame
	public void Update () {
		_imageComp.rectTransform.sizeDelta = _textComp.rectTransform.sizeDelta;
		_transformComp.sizeDelta = _textComp.rectTransform.sizeDelta;
		_layoutElementComp.preferredWidth = _textComp.rectTransform.sizeDelta.x;
		_layoutElementComp.preferredHeight = _textComp.rectTransform.sizeDelta.y;
	}

	public void onClick()
	{
		Main.eventManager.TriggerEvent(new SetChunkSelectionEvent(chunk));
	}

	private void onSelectionChanged(SetChunkSelectionEvent e)
	{
		bool newSelection = false;
		if(e.selectedChunk != null)
		{
			newSelection = (e.selectedChunk.DNASequence == chunk.DNASequence);
		}

		if(isSelected != newSelection)
		{
			setSelected(newSelection);
		}
	}

	public void setMatch(bool value)
	{
		isMatched = value;
		setColor();
	}

	public void setSelected(bool value)
	{
		isSelected = value;
		setColor();
	}

	public void setColor()
	{
		_imageComp.color = isSelected ? _selectedColor : (isMatched ? _matchedColor : _neutralColor);
	}

	
}
