using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
