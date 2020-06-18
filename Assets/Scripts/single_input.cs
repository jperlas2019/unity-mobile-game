using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class single_input : MonoBehaviour {

    public float x = 0;
    public float y = 0;
    public int z = 0;
    public string input_name;
    public bool returnToOrigin = false;

    void Start()
    {
        transform.position = transform.position + new Vector3(x, y, z);
    }

}
