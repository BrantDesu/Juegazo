using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAlertIcon : MonoBehaviour
{
    public GameObject yImage;
    public GameObject yPosNPC;
    public GameObject eventSystem;
    public Dialogue dialogue;
    public Menu menu;
    public bool isDialogue;
    public bool isMenu;
    private bool collision;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void TriggerMenu(){
        FindObjectOfType<MenuManager>().StartMenu(menu);
    }
    public void CloseMenu(){
        FindObjectOfType<MenuManager>().CloseMenu(menu);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            collision = true;
            Vector3 pos = yPosNPC.transform.position;
            yImage.transform.position = pos;
            yImage.GetComponent<Renderer>().enabled = true;
        }
    }

    private void Update() {
        if (collision && isDialogue)
        {
            if ((Input.GetButtonDown("YButton")))
            {
                yImage.GetComponent<Renderer>().enabled = false;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else if ((Input.GetButtonDown("AButton")))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            else if (FindObjectOfType<DialogueManager>().dialogueEnded)
            {
                yImage.GetComponent<Renderer>().enabled = true;
            }
            else if (Input.GetButtonDown("XButton"))
            {
                for (int i = 0; i < 4; i++)
                {
                    Debug.Log(FindObjectOfType<LevelManagerStatic>().levelState(i));
                }
            }
        }
        else if (collision && isMenu)
        {
            if ((Input.GetButtonDown("YButton")))
            {
                yImage.GetComponent<Renderer>().enabled = false;
                eventSystem.SetActive(true);
                FindObjectOfType<MenuManager>().StartMenu(menu);
            }
            if ((Input.GetButtonDown("BButton")))
            {
                yImage.GetComponent<Renderer>().enabled = true;
                eventSystem.SetActive(false);
                FindObjectOfType<MenuManager>().CloseMenu(menu);
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            collision = false;
            yImage.GetComponent<Renderer>().enabled = false;
        }
    }
}
