using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int PlayerOEnemy;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerOEnemy == 1)
        {
            if (other.tag == "Pared" || other.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
        else if(PlayerOEnemy == 0)
        {
            if (other.tag == "Pared" || other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        
    }
}
