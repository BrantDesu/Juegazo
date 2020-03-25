using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRoom : MonoBehaviour
{
	public bool enabled = true;
	public float speed;
	//private robot1Controller robot;
	//private robotChController robotCh;
	public GameObject yShow;
	public GameObject yShowCh;

	public GameObject yImage;
	private Animator anim;

	void Start(){
		//robot = FindObjectOfType<robot1Controller>();
		//anim = GetComponent<Animator>();
		//robotCh = FindObjectOfType<robotChController>();
		//anim.SetBool("caminando", false);
	}

    // Update is called once per frame
    void FixedUpdate(){
    	if(enabled){
    		Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
    		Vector3 temp = transform.position;
    		transform.position = transform.position + movement * speed * Time.deltaTime;
    		//if(temp == transform.position){
    		//	anim.SetBool("caminando", false);
    		//}
    		//else{
    		//	anim.SetBool("caminando", true);
    		//}

    	}
    	//if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
           // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime, 0f, 0f));
        //}
    }

    void OnTriggerEnter2D(Collider2D other){
    	if (other.tag == "robot"){
    		Instantiate(yImage, yShow.transform.position, yShow.transform.rotation);
    	}
    	if (other.tag == "robotCh"){
    		Instantiate(yImage, yShowCh.transform.position, yShowCh.transform.rotation);
    	}
    }

    void OnTriggerStay2D(Collider2D other){
    	if ((other.tag == "robot") && (Input.GetButtonDown("YButton"))){
    		Debug.Log("presionando y");
    		//robot.enabled = true;
    		enabled = false;
    		anim.SetBool("caminando", false);
    	}
    	if ((other.tag == "robotCh") && (Input.GetButtonDown("YButton"))){
    		Debug.Log("presionando y");
    		//robotCh.enabled = true;
    		enabled = false;
    		anim.SetBool("caminando", false);
    	}
    }
}
