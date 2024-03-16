using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;

    private PlayerProgress playerProgress;
    public Animator animator;
    public Explosion explosionPrefab;

    public bool IsAlive()
    {
        return value > 0;
    }

    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {

            EnemyDeath();

        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        MobExplosion();
    }

    private void MobExplosion()
    {
        if (explosionPrefab == null) return;

        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }

    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

 
}
