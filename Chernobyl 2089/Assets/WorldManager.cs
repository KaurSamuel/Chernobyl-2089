using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public List<GameObject> Dungprefs = new List<GameObject>();
    public GameObject Player;
    public GameObject spawn;
    public float Timer;

    private float CurTimer;

    // Start is called before the first frame update
    void Start()
    {
        CurTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        CurTimer -= Time.deltaTime;
        if (CurTimer<= 0)
        {
            System.Random rnd = new System.Random();
            Quaternion rotation = Quaternion.identity;
            Instantiate(Dungprefs[rnd.Next(0,Dungprefs.Count)], spawn.transform.position, rotation);
            CurTimer = Timer;
        }

    }
}
