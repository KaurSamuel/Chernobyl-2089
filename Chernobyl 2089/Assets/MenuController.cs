using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<GameObject> Selectpoints;
    private int CurPoint;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        CurPoint = 1;
        gameObject.transform.position = new Vector3(Selectpoints[CurPoint].transform.position.x, Selectpoints[CurPoint].transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurPoint != 2)
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
            if (CurPoint==1)
            {

            }
            else if (CurPoint == 0 )
            {
                Application.Quit();
                Debug.Log("Quit appliation");
            }
            else if (CurPoint == 2)
            {

            }
        }

    }
}
