using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinOnTrigger : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.name == "Player")
        {
            Debug.Log("Victory");
            SceneManager.LoadScene("levelcomplete", LoadSceneMode.Additive);
            //Application.LoadLevel("levelcomplete");
        }
    }
    

}
