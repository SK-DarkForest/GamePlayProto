using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Enter_PlayMode ()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Close_Game ()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }

    public void Return_ToMenu ()
    {
        SceneManager.LoadScene("StartUpMenu");
    }

    public void Load_CharacterMenu ()
    {
        SceneManager.LoadScene("1");
    }
}
