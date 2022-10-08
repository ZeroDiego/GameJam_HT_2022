using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    public int health = 3;
    private bool enemyDead = false;
    private float timer;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private Animator animator;

    private Collider2D coll2D;

    // Start is called before the first frame update
    void Start()
    {
        coll2D = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDead == true)
        {
            timer += Time.deltaTime;
            if(timer >= 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spit") == true)
        {
        
            EnemyTakeDamage();
            
        }
    }

    private void EnemyTakeDamage()
    {
        health -= 1;

        if(health <= 0)
        {
            enemySpriteRenderer.enabled = false;
            animator.enabled = false;
            deathParticles.Play();
            audioSource.PlayOneShot(deathClip);
            coll2D.enabled = false;

            if (gameObject.tag == "Spider")
            {
                gameObject.GetComponent<Spider_Movement>().enabled = false;
            }
            else if(gameObject.tag == "Bee")
            {
                gameObject.GetComponent<Bee_Movement>().enabled = false;

            }

            enemyDead = true;
            
        }
    }
    
}
