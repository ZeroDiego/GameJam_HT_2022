using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResource : MonoBehaviour
{
    public float jam = 100;
	private float maxJam;
	[SerializeField] private float jamReducer = 0.10f;
	[SerializeField] private float jamAdditive = 0.05f;
	[SerializeField] private float jamReducerLimit = 0.5f;
	[SerializeField] private float invisTime = 1.5f;
    [SerializeField] private ParticleSystem takeDamageParticles;
	[SerializeField] private AudioClip jamPickup;
	private AudioSource audioSource;
    public float hitPoints = 100f;
	private GameOverUI gameOverUI;
	private float timer = 1;

	private static PlayerResource instance;
	public static PlayerResource Instance { get { return instance; } set { instance = value; } }

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		maxJam = jam;
		gameOverUI = FindObjectOfType<GameOverUI>();
		InvokeRepeating(nameof(ReduceMoreJam), 0, 8f);
		audioSource = GetComponent<AudioSource>();
	}

	private void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (jam <= 0)
		{
			TakeDamage(jamReducer);
		}
		else
		{
			jam -= jamReducer;
		}
	}

	public void EatJam(int jamValue)
	{
		jam += jamValue;
		if (jam > maxJam)
		{
			jam = maxJam;
			audioSource.PlayOneShot(jamPickup);
		}
	}

	public void TakeDamage(float damage)
	{
		if (timer > invisTime || damage < 1)
		{
			timer = 0;
            takeDamageParticles.Play();
            hitPoints -= damage;
			if (hitPoints <= 0)
			{
				gameOverUI.GameOver();
			}
		}
	}



	private void ReduceMoreJam()
	{
		jamReducer += jamAdditive;
		if (jamReducer >= jamReducerLimit)
		{
			CancelInvoke();
		}
	}
}
