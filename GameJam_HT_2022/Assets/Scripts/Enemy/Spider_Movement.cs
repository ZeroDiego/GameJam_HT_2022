using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Movement : MonoBehaviour
{

    private JamSpawner spawner;

    public float moveSpeed = 1f;
    public float rotationSpeed = 4f;
    public float enemyDamage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponentInParent<JamSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestJam();
    }

    private void FindClosestJam()
    {
        float distanceToClosestJam = Mathf.Infinity;
        Jam closestJam = null;
        Jam[] allJams = GameObject.FindObjectsOfType<Jam>();

        if (allJams.Length != 0)
        {
            foreach (Jam currentJam in allJams)
            {
                float distanceToJam = (currentJam.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToJam < distanceToClosestJam)
                {
                    distanceToClosestJam = distanceToJam;
                    closestJam = currentJam;
                }
            }

            Vector2 direction = closestJam.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, closestJam.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerResource>().TakeDamage(enemyDamage);
        }
    }
}
