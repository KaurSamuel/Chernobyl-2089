﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry_controller : MonoBehaviour
{
    public List<GameObject> Selectpoints;
    private int CurPoint;
    public PhysicsScene2D cene;
    // Start is called before the first frame update
    void Start()
    {
        CurPoint = 0;
        gameObject.transform.position = new Vector3(Selectpoints[CurPoint].transform.position.x, Selectpoints[CurPoint].transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurPoint != 1)
            {
                CurPoint += 1;
                gameObject.transform.position = new Vector3(Selectpoints[CurPoint].transform.position.x, Selectpoints[CurPoint].transform.position.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurPoint != 0)
            {
                CurPoint -= 1;
                gameObject.transform.position = new Vector3(Selectpoints[CurPoint].transform.position.x, Selectpoints[CurPoint].transform.position.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (CurPoint == 1)
            {
                SceneManager.LoadScene(0);
            }
            else if (CurPoint == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
