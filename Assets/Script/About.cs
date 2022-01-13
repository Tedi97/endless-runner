using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    public GameObject AboutGame;

    void Start()
    {

    }

    void Update() 
    {

    }

    public void tentang()
    {
        AboutGame.SetActive(true);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
