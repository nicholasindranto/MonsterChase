using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    [SerializeField]//kode ini tu kaya memperbolehkan kita sebagai dev utk ngubah value lngsng di unitynya
                    //tanpa kode ini maka variabelnya g akan muncul di unity karna private
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake(){
        //ngambil semua komponen yang ada di gameobject unity
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate(){//ini bakalan di eksekusi bukan setiap frame tapi setiap sekian detik sekali
        //setingan waktunya bisa diliat di Edit->Project Settings->Time->Fixed Timestep. defaultnya 0.02
        PlayerJump();
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        //GetAxisRaw(Horizontal") itu kode buat ngambil kalo keyboard a / d / left arrow / right arror ditekan
        //kalo a / left itu -1 kalo d / right itu 1 kalo kaga ditekan ya 0
        //GetAxis("Horizontal") sama aja tapi dia itu pas neken tombol pas selesai neken tombol value nya
        //kaga langsung ke set -1 / 0 / 1 tapi turun / naik perlahan 0.9 0.8 0.7 dst

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;//kode movementnya
        //Vector3(sumbuX, sumbuY, sumbuZ). jadi karna gerakannya cuma kanan kiri maka yg diubah yg x
        //moveForce kecepatannya
        //Time.deltaTime biar pas jalan tu animasinya smooth kaga jumping jumping per frame
    }

    void AnimatePlayer(){
        if(movementX > 0){//bergerak kekanan
            anim.SetBool(WALK_ANIMATION, true);//animasi jalannya dinyalain
            sr.flipX = false;//wajahnya kekanan
        } else if(movementX < 0){//bergerak kekiri
            anim.SetBool(WALK_ANIMATION, true);//animasi jalan nyala
            sr.flipX = true;//wajahnya kekiri
        } else {//diem ga gerak
            anim.SetBool(WALK_ANIMATION, false);//animasi jalannya mati
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){//GetButtonDown("Jump") kode buat ngedeteksi key utk jump
            //jadi bakalan beda beda tombolnya seuai platform. contoh kalo pake PC nanti space itu jump
            //ada lagi GetButtonUp sama GetButton
            //klo yg down itu bakalan bernilai true tepat ketika sebuah button yang ada di dalam kurung
            //keywordnya ditekan
            //yg up itu bakalan true pas selesai di tekan misal pencet space trus ditahan nah pas dilepas
            //baru true
            //klo yg kaga ada up ato down nya GetButton itu dia bakalan true pas neken ama pas lepas
            //jadi truenya kaya 2 kali dan pas ditahan ya true terus ga akan berenti sampe selese neken
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);//kode buat animasi jumpnya
            //AddForce itu kaya ngasih sebuah gaya ke atas / vertikal ke atas sama jatuh bebas gravitasi
            //berapa value naik ke atasnya? ya jumpForce nya itu
            //ForceMode2D.Impulse itu kaya semacam animasi yg mbikin mulus, klo kaga ada, ya gk lompat dia
            //kaya ngeblitz doang, kaga keliatan
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){//kode buat mendeteksi collision antara player
        //sama ground
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            //apabila sebuah gameObject collision dengan gameObject dengan tag GROUND_TAG maka
            //isGrounded = true

            //CompareTag() itu bertujuan buat membandingkan atau mencocokkan sebuah gameObject yg collide
            //dengannya dengan tag GROUND_TAG
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG)){
            //kalau bersentuhan dengan gameObject dengan tag Enemy maka
            Destroy(gameObject);
            //yg dihancurin apa? ya component dimana script ini nempel yaitu di component Player
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){//ni kode buat ngedeteksi collision dengan ghost
        if (collision.CompareTag(ENEMY_TAG)){//Collider2D bisa langsung CompareTag, Collision2D gabisa
            Destroy(gameObject);
        }
    }
}
