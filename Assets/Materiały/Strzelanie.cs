using UnityEngine;
using System.Collections;

public class Strzelanie : MonoBehaviour {
    public Transform pocisk;
    public float timer;
    float timer2;
    public float szybkoStrzelnosc;
    public int idBroni1;
    public int idBroni2;
    public bool bron1;
    public int idBroni;
    public GameObject[] bron;
    public bool muzzle;
    public int obrazenia;
    AudioSource source;
    public AudioClip[] bronsSound;
    public Transform blood;
    public Rigidbody granat;
    int warstwa = ~(1 << 8);
    public Transform miejsceWyrzutu;
    // Use this for initialization
	void Start () {
        source = transform.GetComponent<AudioSource>();
        Cursor.visible = false;
	}

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < bron.Length; i++)
        {
            if (i != idBroni)
                bron[i].active = false;
        }
        obrazenia = bron[idBroni].GetComponent<BronInfo>().obrazenia;
        szybkoStrzelnosc = bron[idBroni].GetComponent<BronInfo>().szybkostrzelnosc;
        bron[idBroni].active = true;
        if (bron[idBroni].tag == "Pistolet" || bron[idBroni].tag == "Uzi")
            transform.GetComponentInChildren<Animator>().SetBool("Karabin", false);
        else 
            transform.GetComponentInChildren<Animator>().SetBool("Karabin", true);
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        timer += Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            idBroni = idBroni1;
            bron1 = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            idBroni = idBroni2;
            bron1 = false;
        }
        if (bron1 == true)
            idBroni = idBroni1;
        else
            idBroni = idBroni2;
        if (muzzle == true)
        {
            timer2 += Time.deltaTime;
            bron[idBroni].transform.GetChild(0).gameObject.active = true;
            if (timer2 > 0.1)
            {
                bron[idBroni].transform.GetChild(0).gameObject.active = false;
                timer2 = 0;
                muzzle = false;
            }
        }
        if (Input.GetMouseButtonDown(0) && (bron[idBroni].tag == "Pistolet" || bron[idBroni].tag == "Shotgun" || bron[idBroni].tag == "Granatnik"))
        {
            if (timer > szybkoStrzelnosc)
            {
                if (bron[idBroni].tag != "Granatnik")
                {
                    source.PlayOneShot(bronsSound[idBroni], 1f);
                    muzzle = true;
                    if (Physics.SphereCast(ray, 1, out hit, 100, warstwa))
                    {
                        if (hit.collider.tag == "Zombie")
                        {
                            hit.collider.GetComponent<Ai>().hp -= obrazenia;
                            Instantiate(blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            timer = 0;
                        }
                        else
                            timer = 0;
                    }
                    else
                        timer = 0;
                }
                else
                {
                    Rigidbody clone;
                    clone = (Rigidbody)Instantiate(granat, miejsceWyrzutu.position, miejsceWyrzutu.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.forward * 10);
                    source.PlayOneShot(bronsSound[idBroni], 1f);
                    timer = 0;
                    muzzle = true;
                }
            }
        }
        if (Input.GetMouseButton(0) && (bron[idBroni].tag == "Karabin" || bron[idBroni].tag == "Uzi"))
        {
            if (timer > szybkoStrzelnosc)
            {
                source.PlayOneShot(bronsSound[idBroni], 1f);
                muzzle = true;
                if (Physics.SphereCast(ray, 1, out hit, 100,warstwa))
                {
                    if (hit.collider.tag == "Zombie")
                    {
                        hit.collider.GetComponent<Ai>().hp -= obrazenia;
                        Instantiate(blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        timer = 0;
                    }
                    else
                        timer = 0;
                }
                else
                    timer = 0;
            }
        }
	}
}
