using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Running : MonoBehaviour
{
    private Vector3 normalizeDirection;
    public float speed = 5f;
    public float reload_timer;
    public List<GameObject> MovmentLines;
    public GameObject bulletpref;
    public Animator UiLoadedAnim;
    public Image Clipimage;
    public List<Sprite> clipsprites;
    public Animator Uiloaded;
    public Text ScoreText;
    public Animator Right;
    public Animator Left;
    public Animator Player;
    public Animator Fade;
    public AudioSource audio;
    public AudioClip deadclip;
    public AudioSource effects;
    public AudioClip oofclip;
    public AudioClip shootclip;
    public List<GameObject> retrythings;
    public List<GameObject> retrythings2;
    public GameObject UI;
    public Text Scoretext;


    private int CurLine;
    private float CurReload_timer;
    private int maxmahsize = 3;
    private int curmagsize;
    private int score;
    private bool notdead;
    private Collider2D collider;
    void Start()
    {
        //normalizeDirection = (target.position - transform.position).normalized;
        CurLine = 1;
        CurReload_timer = reload_timer;
        curmagsize = maxmahsize;
        Clipimage.sprite = clipsprites[curmagsize];
        Uiloaded.SetBool("empty", false);
        score = 1;
        notdead = true;
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(0,1) * speed * Time.deltaTime;
        if (CurReload_timer>0)
        {
            CurReload_timer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&& CurLine != 3)
        {
            
            CurLine += 1;
            gameObject.transform.position = new Vector3(MovmentLines[CurLine].transform.position.x, transform.position.y,-10);            
            Right.SetTrigger("smere");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)&& CurLine != 0)
        {
            
            CurLine -= 1;
            gameObject.transform.position = new Vector3(MovmentLines[CurLine].transform.position.x, transform.position.y,-10);
            Left.SetTrigger("smere");
        }
        if (Input.GetKeyDown(KeyCode.Space)&& CurReload_timer<=0&& curmagsize>=0&& notdead)
        {
            Quaternion rotation = Quaternion.identity;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y);
            Instantiate(bulletpref, pos, rotation);
            UiLoadedAnim.SetTrigger("Shooting");
            curmagsize -= 1;
            if (curmagsize < 0 )
            {
                Uiloaded.SetBool("empty", true);
            }
            if (curmagsize != -1 )
            {
                Clipimage.sprite = clipsprites[curmagsize];
            }
            CurReload_timer = reload_timer;
            effects.clip = shootclip;
            effects.Play();
        }
        if (curmagsize>-1)
        {
            Uiloaded.SetBool("empty", false);
        }
        if (curmagsize!= -1)
        {
            Clipimage.sprite = clipsprites[curmagsize];
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (curmagsize!=maxmahsize)
            {
                curmagsize += 1;
            }
        }
    }
    private void FixedUpdate()
    {
        if (notdead)
        {
            score += 1;
            ScoreText.text = score.ToString();
        }
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        notdead = false;
        collider.enabled = false;
        Player.SetTrigger("dead");
        Fade.SetBool("dead",true);
        effects.clip = oofclip;
        effects.Play();
        audio.Stop();
        audio.clip = deadclip;
        audio.Play();
        foreach (GameObject item in retrythings)
        {
            item.active = true;
        }
        foreach (GameObject item in retrythings2)
        {
            item.active = false;
        }
        Scoretext.text = "Score: " + score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Bullet")
        {
            curmagsize += 1;
            Destroy(collision.gameObject);
        }   
    }
}