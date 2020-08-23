using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combo_multi : MonoBehaviour
{
    public Text combo_multi_text;
    public GameObject combo_value_object;
    public float combo_multi_value;
    public Animator combo_multi_animator;

    void Update()
    {
        combo_multi_value = (float)1.00 + (float)combo_value_object.GetComponent<combo_value>().combo1 / 100;
        combo_multi_text.text = "COMBO " + combo_value_object.GetComponent<combo_value>().combo1 + "\n" + "X" + combo_multi_value;
    }
}
