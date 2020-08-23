using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public GameObject statsMenuUI;
    public GameObject MainHUD;
    public GameObject Player;
    public GameObject MainMenu;
    public GameObject MagicButton;

    // void Start(){
    //     statsMenuUI.SetActive(false);

    // }

    public void closeStats() {
        statsMenuUI.SetActive(false);
        MainMenu.SetActive(true);
        MagicButton.SetActive(true);
        // Time.timeScale = 1f;
    }

    public void openStats() {
        statsMenuUI.SetActive(true);
        MagicButton.SetActive(false);
        if(Player.GetComponent<Player>().ATTR > 0){
            MainHUD.GetComponent<MainHUD>().interact();
        } else {
            MainHUD.GetComponent<MainHUD>().non_interact();
        }
        MainMenu.SetActive(false);

        
        // Time.timeScale = 0f;
        
    }

}

