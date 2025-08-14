using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour{
    public void RestartGame(){
        // SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//utk pindah scene ke scene itu sendiri
        //ada 2 cara
        //1. langsung panggil aja namanya SceneManager.LoadScene("Gameplay");
        //2. manggil pake fungsi GetActiveScene() SceneManager.GetActiveScene().name
    }

    public void HomeButton(){
        SceneManager.LoadScene("MainMenu");//ini sama aja cuma nar pindah ke mainmenu
    }
}
