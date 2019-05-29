using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonPart : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float CurTimer = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1) * speed * Time.deltaTime;
        CurTimer -= Time.deltaTime;
        if (CurTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
