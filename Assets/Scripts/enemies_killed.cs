using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemies_killed : MonoBehaviour
{
    public Text KILLED_text;
    public static int killed_value;
    public void Start()
    {
        killed_value = 0;
        KILLED_text.text = "KILLED: " + killed_value;
    }
    public void increase_killed()
    {
        killed_value += 1;
        KILLED_text.text = "KILLED: " + killed_value;
    }
    public void reset_killed()
    {
        killed_value = 0;
        KILLED_text.text = "KILLED: " + killed_value;
    }
}
