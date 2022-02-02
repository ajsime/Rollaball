using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;

    public  TextMeshProUGUI countText;

    public TextMeshProUGUI winText;

    public GameObject winTextGameObject;
    // Start is called before the first frame update
    void Start()
    {
        winTextGameObject.SetActive(false);
        updateHealth();
        //HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();
        if (HP <= 0)
        {
            winText.text = "You lose! :(";
            winTextGameObject.SetActive(true);
        }
    }

    void updateHealth()
    {
        countText.text = "Health: " + HP.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            HP--;
            Destroy(other.gameObject);
        }
    }
}
