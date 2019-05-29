using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Lifetime = 1f;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 1) * 10f * Time.deltaTime;
        Lifetime -= Time.deltaTime;
        if (Lifetime<0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Fragile")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
   
}

