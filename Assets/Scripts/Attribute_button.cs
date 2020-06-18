using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attribute_button : MonoBehaviour {

	public Button attribute_button;

	// public void Start()
	// {
	// 	attribute_button.interactable = false;
	// }
	public void interactable()
	{
		attribute_button.interactable = true;
	}

	public void non_interactable()
	{
		attribute_button.interactable = false;
	}

}
