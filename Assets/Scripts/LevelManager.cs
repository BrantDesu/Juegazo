using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool restart = false;
    public string nivel;
    public string nivelActual;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                SceneManager.LoadScene(nivel); 
        }
    }
    
    void Update(){
        if(restart){
            SceneManager.LoadScene(nivelActual); 
        }
    }
}
