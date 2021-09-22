using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerInput;
    private GameManager gameManager;
    public Text bestScoreName;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        WriteBestScore();
    }

    public void StartNew()
    {
        gameManager.newName = playerInput.text;
        Debug.Log(gameManager.newName);
        SceneManager.LoadScene(1);  
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void WriteBestScore()
    {
        bestScoreName.text = "Best Score : " + gameManager.highScoreName + " " + gameManager.highScore;
    }
}