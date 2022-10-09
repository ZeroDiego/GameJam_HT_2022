using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1;
    }
}