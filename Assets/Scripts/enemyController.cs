using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

	public int hp;
	public GameObject bloodParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
        	Destroy(gameObject);
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
    }

    void OnTriggerStay2D(Collider2D other){
    	if(other.tag == "bomba"){
    		hp=hp-3;
    		Instantiate(bloodParticle, gameObject.transform.position, gameObject.transform.rotation);
    	}
    }
}
