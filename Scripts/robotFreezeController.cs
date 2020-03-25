using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotFreezeController : MonoBehaviour
{

	public float speed;
	public bool enabled = false;
	private playerControllerUno player;
	private Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerControllerUno>();
		posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {	
        if(enabled){
    		Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
    		//animaciones
    		transform.position = transform.position + movement * speed * Time.deltaTime;
    		if(Input.GetButtonDown("BButton")){
    			player.enabled = true;
    			enabled = false;
    		}
    	}
		if(!enabled){
			//transform.position = posInicial;
		}
    }
}
