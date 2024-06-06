using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform lookAt;

    bool smooth = true;
    float speed = 0.125f;
    Vector3 offset = new Vector3(0, 7f, -6f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 punkt = lookAt.transform.position + offset;
	if(smooth)
        {
            transform.position = Vector3.Lerp(transform.position, punkt, speed);
        }
    else
        {
            transform.position = punkt;
        }
	}
}
