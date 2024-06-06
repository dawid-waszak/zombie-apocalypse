using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
    public string jakiBonus = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (jakiBonus == "Życie")
            {
                col.GetComponent<Hud>().hp = 100;
                Destroy(gameObject);
            }
            if (col.GetComponent<Hud>().bonus == false)
            {
                col.GetComponent<Hud>().bonus = true;
                if (jakiBonus != "Życie")
                    col.GetComponent<Hud>().czasBonusu = 20;
                col.GetComponent<Hud>().jakiBonus = jakiBonus;
                Destroy(gameObject);
            }
        }
    }

}
