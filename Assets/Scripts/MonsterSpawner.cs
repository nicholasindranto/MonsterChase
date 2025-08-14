using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour{
    [SerializeField]
    private GameObject[] monsterReference;//buat nyimpen prefab dari si monster

    [SerializeField]
    private Transform leftPos, rightPos;//buat nyimpen posisi dari spawn pointnya

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;//random mau kanan atau kiri

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters(){
        while (true){//biar monsternya tu spawn terus cuy, klo kaga ada ini ntar cuma 1 doang yg muncul
            yield return new WaitForSeconds(Random.Range(1, 5));
            //monsternya bakalan di spawn setiap beberapa detik sekali yang waktunya itu random antara 1 - 5
            //angka randomnya itu yaitu 1,2,3,4 doang. 5 nya kaga ikut

            randomIndex = Random.Range(0, monsterReference.Length);
            //kaya ngerandom monster apa yg bakalan ke spawn
            //di random dari 0 sampe jumlah array dari monsterReference
            //array monsterReference bisa diliat lngsng di unitynya yaitu 3 karna monsternya cuma 3 (0,1,2)

            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            //kaya menginstansiasi sebuah objek berdasarkan indexnya tadi itu
            //istilahnya kaya menginstansiasi random monster
            //ingat cuy monsterReference disini tu object (GameObject) ya cuy jadi bisa di instansiasi

            if(randomSide == 0){//mosnternya spawn di kiri
                spawnedMonster.transform.position = leftPos.position;
                //posisinya di set di kiri
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                //kecepatan dari monsternya di set bukan diubah cuy karna emang gada valuenya pas dia ngespawn
                //ke angka random 4/5/6/7/8/9
            } else {//di kanan spawnnya
                spawnedMonster.transform.position = rightPos.position;
                //posisinya diset di kanan
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);//minus karna geraknya kekiri
                //ini juga sama aja di random speednya
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                //scale x dibuat negatif biar monsternya menghadap kekiri

            }
        }
    }
}
