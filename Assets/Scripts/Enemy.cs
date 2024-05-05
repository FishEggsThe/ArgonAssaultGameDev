using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;

    int pointsWorth = 100;
    int enemyHP = 2;

    Scoreboard scoreboard;
    GameObject parent;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        enemyHP--;
    }

    void KillEnemy()
    {
        if (enemyHP <= 0) {
            scoreboard.IncreaseScore(pointsWorth);
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent.transform;
            Destroy(gameObject);
        }
    }
}
