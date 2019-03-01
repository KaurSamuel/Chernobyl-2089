using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualUzi : Gun
{
    public DualUzi()
    {
        attackSpeed = 0.1f;
        magsize = 64;
        reloadtimer = 3f;
        automatic = true;
        Damage = 1f;
    }
}
