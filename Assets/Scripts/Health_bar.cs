using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour 
{

	public Slider slider;
	void Start()
	{
		slider.maxValue = Enemy.health;
	}

	void Update()
	{
		SetHealth();
	}

	public void SetHealth()
	{

		slider.value = Enemy.health;
		
	}

}
