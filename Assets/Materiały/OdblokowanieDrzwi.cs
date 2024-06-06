using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OdblokowanieDrzwi : MonoBehaviour {
    bool enter;
    public Transform text;
    public int ilePieniedzy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enter == true)
        {
            text.GetComponent<Text>().text = "[E] Aby odblokować drzwi - " + ilePieniedzy + "$";
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<Hud>().punkty >= ilePieniedzy)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Hud>().punkty -= ilePieniedzy;
                    text.gameObject.active = false;
                    Destroy(gameObject);
                }
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            enter = true;
            text.gameObject.active = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
            text.gameObject.active = false;
        }
    }
}
