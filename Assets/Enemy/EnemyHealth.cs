using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] [Range(0,20)] int maxHitPoints = 3;

    [Tooltip("Adds amount to Max Hit Points when the enemy dies.")]
    [SerializeField] int diffcultyRamp = 3;
    int currentHitPoints = 0;

    Enemy enemy;

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
        maxHitPoints += diffcultyRamp;
        gameObject.SetActive(false);
    }
}
