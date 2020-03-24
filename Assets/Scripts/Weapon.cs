using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject weapon;

    void Start()
    {
        //Instantiate(weapon, new Vector3(3, 0, 0), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(weapon);
        }
    }

}
