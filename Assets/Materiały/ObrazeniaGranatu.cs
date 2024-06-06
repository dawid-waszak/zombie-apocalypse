using UnityEngine;
using System.Collections;

public class ObrazeniaGranatu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Zombie")
        {
            col.GetComponent<Ai>().hp -= 400;
            Destroy(gameObject);
        }
    }
}
