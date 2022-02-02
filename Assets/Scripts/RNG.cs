using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class RNG : MonoBehaviour
{
    public Random rng = new Random((int)DateTime.Now.Ticks);

    private GameObject[] pickups;

    private Shoot script;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        pickups = GameObject.FindGameObjectsWithTag("PickUp");

    }

    // Update is called once per frame
    void Update()
    {
        //rng = new Random((int) DateTime.Now.Ticks);
        timer += Time.deltaTime;
        if (timer >= 8f)
        {
            spawnProjectiles();
            timer = 0f;
        }

    }

    void spawnProjectiles()
    {
        foreach (GameObject pickup in pickups)
        {
            script = pickup.GetComponent<Shoot>();
            if (rng.Next(0, 10) > script.difficulty)
            {
                script.shoot();
            }
        }
    }
}
