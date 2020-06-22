using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public GameObject Player;
	public GameObject enemy_prefab;
	public Text gold;
	public List<GameObject> enemy_array = new List<GameObject>();
	public GameObject strings;
	

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemy_array.Count < 1)
		{
			make_enemy();
			Debug.Log(strings.GetComponent<Strings>().complete_string + "debug");
			if (strings.GetComponent<Strings>().complete_string == false) {
				strings.GetComponent<Strings>().clear_string();
				strings.GetComponent<Strings>().create_string();
			}
			strings.GetComponent<Strings>().complete_string = false;
		}
		
		if (enemy_array[0].GetComponent<Enemy>().health2 < 1)
		{
			enemy_array[0].GetComponent<Enemy>().destroy_self();
			enemy_array.Clear();
			gold.GetComponent<Score>().increase_gold();
			Player.GetComponent<Player>().EXP += 1;
			Player.GetComponent<Player>().update_stats();
		}
	}

	void make_enemy()
	{
        GameObject new_enemy = Instantiate(enemy_prefab) as GameObject;
		enemy_array.Add(new_enemy);
	}

	void remove_enemy()
	{
		
	}
}
