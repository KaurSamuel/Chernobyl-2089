using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public Pistol()
    {
        attackSpeed = 0.2f;
        magsize = 8;
        reloadtimer = 1f;
        automatic = false;
        Damage = 4f;
    }
}
