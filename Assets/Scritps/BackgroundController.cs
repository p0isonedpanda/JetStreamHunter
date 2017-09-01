using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float moveDistance;
    Vector3 startPos, endPos;
    Vector3 refVelocity = Vector3.zero;
    bool movingUp = true;

	// Use this for initialization
	void Start ()
    {
        moveDistance = Random.Range(1.0f, 3.0f);
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y + moveDistance, transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Here we alternate between moving the set piece up and down smoothly
		if (movingUp)
            transform.position = Vector3.SmoothDamp(transform.position, endPos, ref refVelocity, 0.1f);
        else
            transform.position = Vector3.SmoothDamp(transform.position, startPos, ref refVelocity, 0.1f);

        Debug.Log(movingUp);

        if (transform.position == endPos * 1.1f)
            movingUp = false;
        else if (transform.position == startPos * 0.9f)
            movingUp = true;
    }
}
