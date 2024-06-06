using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
    public Transform dach;
    public float alpha;
    public bool jestWBudynku;
    Material mat;
    Color color;
    // Use this for initialization
    void Start () {
	mat = dach.GetComponent<Renderer>().material;
    color = mat.color;
    }

    // Update is called once per frame
    public float timer;
	void Update () {
        timer += Time.deltaTime;
        mat.color = new Color(color.r, color.g, color.b, alpha);
        if (jestWBudynku == true)
        {
            if(timer > 0.1 && alpha > 0.3)
            {
                alpha -= 0.1f;
                timer = 0;
            }
        }
    else
        {
            if (timer > 0.1 && alpha < 1)
            {
                alpha += 0.1f;
                timer = 0;
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            jestWBudynku = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            jestWBudynku = false;
        }
    }
}
