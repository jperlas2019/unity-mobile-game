using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_text : MonoBehaviour {

	public float destroy_time = 0.5f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, destroy_time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
