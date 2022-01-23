using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusElevator : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    private float yMax = -.1f;
    private float yMin = -15.5f;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        float yNew = transform.position.y + direction * speed * Time.deltaTime;
        if (yNew >= yMax)
        {
            yNew = yMax;
            direction *= -1;
        }
        else if (yNew <= yMin)
        {
            yNew = yMin;
            direction *= -1;
        }
        transform.position = new Vector3(-6.41f, yNew, 4f);
    }
}
