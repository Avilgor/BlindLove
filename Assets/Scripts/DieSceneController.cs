using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieSceneController : MonoBehaviour
{
    public GameObject cosas;
    
    public void nextBtn()
    {
        cosas.SetActive(true);
    }

    public void returnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
