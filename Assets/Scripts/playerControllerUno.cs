using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerUno : MonoBehaviour
{
	public bool enabled = true;
	private float speed = 5.0f;
	private robot1Controller robot;
	private robotChController robotCh;
    private robotFreezeController robotFr;
	private LevelManager levelMan;
	public GameObject yShow;
	public GameObject yShowCh;
    public GameObject yShowFr;
	public GameObject yImage;
	private Animator anim;
	public int hp;

	void Start(){
		robot = FindObjectOfType<robot1Controller>();
		anim = GetComponent<Animator>();
		robotCh = FindObjectOfType<robotChController>();
        robotFr = FindObjectOfType<robotFreezeController>();
		levelMan = FindObjectOfType<LevelManager>();
		anim.SetBool("caminando", false);
	}

    // Update is called once per frame
    void Update(){
    	if(enabled){
    		Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
    		Vector3 temp = transform.position;
    		transform.position = transform.position + movement * speed * Time.deltaTime;
    		if(temp == transform.position){
    			anim.SetBool("caminando", false);
    		}
    		else{
    			anim.SetBool("caminando", true);
    		}

    	}
		if(Input.GetButtonDown("LB")){
			levelMan.restart = true;
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
        if (other.tag == "robotFr"){
            Instantiate(yImage, yShowFr.transform.position, yShowFr.transform.rotation);
        }
		if (other.tag == "BulletEnemy"){
            hp--;
			if(hp==0){
				Destroy(gameObject);
				levelMan.restart = true;
			}
        }
    }

    void OnTriggerStay2D(Collider2D other){
    	if ((other.tag == "robot") && (Input.GetButtonDown("YButton"))){
    		Debug.Log("presionando y");
    		robot.enabled = true;
			StartCoroutine(Example());
    		enabled = false;
    		anim.SetBool("caminando", false);
    	}
    	if ((other.tag == "robotCh") && (Input.GetButtonDown("YButton"))){
    		Debug.Log("presionando y");
    		robotCh.enabled = true;
			StartCoroutine(ExampleCh());
    		enabled = false;
    		anim.SetBool("caminando", false);
    	}
        if ((other.tag == "robotFr") && (Input.GetButtonDown("YButton"))){
            Debug.Log("presionando y");
            robotFr.enabled = true;
			StartCoroutine(ExampleFr());
            enabled = false;
            anim.SetBool("caminando", false);
        }
    }

	IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        robot.enabled = false;
		enabled = true;
    }
	
	IEnumerator ExampleCh()
    {
        yield return new WaitForSeconds(5);
        robotCh.enabled = false;
		enabled = true;
    }

	IEnumerator ExampleFr()
    {
        yield return new WaitForSeconds(5);
        robotFr.enabled = false;
		enabled = true;
    }
}
