using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    public int jamValue;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream:GameJam_HT_2022/Assets/Scripts/Player/Jam.cs
        
=======
        spawner = GetComponentInParent<JamSpawner>();
>>>>>>> Stashed changes:GameJam_HT_2022/Assets/Scripts/Jam.cs
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
<<<<<<< Updated upstream:GameJam_HT_2022/Assets/Scripts/Player/Jam.cs
        gameObject.SetActive(false);
	}
=======
        spawner.DisableJam(gameObject);
	}


>>>>>>> Stashed changes:GameJam_HT_2022/Assets/Scripts/Jam.cs
}
