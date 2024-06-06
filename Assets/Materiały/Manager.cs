using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {
    public int fala = 1;
    public int ileZombieJest;
    public int aktualnaIloscZombie;
    public int ileZombieZostalo;
    public int ileHp;
    public int max = 1;
    public GameObject[] spawny;
    public GameObject[] spawny1;
    public Transform zwykly;
    public Transform zombie;
    public Transform szybki;
    public Transform wielki;
    public Transform gruby;
    public Transform falaT;
    GameObject player;
    public float timer;
    float czas = 6;
    public int hp = 100;
    public int obrazenia = 5;
    public int rand;
    public float koniecRundy;
    public AudioClip bell;
    public bool czekaj;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ileZombieJest = 10;
        ileZombieZostalo = ileZombieJest;
	}
	// Update is called once per frame
	void Update () {
        falaT.GetComponent<Text>().text = "Fala: " + fala;
        if (fala == 3)
        {
            max = 3;
        }
        else if (fala == 5)
        {
            max = 4;
        }
        else if (fala == 7)
            max = 5;
        if (ileZombieZostalo == 0)
        {
            koniecRundy += Time.deltaTime;
        }
        if(koniecRundy > 10)
        {
            fala++;
            aktualnaIloscZombie = 0;
            ileZombieJest += 1;
            if (czas > 0.5)
                czas -= 0.5f;
            hp += 10;
            obrazenia += 1;
            player.GetComponent<AudioSource>().PlayOneShot(bell, 0.6f);
            ileZombieZostalo = ileZombieJest;
            koniecRundy = 0;
        }
     if(aktualnaIloscZombie < ileZombieJest)
        {
            GameObject x;
            int los = Random.Range(0, spawny.Length);
            rand = Random.Range(1, max);
            timer += Time.deltaTime;
            if (timer > czas)
            {
                for (int i = 0; i < ileZombieJest; i++)
                {
                    if (rand == 1)
                        zombie = zwykly;
                    else if (rand == 2)
                        zombie = szybki;
                    else if (rand == 3)
                        zombie = wielki;
                    else if (rand == 4)
                        zombie = gruby;
                    Instantiate(zombie, spawny[los].transform.position, spawny[los].transform.rotation);
                    aktualnaIloscZombie++;
                    timer = 0;
                    break;
                }
            }
        }
	}
}
