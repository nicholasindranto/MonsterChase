using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX = -61f;//ngeset minimum dari x nya supaya kameranya kaga gerak melebihi batas background

    [SerializeField]
    private float maxX = 61f;//ini juga sama ngeset yg kanan, kalau yg kiri itu yg minX

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        //kita ngambil GameObject lalu mencari GameObject dengan tag FindWithTag() "Player" setelah itu
        //mengambil properti transform nya
    }

    // Update is called once per frame
    void LateUpdate(){//ini apa??
        if(!player) return;//kalau playernya mati / ilang maka seluruh kode dibawah tdk di eksekusi
        //mengapa? karena kalau mati kameranya kaga mungkin follow player lg dong tuh di line 32
        //kode !player itu sama aja dengan player == null
        //if(player) itu sama aja dengan if(player != null)

        //LateUpdate itu adalah method yang bakalan dieksekusi tepat setelah method Update dieksekusi
        //kalau kita nggerakin kameranya di method Update, ntar bakalan kaya patah patah gitu gerakan kameranya
        tempPos = transform.position;//disini kita ngambil posisi skrng dari MainCamera
        tempPos.x = player.position.x;//stelah itu posisi x nya diganti sama posisi si player
        //posisi player diambil di method Start diatas

        if(tempPos.x < minX)tempPos.x = minX;

        if(tempPos.x > maxX)tempPos.x = maxX;

        transform.position = tempPos;//disini kita ngubah value dari posisi nya si MainCamera
    }
}
