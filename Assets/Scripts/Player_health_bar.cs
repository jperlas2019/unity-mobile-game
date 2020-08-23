using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health_bar : MonoBehaviour {

	public Slider slider;
	void Start()
	{
		slider.maxValue = Player.max_health;
	}

	void Update()
	{
		SetHealth();
	}

	public void SetHealth()
	{

		slider.value = Player.health;
		slider.maxValue = Player.max_health;
	}
}
