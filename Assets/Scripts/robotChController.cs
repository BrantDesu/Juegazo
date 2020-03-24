using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotChController : MonoBehaviour
{
	public float speed;
	public bool enabled = false;
	private playerControllerUno player;
	private Animator anim;
	private bool vertical = true;
	public GameObject bomb;
	public GameObject showY;
	private Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerControllerUno>();
        anim = GetComponent<Animator>();
		posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    	if(enabled){
			
    		Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
    		if((Input.GetAxis("MoveHorizontal")!=0)&&vertical){
    			transform.Rotate(0, 0, 90);
    			vertical = false;
    		}
    		if((Input.GetAxis("MoveVertical")!=0)&&!vertical){
    			transform.Rotate(0, 0, 90);
    			vertical = true;
    		}
    		Vector3 temp = transform.position;
    		transform.position = transform.position + movement * speed * Time.deltaTime;
    		if(temp == transform.position){
    			anim.SetBool("controlando", false);
    		}
    		else{
    			anim.SetBool("controlando", true);
    		}
    		if(Input.GetButtonDown("BButton")){
    			player.enabled = true;
    			enabled = false;
    		}
    		if(Input.GetButtonDown("XButton")){
    			Instantiate(bomb, showY.transform.position, showY.transform.rotation);
    		}
    	}
		if(!enabled){
			//transform.position = posInicial;
		}
    }

}
