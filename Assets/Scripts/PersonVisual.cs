using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonVisual : MonoBehaviour {

	public Image HeadContainer;
	public Image EyesContainer;
	public Image BodyContainer;
	public Image HairContainer;

	public PersonVisual(PersonData data)
	{
		//HeadContainer.sprite = Main.instance.TheHumanGenome[data.UniqueDNA];
	}

}
