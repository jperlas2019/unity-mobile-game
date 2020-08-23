using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special : MonoBehaviour
{
    public int SPECIAL;
    public int SPECIAL_max;
    public Text SPECIAL_text;

    void Start()
    {
        SPECIAL = 0;
        SPECIAL_max = 30;
        SPECIAL_text.text = "SPECIAL: " + SPECIAL + "/" + SPECIAL_max;
    }
    public void increase_special()
    {
        if ((SPECIAL + 1) <= SPECIAL_max)
        {
            SPECIAL += 1;
        }
        SPECIAL_text.text = "SPECIAL: " + SPECIAL + "/" + SPECIAL_max;
        if(SPECIAL >= 30)
        {
            SPECIAL_text.color = new Color(255, 255, 0);
        } else {
            SPECIAL_text.color = new Color(255, 255, 255);
        }
    }
    public void reset_special()
    {
        SPECIAL = 0;
        SPECIAL_text.text = "SPECIAL: " + SPECIAL + "/" + SPECIAL_max;
        SPECIAL_text.color = new Color(255, 255, 255);
    }

}
