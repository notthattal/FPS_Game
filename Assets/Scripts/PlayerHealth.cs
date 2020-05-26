using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0f)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
}
