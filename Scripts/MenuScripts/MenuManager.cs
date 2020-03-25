using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI[] optionsText;
    public Animator animator;


    public void StartMenu(Menu menu)
    {
        
        animator.SetBool("isOpen", true);
        FindObjectOfType<PlayerControllerRoom>().enabled = false;
        nameText.text = menu.name;



        for (int i = 0; i < (menu.options).Length; i++)
        {
            optionsText[i].text = (menu.options)[i];
        }

    }
    public void CloseMenu(Menu menu)
    {
        animator.SetBool("isOpen", false);
        FindObjectOfType<PlayerControllerRoom>().enabled = true;
    }
}
