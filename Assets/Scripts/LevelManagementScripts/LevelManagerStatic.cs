using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerStatic : MonoBehaviour
{
    static bool[] niveles = new bool[] {false, false, false, false};
    void Start()
    {
        
    }

    public bool levelState(int i){
        return niveles[i];
    }
    public void modifyLevelState(int i){
        niveles[i] = true;
    }
}
