using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour{
    public void PlayGame(){//kalau mau ada param itu cuma bisa 1 doang cuy gabisa lebih
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //ini tu kaya ngeconvert string jadi int Parse
            //UnityEngine.EventSystems.Even blablabla itu kaya ngambil
            //nama dari tombol / currentSelectedGameObject yg diklik
            //yaitu 0 atau 1 nama dari component di unitynya

        GameManager.instance.CharIndex = selectedCharacter;//nah ini cuy guna dari static itu
        //kode ni tu kaya ngirimin angka atau character apa yg dipilih sama si user cuy
        //daripada kaya gini GameManager gm = new GameManager();  ->  gm.CharIndex = selectedCharacter;
        
        SceneManager.LoadScene("Gameplay");//kode buat pindah scene dari main menu ke gameplay
    }
}
