using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D collision){
        //kalau sebuah objek nyentuh ni BoxCollider2D maka
        if(collision.CompareTag("Enemy") || collision.CompareTag("Player")){
            //kalau yg nyentuh dia itu tag nya Enemy atau Player
            Destroy(collision.gameObject);
            //maka yg di destriy itu yg nyenruh si BoxCollider2D nya yaitu gameObject dengan tag Enemy / Player
            Debug.Log("Collider entered with tag: " + collision.tag);
        }
    }
}
