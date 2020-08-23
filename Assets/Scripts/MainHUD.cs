using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHUD : MonoBehaviour {
	public GameObject Player;
	public Button STRButton;
	public Button DEXButton;
	public Button VITButton;
	public Button MAGButton;
	public Button SPIButton;
	public Button LUKButton;
	
	
	public void interact()
	{
		STRButton.GetComponent<Attribute_button>().interactable();
		DEXButton.GetComponent<Attribute_button>().interactable();
		VITButton.GetComponent<Attribute_button>().interactable();
		MAGButton.GetComponent<Attribute_button>().interactable();
		SPIButton.GetComponent<Attribute_button>().interactable();
		LUKButton.GetComponent<Attribute_button>().interactable();
	}
	public void non_interact()
	{
		STRButton.GetComponent<Attribute_button>().non_interactable();
		DEXButton.GetComponent<Attribute_button>().non_interactable();
		VITButton.GetComponent<Attribute_button>().non_interactable();
		MAGButton.GetComponent<Attribute_button>().non_interactable();
		SPIButton.GetComponent<Attribute_button>().non_interactable();
		LUKButton.GetComponent<Attribute_button>().non_interactable();
	}
}
