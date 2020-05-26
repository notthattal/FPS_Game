using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitpoints = hitpoints - damage;
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
