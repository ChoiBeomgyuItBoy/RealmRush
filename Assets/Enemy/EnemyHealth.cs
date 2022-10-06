using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] [Range(0,20)] int maxHitPoints = 3;

    Enemy enemy;

    int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        
        if(currentHitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        enemy.RewardGold();
        gameObject.SetActive(false);
    }
}
