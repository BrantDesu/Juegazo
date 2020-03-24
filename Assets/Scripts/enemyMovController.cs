using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovController : MonoBehaviour
{

	public int hp;
	public GameObject bloodParticle;

	public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
	private bool hittingWall;

	public float moveSpeed;
	public bool moveRight;
	public bool movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
        	Destroy(gameObject);
        }

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall){
    		moveRight = !moveRight;
    	}

    	if (moveRight){
        	transform.localScale = new Vector3(-1f,1f,1f);
        	GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!moveRight){
        	transform.localScale = new Vector3(1f,1f,1f);
        	GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
		if (!movement){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "sierra"){
    		hp--;
    		Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
    	}
    	if(other.tag == "bomba"){
    		hp=hp-3;
    		Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
    	}
		if(other.tag == "hielo"){
    		movement = false;
    	}
    }

    void OnTriggerStay2D(Collider2D other){
    	if(other.tag == "bomba"){
    		hp=hp-3;
    		Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
    	}
    }
}
