using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target = default;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip enemyAttackSound = default;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
        GetComponent<AudioSource>().PlayOneShot(enemyAttackSound);
    }

}
