using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}