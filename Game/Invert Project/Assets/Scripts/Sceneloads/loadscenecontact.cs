using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscenecontact : MonoBehaviour
{
    public string levelToLoad;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
