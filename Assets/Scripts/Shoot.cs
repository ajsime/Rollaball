using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    private bool active = false;
    private GameObject bullet;
    private float xdirection;
    private float zdirection;
    private float timer;
   

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }
        if (active)
        {
            bullet.transform.position = new Vector3(7.5f, 0.5f, Random.Range(0f, 10.5f));
        }

    }

    void shoot()
    {
        bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        active = true;
    }
}
