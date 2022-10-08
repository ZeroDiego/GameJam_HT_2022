using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
	[SerializeField] private GameObject gameOverUI;

	public void GameOver()
	{
		gameOverUI.SetActive(true);
		Time.timeScale = 0;
	}

	public void Restart()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
