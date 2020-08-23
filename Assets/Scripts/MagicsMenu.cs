using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicsMenu : MonoBehaviour
{
    public GameObject magicsMenuUI;
    public GameObject MainMenu;
    public GameObject MenuButton;

    // void Start()
    // {
    //     magicsMenuUI.SetActive(false);
    // }

    public void closeMagics()
    {
        magicsMenuUI.SetActive(false);
        MainMenu.SetActive(true);
        MenuButton.SetActive(true);
    }

    public void openMagics()
    {
        magicsMenuUI.SetActive(true);
        MainMenu.SetActive(false);
        MenuButton.SetActive(false);
    }

}
