using UnityEngine;
using System.Collections;

public class Wybuch : MonoBehaviour {
    public Transform eksplozja;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Terrain" || col.tag == "Zombie" || col.tag == "Drewno")
        {
            Instantiate(eksplozja, transform.position, eksplozja.rotation);
            Destroy(gameObject);
        }
    }
}
