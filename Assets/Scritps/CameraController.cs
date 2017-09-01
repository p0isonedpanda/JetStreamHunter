using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController pc;
    GameObject player;
    Vector3 currentVelocity = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        pc = PlayerController.instance;
        player = pc.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Smoothly follow the player
        transform.position = Vector3
            .SmoothDamp(transform.position,
            new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10.0f),
            ref currentVelocity, 0.25f);
	}
}
