using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour{
    [HideInInspector]//biar variabel ini kaga tampil di inspector
    public float speed;
    private Rigidbody2D myBody;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        //ada 2 cara buat nggerakin karakter
        //yg pertama di player yg AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        //yg kedua yg velocity
        //dua duanya sama sama nggerakin
        //klo yg disini kita maunya si monster buat gerak kanan kiri jadi valuenya di set ke x doang
        //yg y myBody.velocity.y itu kaya ngasih value yg sama dengan velocity dari y nya
    }
}
