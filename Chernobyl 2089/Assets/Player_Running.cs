using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Running : MonoBehaviour
{
    private Vector3 normalizeDirection;
    public float speed = 5f;
    public List<GameObject> MovmentLines;

    private int CurLine;

    void Start()
    {
        //normalizeDirection = (target.position - transform.position).normalized;
        CurLine = 1;
    }

    void Update()
    {
        //transform.position += new Vector3(0,1) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurLine!=2)
            {
                CurLine += 1;
                gameObject.transform.position = new Vector3(MovmentLines[CurLine].transform.position.x, transform.position.y,-10);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurLine != 0)
            {
                CurLine -= 1;
                gameObject.transform.position = new Vector3(MovmentLines[CurLine].transform.position.x, transform.position.y,-10);
            }
        }
    }
}