using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combo_meter : MonoBehaviour
{
    public Slider combo_slider;

    void Start()
    {
        combo_slider.maxValue = combo_value.max_combo;
    }

    void Update()
    {
        combo_slider.maxValue = combo_value.max_combo;
        combo_slider.value = combo_value.combo;
    }
}
