using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager instance;
    //static tu kaya kode biar class lain bisa mengakses public function atau public variables
    //yg ada di kelas lainnya
    //dlm hal ini staticnya itu dia mbikin biar semua kode public yg ada di class GameManager
    //tu bisa diakses dibanyak kelas

    //lah bukanne sama aja kaya instansiasi sebuah objek ya?? ya sama aja. jadi ini tu kaya alternatifnya
    //daripada Warrior w = new Warrior();      ->      w.name = "pejuang";
    //mending lngsung ae Warrior.name = "pejuang";
    //(dengan syarat di class Warrior variabel name itu public static string name;)

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex{
        get{return _charIndex;}
        set{_charIndex = value;}
    }

    private void Awake(){
        if(instance == null){//kalau instansiasinya gada
            instance = this;//nanti bakalan bikin copy dari instansiasinya
            //biar apa? biar kita bisa tahu character apa yg dipilih sama si user cuy pas masuk ke gameplay
            DontDestroyOnLoad(gameObject);
            //ni kode mencegah biar pas ganti scene dari mainmenu ke gameplay ni class kaga diancurin
            //soalnya pas pindah tu, semua class atau object atau componenet yang ada di scene nya itu
            //bakalan diancurin dulu baru pindah
        } else {
            Destroy(gameObject);
            //kalau dah punya instance nya ya ancurin aja, brarti kita dah punya copy nya
        }
    }
    
    private void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;//langganan ke eventnya cuy

        //simpelnya gini kita dah langganan ke sebuah percetakan koran
        //nah maka dari itu kontak HP kita bakalan di save sama sana dong??
        //jadi kita bakalan dikasih tahu ama mereka si operator dari percetakan koran kalau korannya dah redi
        //mereka disini itu merujuk ke SceneManager.sceneLoaded

        //nah SceneManager.sceneLoaded bakalan mberi tahu kita nantinya scenenya itu apa
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;//batal langganan

        //simpelnya biar memorinya kaga leaked
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){//fungsi untuk eventnya
        //simpelnya karna si SceneManager.sceneLoaded ngomong kalo dah redi korannya
        //kalau disini itu dah pindah scenenya

        //maka kode dibawah dijalanin
        if(scene.name == "Gameplay"){
            //kalau nama scenenya itu Gameplay
            Instantiate(characters[CharIndex]);//maka kita munculin alias kita instansiasi karakternya
        }
    }
}
