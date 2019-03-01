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

    public void TakeDamage(float Damage)
    {
        HitPoints -= Damage;
        Debug.Log("Ememy took " + Damage.ToString()+ " damage and has "+ HitPoints.ToString()+" HP remaining");
        if (HitPoints <= 0)
        {
            Destroy(gameObject); //Todo: Add some animation and disable collisions make it not seem like it disapears
        }
    }




}
