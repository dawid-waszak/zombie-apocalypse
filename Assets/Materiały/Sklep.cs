using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sklep : MonoBehaviour {
    public int idBroni;
    public bool enter;
    public GameObject text;
    Transform player;
    public AudioSource source;
    public AudioClip buy;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        source = transform.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	if(enter == true)
        {
            if (idBroni == 1)
            {
                text.GetComponent<Text>().text = "Shotgun - 5000$ [E] Aby kupić";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(player.GetComponent<Hud>().punkty >= 5000)
                    {
                        player.GetComponent<Hud>().punkty -= 5000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 1;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 1;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if(idBroni == 2)
            {
                text.GetComponent<Text>().text = "Shotgun - 3000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 3000)
                    {
                        player.GetComponent<Hud>().punkty -= 3000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 2;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 2;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if (idBroni == 3)
            {
                text.GetComponent<Text>().text = "Uzi - 5000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 5000)
                    {
                        player.GetComponent<Hud>().punkty -= 5000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 3;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 3;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if (idBroni == 4)
            {
                text.GetComponent<Text>().text = "Ak - 47 - 6000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 6000)
                    {
                        player.GetComponent<Hud>().punkty -= 6000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 4;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 4;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if (idBroni == 5)
            {
                text.GetComponent<Text>().text = "Granatnik - 7000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 7000)
                    {
                        player.GetComponent<Hud>().punkty -= 7000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 5;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 5;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if (idBroni == 6)
            {
                text.GetComponent<Text>().text = "Rewolwer - 1000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 1000)
                    {
                        player.GetComponent<Hud>().punkty -= 1000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 6;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 6;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
            else if (idBroni == 7)
            {
                text.GetComponent<Text>().text = "Sniper - 8000$ [E] Aby kupić";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Hud>().punkty >= 8000)
                    {
                        player.GetComponent<Hud>().punkty -= 8000;
                        if (player.GetComponent<Strzelanie>().bron1 == false)
                            player.GetComponent<Strzelanie>().idBroni2 = 7;
                        else
                            player.GetComponent<Strzelanie>().idBroni1 = 7;
                        source.PlayOneShot(buy, 0.5f);
                    }
                }
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            enter = true;
            text.active = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            text.active = false;
               enter = false;
        }
    }
}
