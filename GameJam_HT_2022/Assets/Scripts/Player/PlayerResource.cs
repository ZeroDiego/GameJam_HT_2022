using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    public float jam = 100;
	[SerializeField] private float jamReducer = 0.10f;
	[SerializeField] private float jamAdditive = 0.05f;
	[SerializeField] private float jamReducerLimit = 0.4f;

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
		InvokeRepeating(nameof(ReduceMoreJam), 0, 5f);
	}

	private void FixedUpdate()
	{
		jam -= jamReducer;
	}

	public void EatJam(int jamValue)
	{
		jam += jamValue;
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
