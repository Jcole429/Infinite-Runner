using UnityEngine;
using System.Collections;

public class powerUpMovement : MonoBehaviour {

    Vector3 bottom;
    Vector3 top;

    bool movingUp = false;
    bool movingDown = true;

	// Use this for initialization
	void Start () {
        bottom = new Vector3(transform.position.x, 0.3f, transform.position.z);
        top = new Vector3(transform.position.x, 1f, transform.position.z);
    }

    // Update is called once per frame
    void Update(){
        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottom, (.9f) * Time.deltaTime);
            if (transform.position.y == .3f)
            { movingDown = false; movingUp = true; }
        }
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, top, (.9f) * Time.deltaTime);
            if (transform.position.y == 1f)
            { movingDown = true; movingUp = false; }
        }
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
