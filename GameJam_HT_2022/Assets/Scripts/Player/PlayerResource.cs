using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    public float jam = 100;
	[SerializeField] private float jamReducer = 0.10f;
	[SerializeField] private float jamAdditive = 0.05f;
	[SerializeField] private float jamReducerLimit = 0.4f;

	private void Start()
	{
		InvokeRepeating(nameof(ReduceMoreJam), 0, 5f);
	}

	private void FixedUpdate()
	{
		jam -= jamReducer;
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
