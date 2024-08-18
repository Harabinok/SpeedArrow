using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _loadScene;

    public void LoadSceneNumber()
    {
        SceneManager.LoadScene(_loadScene);
    }

    public void RestartScene()
    {
        int indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexCurrentScene);
    }
}
