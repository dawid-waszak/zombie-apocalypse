using UnityEngine;
using System.Collections;

public class Znikanie : MonoBehaviour {
    public float czas;
    float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > czas)
            Destroy(gameObject);
	}
}
