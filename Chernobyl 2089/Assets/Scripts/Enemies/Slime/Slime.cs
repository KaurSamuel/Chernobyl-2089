using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Slime()
    {
        MovmentsSpeed = 1f;
        AttackSpeed = 1f;
        Damage = 1f;
        Meele = true;
        HitPoints = 10f;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().GivenDamage);
        }
    }
}
