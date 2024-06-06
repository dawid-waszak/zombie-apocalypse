using UnityEngine;
using System.Collections;

public class Poruszanie : MonoBehaviour {
    Rigidbody rigidbody;
    public float speed;
    Vector3 lookPos;
    Vector3 moveInput;
    Vector3 moveVelocity;
    public bool sprint;
    public float timer;
    public AudioSource source;
    public AudioClip foot1;
    public AudioClip foot2;
    public AudioClip foot3;
    public bool walking;
    public float stamina;
    Vector3 poz = new Vector3(0.1f, 0, 0.1f);
    public Transform postac;
    int warstwa = ~(1 << 9 | 1 << 8);
    public bool poruszanie;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (poruszanie == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + poz);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, warstwa))
            {
                lookPos = hit.point;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (transform.GetComponent<Hud>().stamina > 0)
                {
                    sprint = true;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprint = false;
            }

            if (sprint == true && transform.GetComponent<Hud>().stamina > 0)
            {
                postac.GetComponent<Animator>().speed = 2;
                if (transform.GetComponent<Hud>().ogluszenie == false)
                    speed = 7;
                else
                    speed = 1;
                stamina += Time.deltaTime;
                if (stamina > 0.1 && transform.GetComponent<Hud>().jakiBonus != "Stamina")
                {
                    transform.GetComponent<Hud>().stamina -= 4;
                    stamina = 0;
                }
            }
            else
            {
                postac.GetComponent<Animator>().speed = 1f;
                stamina += Time.deltaTime;
                if (stamina > 0.5 && transform.GetComponent<Hud>().stamina < 100)
                {
                    transform.GetComponent<Hud>().stamina += 1;
                    stamina = 0;
                }
                if (transform.GetComponent<Hud>().ogluszenie == false)
                    speed = 5;
                else
                    speed = 1;
            }
            if (Input.GetKey(KeyCode.W))
                walking = true;
            else if (Input.GetKey(KeyCode.S))
                walking = true;
            else if (Input.GetKey(KeyCode.A))
                walking = true;
            else if (Input.GetKey(KeyCode.D))
                walking = true;
            else
                walking = false;
            if ((walking == true || sprint == true))
            {
                Ray ray2 = new Ray(transform.position, Vector3.down);
                RaycastHit hit2;
                postac.GetComponent<Animator>().SetBool("Walk", true);
                float czas;
                AudioClip sound = foot2;
                timer += Time.deltaTime;
                if (Physics.Raycast(ray2, out hit))
                {
                    if (hit.collider.tag == "Terrain")
                        sound = foot1;
                    if (hit.collider.tag == "Drewno")
                        sound = foot2;
                }
                czas = foot1.length;

                if (timer > czas && sprint == false)
                {
                    source.PlayOneShot(sound, 0.5f);
                    timer = 0;
                }
                else if (timer > czas / 2 && sprint == true)
                {
                    source.PlayOneShot(sound, 0.5f);
                    timer = 0;
                }
            }
            else
            {
                postac.GetComponent<Animator>().SetBool("Walk", false);
            }
            Vector3 lookDir = lookPos - transform.position;
            lookDir.y = 0;

            transform.LookAt(transform.position + lookDir, Vector3.up);

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            moveVelocity = movement * speed;
        }
	}
    void FixedUpdate()
    {
        rigidbody.velocity = moveVelocity;
    }
}
