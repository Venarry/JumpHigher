using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private string _currentScene;

    public void RestartScene()
    {
        _currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentScene);
    }
}
