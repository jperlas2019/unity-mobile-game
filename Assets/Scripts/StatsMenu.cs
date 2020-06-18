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

    void Start(){
        statsMenuUI.SetActive(false);

    }

    public void closeStats() {
        statsMenuUI.SetActive(false);
        MainMenu.SetActive(true);
        // Time.timeScale = 1f;
    }

    public void openStats() {
        statsMenuUI.SetActive(true);
        if(Player.GetComponent<Player>().ATTR > 0){
            MainHUD.GetComponent<MainHUD>().interact();
        } else {
            MainHUD.GetComponent<MainHUD>().non_interact();
        }
        MainMenu.SetActive(false);

        
        // Time.timeScale = 0f;
        
    }

}

