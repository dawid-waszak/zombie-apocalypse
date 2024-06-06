using UnityEngine;
using System.Collections;

public class Celownik : MonoBehaviour {
    public GameObject celownik;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        celownik.transform.position = Input.mousePosition;
	}
}
