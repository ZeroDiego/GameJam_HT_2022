using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private UI_Time timerObject;
	[SerializeField] private UI_ScoreText scoreTextObject;

	public void GameOver()
	{
		gameOverUI.SetActive(true);
		int time = Mathf.FloorToInt(timerObject.timer);
		PlayerPrefs.SetInt("Score", time);
		scoreTextObject.SetText();
		Time.timeScale = 0;
	}

	public void Restart()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
