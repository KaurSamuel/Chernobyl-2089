using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -1f) * 1f * Time.deltaTime;
    }

}
