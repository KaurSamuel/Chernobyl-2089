using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovmentsSpeed;
    public float AttackSpeed;
    public float Damage;
    public float HitPoints;
    public bool Meele;   
    /// <summary>
    /// Enemy takes given damage
    /// </summary>
    /// <param name="DamageDone">Given damage</param>
    public void TakeDamage(float DamageDone)
    {
        HitPoints -= DamageDone;
        Debug.Log("Ememy took " + DamageDone.ToString()+ " damage and has "+ HitPoints.ToString()+" HP remaining");
        if (HitPoints <= 0)
        {
            Destroy(gameObject); //Todo: Add some animation and disable collisions, make it not seem like it disapears
        }
    }

    public void Attack(GameObject Player)
    {

    }


}
