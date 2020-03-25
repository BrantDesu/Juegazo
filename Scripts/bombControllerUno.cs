using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombControllerUno: MonoBehaviour
{

	public GameObject zona;
    // Start is called before the first frame update
    void Start()
    {	
    	zona.SetActive(false);
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
        zona.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
