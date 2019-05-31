using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public string leveltoload;

    void Update()
    {
        if (Input.GetKey("return"))
        {
            SceneManager.LoadScene(leveltoload);
        }
    }
}
