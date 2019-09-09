using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

	public float speed;

    // Update is called once per frame
    void Update()
    {
    	Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
    	//animaciones
    	transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
