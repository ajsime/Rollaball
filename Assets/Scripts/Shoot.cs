using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public float speed = 5.0f;
    private bool active = false;
    private GameObject bullet;
    private Vector3 playerPosition;
    private Vector3 lastKnownPosition;
    private float timer = 0;
    private float projectileActiveTime = 0f;
    private int randNum;
    public int difficulty = 8;
    private int numPickups;
    private int maxPickups;
    private int lastNumPickups;
    private Random random = new Random();


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player = GameObject.FindWithTag("MainCamera");
        numPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
        maxPickups = numPickups;
        lastNumPickups = numPickups;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        playerPosition = player.transform.position;
        updateNumObjects();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !active)
        {
            shoot();
        }

        if (timer >= 7f && !active)
        {
            shoot();
            timer = 0f;
        }
        if (active)
        {
            bullet.transform.position += bullet.transform.forward * speed * Time.deltaTime;
            projectileActiveTime += Time.deltaTime;
            if (projectileActiveTime >= 7f)
            {
                projectileActiveTime = 0f;
                active = false;
                Destroy(bullet);

            }

        }

    }

    void shoot()
    {
        randNum = random.Next(0, 10);
        
        if (randNum > difficulty)
        {
            timer = 0f;
            return;
        }
        bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        lastKnownPosition = playerPosition;
        bullet.transform.LookAt(lastKnownPosition);
        //bullet.transform.rotation = Quaternion.LookRotation(playerPosition);
        active = true;
        timer = 0f;
    }

    void adjustDifficulty()
    {

        if (numPickups < Math.Round(maxPickups * 0.75) && difficulty == 8)
        {
            difficulty = 7;
        }
        else if (numPickups < Math.Round(maxPickups * 0.5) && difficulty == 7)
        {
            difficulty = 5;
            speed = 5.5f;
        }
        else if (numPickups == 3)
        {
            difficulty = 3;
            speed = 6.0f;
        }
        else if (numPickups < 3)
        {
            difficulty = 1;
            speed = 9.0f;
        }
        Debug.Log("Difficulty Level: " + difficulty);
        
    }

    void updateNumObjects()
    {
        GameObject[] pickupGameObjects = GameObject.FindGameObjectsWithTag("PickUp");
        int activeObjects = 0;
        foreach (GameObject pickup in pickupGameObjects)
        {
            if (pickup.activeSelf)
            {
                activeObjects++;
            }
        }

        if (activeObjects < numPickups)
        {
            numPickups = activeObjects;
            adjustDifficulty();
        }

        return;
    }

}
