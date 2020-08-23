using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combo_value : MonoBehaviour
{
    public Text combo_text;
    static public int max_combo;
    static public int combo;

    public int combo1 = combo;

    void Start()
    {
        max_combo = 100;
        combo = 0;
        combo1 = combo;
        combo_text.text = combo + "/" + max_combo;
    }

    public void increase_combo(int value = 1)
    {
        combo += value;
        combo1 = combo;
        combo_text.text = combo + "/" + max_combo;
    }

    public void reset_combo()
    {
        combo = 0;
        combo1 = combo;
        combo_text.text = combo + "/" + max_combo;
    }

    public void decrease_combo(int value)
    {
        combo -= value;
        combo1 = combo;
        combo_text.text = combo + "/" + max_combo;
    }
}
