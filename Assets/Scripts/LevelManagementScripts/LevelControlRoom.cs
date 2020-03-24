using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlRoom : MonoBehaviour
{
    public int actualLevelID;
    public string SceneToLoad;
    //public GameObject player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (actualLevelID >= 0)
            {
                Debug.Log("LevelID: " + actualLevelID);
                FindObjectOfType<LevelManagerStatic>().modifyLevelState(actualLevelID);
                Debug.Log(FindObjectOfType<LevelManagerStatic>().levelState(actualLevelID));
            }
            //player.SetActive(false);
            SceneManager.LoadScene(SceneToLoad);
        }
    }
    public void SceneLoader(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}

