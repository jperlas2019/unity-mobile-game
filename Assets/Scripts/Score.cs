using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int gold_value = 0;
	public Text gold;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gold.text = "GOLD: " + gold_value;
	}

	public void increase_gold()
	{
		gold_value += 1;
	}
}
