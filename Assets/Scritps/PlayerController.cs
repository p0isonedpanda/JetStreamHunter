using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    [Header("Movement")]
    public float moveForce;
    public ParticleSystem waterJet;

    [Header("Water")]
    public float maxWater;
    public float waterConsumptionRate;
    public Slider waterMeter;

    float water;

    Rigidbody2D rb;

    // Awake is run before Start(), which we can use to check that this is the only instance in the scene
    private void Awake()
    {
        if (instance != null) // Check if instance exists already
            throw new System.Exception();

        instance = this; // Initialise singleton
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        water = maxWater;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Since this game will be built for desktop, we will simulate mobile input by using the mouse
		if (Input.GetKey(KeyCode.Mouse0) && water > 0)
        {
            // Set rotation of water jet
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -10.0f;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(waterJet.gameObject.transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            waterJet.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Applies force to the player and consumes water
            rb.AddForce(-waterJet.gameObject.transform.TransformDirection(Vector2.right) * moveForce);
            water = Mathf.Clamp(water - waterConsumptionRate * Time.fixedDeltaTime, 0.0f, maxWater);
            waterMeter.value = water / maxWater;

            waterJet.Play();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) || water == 0.0f)
        {
            waterJet.Stop();
        }
	}

    public void AddWater (float waterAdded)
    {
        water = Mathf.Clamp(water + waterAdded, 0.0f, maxWater);
        waterMeter.value = water / maxWater;
    }
}
