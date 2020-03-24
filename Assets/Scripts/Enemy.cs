using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject crosshair;
    public bool endOfAiming;
    public GameObject bulletPrefab;
    public int speed;
    public float bulletSpeed;
    public int velBalas = 2;

    private int HaciaArriba = 1;
    private int HaciaDerecha = 1;
    
    private int direction = 1;
    private bool Choque = false;
    public GameObject bloodParticle;

    public int TipoMovimiento; // 0 parado, 1 arriba-abajo, 2 izquierda-derecha

    void Start()
    {
        StartCoroutine(Esperar());
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(velBalas);
        Shoot();
        StartCoroutine(Esperar());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(enemy);
            Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (other.tag == "sierra")
        {
            Destroy(enemy);
            Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (other.tag == "bomba")
        {
            Destroy(enemy);
            Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (other.tag == "hielo")
        {
            TipoMovimiento = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Pared" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "changeScene")
        {
            Choque = true;
        }
    }

    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
        bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
        Destroy(bullet, 2.0f);
    }

    void Update()
    {
        if(TipoMovimiento == 1) // Arriba-Abajo
        {
            if (Choque)
            {
                if (HaciaArriba == 1)
                {
                    direction = -1;
                    HaciaArriba = 0;
                }
                else if (HaciaArriba == 0)
                {
                    direction = 1;
                    HaciaArriba = 1;
                }
                Choque = false;
            }

            transform.Translate(0, speed * direction * Time.deltaTime, 0);
        }
        else if(TipoMovimiento == 2) // Izquierda-Derecha
        {
            if (Choque)
            {
                if (HaciaDerecha == 1)
                {
                    direction = -1;
                    HaciaDerecha = 0;
                }
                else if (HaciaDerecha == 0)
                {
                    direction = 1;
                    HaciaDerecha = 1;
                }
                Choque = false;
            }

            transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        }

    }


}
