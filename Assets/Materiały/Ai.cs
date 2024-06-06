using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
    
    Transform player;
    public bool szybkiZombie;
    public bool gruby;
    public bool bieg;
    public bool atak;
    public bool atakowac;
    public float timer;
    public int hp = 100;
    public int damage;
    public bool dzwiek;
    public AudioClip zombie;
    public AudioClip krzyk;
    public AudioSource source;
    public float glutTime;
    public int los;
    public bool bonus;
    public Transform Bonus1;
    public string typZombie;
    public Transform Bonus2;
    public Transform ZombieRagdoll;
    public Transform krew;
    public float speed;
    int bonusLos;
    int warstwa = ~(1 << 9 | 1 << 8);
	// Use this for initialization
	void Start () {
        if (szybkiZombie == false)
            speed = Camera.main.GetComponent<Manager>().fala / 10 + 3;
        else
            speed = 8;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hp = Camera.main.GetComponent<Manager>().hp;
        damage = Camera.main.GetComponent<Manager>().obrazenia;
        if (typZombie == "Wielki")
        {
            hp += 300;
            damage += 20;
        }
        source = transform.GetComponent<AudioSource>();
        los = Random.Range(1, 4);
        if(los == 2)
        {
            bonus = true;
            bonusLos = Random.Range(1, 4);
        }
    }
	
    void Hit(int obrazenia)
    {
        hp -= obrazenia;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed;
            if (Vector3.Distance(transform.position, player.position) <= 16)
            {
                if (dzwiek == false)
                {
                    source.PlayOneShot(zombie, 1f);
                    dzwiek = true;
                }
            }
            if (atakowac == true)
            {
                atak = true;
                timer += Time.deltaTime;
                if (timer > 0.5)
                {
                    timer = 0;
                    atakowac = false;
                }
            }
            if (atak == true)
            {
                transform.GetComponentInChildren<Animator>().SetBool("Atak", true);
                transform.GetComponentInChildren<Animator>().SetBool("Bieg", false);
            }
            else
            {
                transform.GetComponentInChildren<Animator>().SetBool("Atak", false);
                if (szybkiZombie == true)
                    transform.GetComponentInChildren<Animator>().SetBool("Bieg", true);
                else
                    transform.GetComponentInChildren<Animator>().SetBool("Bieg", false);
            }
            if(gruby == true)
            {
                glutTime += Time.deltaTime;
                if (glutTime > 5)
                {
                    source.PlayOneShot(krzyk, 0.5f);
                    if (Vector3.Distance(transform.position, player.position) <= 10)
                    {
                        player.GetComponent<Hud>().ogluszenie = true;
                    }
                    glutTime = 0;
                }
            }
            if (atakowac == false)
            {
                atak = false;
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.position;
                if (Vector3.Distance(transform.position, player.position) <= 1)
                {
                    int obrazenia = Random.Range(1, damage);
                    player.SendMessage("AtakZombie", obrazenia);
                    atakowac = true;
                }
            }
        }
        else
        {
                Camera.main.GetComponent<Manager>().ileZombieZostalo--;
                player.GetComponent<Hud>().punkty = player.GetComponent<Hud>().punkty + Random.Range(100, 500);
                if (bonus == true)
                {
                    if (bonusLos == 1)
                        Instantiate(Bonus1, transform.position, transform.rotation);
                    else if (bonusLos == 2)
                        Instantiate(Bonus2, transform.position, transform.rotation);
                }
            Instantiate(ZombieRagdoll, transform.GetChild(0).position, transform.GetChild(0).rotation);
            Ray ray = new Ray(transform.position, Vector3.down);

            RaycastHit hit;
            Vector3 poz = new Vector3(0, 0.1f, 0);
            if(Physics.Raycast(ray, out hit, 20, warstwa))
            {
                if (hit.collider != null)
                    Instantiate(krew, hit.point + poz, krew.rotation);
            }
            Destroy(gameObject);
        }
    }
}
