using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public AudioClip enemy_dies;
	public AudioSource audioSource;
	public Text gold;
	public GameObject floating_text;
    public static float health;
	public float health2 = health;
	public float attack;

	// Use this for initialization
	void Start () {
		health = 100;
		attack = 5;
	}
	
	// Update is called once per frame
	void Update () {
		health2 = health;

		// if (health < 1)
		// {
		// 	Destroy(gameObject);

		// }
	}

	public void Damage(int input_damage, bool crit)
	{
		gold.GetComponent<Score>().increase_gold();
		health -= input_damage;
		show_floating_text(input_damage, crit);
		
	}

    void show_floating_text(int input_damage, bool crit)
    {
		// transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
		float enemy_position_x = transform.position.x;
		float enemy_position_y = transform.position.y;
		float enemy_min_x = enemy_position_x - 1.0f;
		float enemy_max_x = 1.0f + enemy_position_x;
		float enemy_min_y = enemy_position_y - 1.0f;
		float enemy_max_y = 1.0f + enemy_position_y;

        GameObject go = Instantiate(floating_text, new Vector3(Random.Range(enemy_min_x, enemy_max_x), Random.Range(enemy_min_y, enemy_max_y), transform.position.z - 1), Quaternion.identity);
		if (crit == true)
		{
			go.GetComponent<TextMesh>().color = new Color(255, 255, 0);
			go.GetComponent<floating_text>().destroy_time = 2;
			go.GetComponent<TextMesh>().characterSize = 3;
		}
		go.GetComponent<TextMesh>().text = input_damage.ToString();
    }

	public void destroy_self()
	{
		audioSource.PlayOneShot(enemy_dies);
		Destroy(gameObject, 1);
	}

}
