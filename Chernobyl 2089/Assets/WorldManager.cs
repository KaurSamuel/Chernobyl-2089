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
            GameObject _dungeonpart = new GameObject();
            _dungeonpart = Dungprefs[0];
            Instantiate(_dungeonpart);
            _dungeonpart.transform.position = spawn.transform.position;
            CurTimer = Timer;
        }
    }
}
