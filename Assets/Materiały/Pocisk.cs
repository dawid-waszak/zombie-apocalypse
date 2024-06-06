using UnityEngine;
using System.Collections;

public class Pocisk : MonoBehaviour {
    public int obrazenia;
    public float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * 1 / Time.deltaTime);
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Zombie")
        {
            col.GetComponent<Ai>().hp -= 10;
            Destroy(gameObject);
        }
    }
}
