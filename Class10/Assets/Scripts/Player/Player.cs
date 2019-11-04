using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int health = 3;
    public event Action<Player> onPlayerDeath;
    public AudioClip deathSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void collidedWithEnemy(Enemy enemy)
	{
		enemy.Attack(this);
		if (health <= 0)
		{
            audioSource.PlayOneShot(deathSound);
            if (onPlayerDeath != null)
            {
                onPlayerDeath(this);
            }
		}
	}

	void OnCollisionEnter(Collision col)
	{
		Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy)
		{
			collidedWithEnemy(enemy);
		}
	}

}
