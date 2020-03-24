using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCompleted : MonoBehaviour
{
    public int option;
    bool show;
    public GameObject completedImage;
    void Start()
    {
        show = FindObjectOfType<LevelManagerStatic>().levelState(option);
        if (show)
        {
            completedImage.SetActive(true);
        }
        else
        {
            completedImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
