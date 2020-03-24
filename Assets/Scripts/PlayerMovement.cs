using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Atributos del personaje:")]
    public float speed;
    public float distanciaMira;
    public float bulletSpeed;

    [Space]
    [Header("Acciones del personaje:")]
    public Vector3 movement;
    public bool endOfAiming;
    public Rigidbody2D rb;

    [Space]
    [Header("Referencias:")]
    //public Weapon currentWeapon;
    public GameObject crosshair;

    [Space]
    [Header("Prefabs:")]
    public GameObject bulletPrefab;

    public int flag = 0;
    public int cont = 0;
    private Animator anim;
    private LevelManager lvlMng;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("ConPistola", false);
        lvlMng = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        ProcessInputs();
        Move();
        Aim();
        if(flag == 1)
        {
            Shoot();
        }
        if(Input.GetButtonDown("LB")){
			lvlMng.restart = true;
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            flag = 1;
            anim.SetBool("ConPistola", true);
        }
        else if(other.tag == "BulletEnemy" || other.tag == "Enemy")
        {
            if(cont == 2)
            {
                lvlMng.restart = true;
            }
            cont++;
        }
    }

    void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"));

        endOfAiming = Input.GetButtonUp("AButton");
    }

    void Move()
    {
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }

    void Aim()
    {
        if(movement != Vector3.zero)
        {
            crosshair.transform.localPosition = movement * distanciaMira;
        }
    }

    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        if (endOfAiming)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
            bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(bullet, 2.0f);
        }
    }

}
