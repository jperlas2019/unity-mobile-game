using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public GameObject MainHUD;
	public AudioClip levelup;
	public AudioClip player_hurt;
	public AudioSource audioSource;
	public GameObject floating_text;
    public static float health = 10.0f;
	public float health2 = health;
	public static float default_attack = 5.0f;
	public static float default_attack_min = 1.0f;
	public static float default_attack_max = 5.0f;
	public static float default_complete_damage = 5.0f;
	public static int max_exp;
	public int STR;
	public int DEX;
	public int VIT;
	public int MAG;
	public int SPI;
	public int LUK;
	public int EXP;
	public int LVL; 
	public int ATTR;
	public int CRIT_CHANCE;
	public Text STR_text;
	public Text DEX_text;
	public Text VIT_text;
	public Text MAG_text;
	public Text SPI_text;
	public Text LUK_text;
	public Text EXP_text;
	public Text LVL_text;
	public Text ATTR_text;
	

	// Use this for initialization
	void Start () {
		STR = 1;
		DEX = 0;
		VIT = 0;
		MAG = 0;
		SPI = 0;
		LUK = 0;
		EXP = 0;
		LVL = 1;
		max_exp = 2;
		ATTR = 0;
		CRIT_CHANCE = 5;
		update_stats();
	}
	
	// Update is called once per frame
	void Update () {
		health2 = health;
	}

	public void Damage(float input_damage)
	{
		health -= input_damage;
		audioSource.PlayOneShot(player_hurt);
		show_floating_text(input_damage);
	}


	    void show_floating_text(float input_damage)
    {
		float player_position_x = transform.position.x;
		float player_position_y = transform.position.y;
		float player_min_x = player_position_x - 1.0f;
		float player_max_x = 1.0f + player_position_x;
		float player_min_y = player_position_y - 1.0f;
		float player_max_y = 1.0f + player_position_y;
        GameObject go = Instantiate(floating_text, new Vector3(Random.Range(player_min_x, player_max_x), Random.Range(player_min_y, player_max_y), transform.position.z - 1), Quaternion.identity);
		go.GetComponent<TextMesh>().text = input_damage.ToString();
    }

	public void level_up()
	{
		audioSource.PlayOneShot(levelup);
		max_exp += Mathf.RoundToInt(max_exp / 2);
		EXP = 0;
		LVL += 1;
		STR += 1;
		DEX += 1;
		VIT += 1;
		MAG += 1;
		SPI += 1;
		LUK += 1;
		ATTR += 5;
		MainHUD.GetComponent<MainHUD>().interact();
		
	}

	public void update_stats()
	{
		if (EXP >= max_exp)
			{
				level_up();
			}
		STR_text.text = "STR: " + STR;
		DEX_text.text = "DEX: " + DEX;
		VIT_text.text = "VIT: " + VIT;
		MAG_text.text = "MAG: " + MAG;
		SPI_text.text = "SPI: " + SPI;
		LUK_text.text = "LUK: " + LUK;
		EXP_text.text = "EXP: " + EXP + "/" + max_exp;
		LVL_text.text = "LVL: " + LVL;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
	}

	public void increase_STR()
	{
		STR += 1;
		STR_text.text = "STR: " + STR;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
		public void increase_DEX()
	{
		DEX += 1;
		DEX_text.text = "DEX: " + DEX;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
		public void increase_VIT()
	{
		VIT += 1;
		VIT_text.text = "VIT: " + VIT;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
		public void increase_MAG()
	{
		MAG += 1;
		MAG_text.text = "MAG: " + MAG;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
		public void increase_SPI()
	{
		SPI += 1;
		SPI_text.text = "SPI: " + SPI;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
		public void increase_LUK()
	{
		LUK += 1;
		LUK_text.text = "LUK: " + LUK;
		ATTR -= 1;
		ATTR_text.text = "SKILL POINTS: " + ATTR;
		if (ATTR < 1)
		{
			MainHUD.GetComponent<MainHUD>().non_interact();
		}
	}
}
