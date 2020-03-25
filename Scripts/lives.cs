using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{

    public Sprite[] corazones;

    void Start(){
        
        CambioVida(3);

    }

    void Update(){
        
    }

    public void CambioVida(int pos){
        
        this.GetComponent<Image>().sprite = corazones [pos];

    }

}
