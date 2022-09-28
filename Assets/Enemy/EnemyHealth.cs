using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 5;
    [Tooltip("Dodaje wartość do maxHitpoints kiedy przeciwnik umiera.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitpoints;
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
        currentHitpoints--;

        if(currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitpoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
