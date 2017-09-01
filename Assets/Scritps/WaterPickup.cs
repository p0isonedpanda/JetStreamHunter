using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour
{
    PlayerController pc;

    public float waterGiven;
    public GameObject splash;

	// Use this for initialization
	void Start ()
    {
        pc = PlayerController.instance;
	}

    // Called when the player collides with the pickup
    private void OnTriggerEnter2D (Collider2D col)
    {
        pc.AddWater(waterGiven);
        Instantiate(splash, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
