using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunRotator : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public GameObject GunSprite;

    [HideInInspector]
    public float bulletSpeed = 10;
    public float curmagsize;
    [HideInInspector]
    private bool reloading = false;
    [HideInInspector]
    public float timer = 0f;

    public Gun[] inventory;
    public Gun currentlyequipped;
    private float cooldowntimer;
    private int currentlyequippedint;

    public Text AmmoUI;
    public Text GunUI;
    public Image ReloadUI;

    private void Start()
    {
        currentlyequipped = inventory[0];
        currentlyequippedint = 0;
        curmagsize = currentlyequipped.magsize;
    }

    void Update()
    {
        Debug.Log(transform.rotation.z);
        if (transform.rotation.z > 0.7f || transform.rotation.z < -0.7f)
        {
            GunSprite.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GunSprite.GetComponent<SpriteRenderer>().flipY = false;
        }
        AmmoUI.text = (curmagsize.ToString() + " / " + currentlyequipped.magsize.ToString());
        Aim();
        cooldowntimer += Time.deltaTime;
        if (cooldowntimer >= currentlyequipped.attackSpeed)
        {
            if (Input.GetMouseButton(0) && !reloading && curmagsize>0 && currentlyequipped.automatic)
            {
                Fire();
                curmagsize -= 1;
            }
            else if (!currentlyequipped.automatic && Input.GetMouseButtonDown(0)&& !reloading && curmagsize > 0)
            {
                Fire();
                curmagsize -= 1;
            }
            if (Input.GetMouseButton(1) || reloading) //Reloading
            {
                Reload();
            }
        }
        if (Input.mouseScrollDelta == new Vector2 (0, 1))
        {
            if (currentlyequippedint == inventory.Length - 1)
            {
                currentlyequippedint = 0;
            }
            else
            {
                currentlyequippedint += 1;
            }
            currentlyequipped = inventory[currentlyequippedint];
            curmagsize = 0;
            GunUI.text = currentlyequipped.name;
            timer = currentlyequipped.reloadtimer;
            Debug.Log("Weapon Change up");
        }
        else if (Input.mouseScrollDelta == new Vector2(0, -1))
        {
            if (currentlyequippedint == 0)
            {
                currentlyequippedint = inventory.Length - 1;
            }
            else
            {
                currentlyequippedint -= 1;
            }
            currentlyequipped = inventory[currentlyequippedint];
            curmagsize = 0;
            GunUI.text = currentlyequipped.name;
            timer = currentlyequipped.reloadtimer;
            Debug.Log("Weapon Change down");
        }
    }

    void Fire()
    {
        Rigidbody2D bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
        bPrefab.GetComponent<Bullet>().GivenDamage = currentlyequipped.Damage;
        bPrefab.tag = "Player Bullet";
        Debug.Log("Instantiated a bullet with damage value of: " + bPrefab.GetComponent<Bullet>().GivenDamage.ToString());

        bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
        cooldowntimer = 0;
    }

    void Reload()
    {
        reloading = true;
        timer -= Time.deltaTime;
        Debug.Log("Reloading. Timer : "+ currentlyequipped.reloadtimer.ToString());
        float reloadprecentage = (timer / currentlyequipped.reloadtimer);
        if (reloadprecentage<0)
        {
            reloadprecentage = 0;
        }

        ReloadUI.rectTransform.localScale = new Vector2(reloadprecentage, 1);

        if (timer<0)
        {
            reloading = false;
            curmagsize = currentlyequipped.magsize;
            timer = currentlyequipped.reloadtimer;
            ReloadUI.rectTransform.localScale = new Vector2(1, 1);
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
