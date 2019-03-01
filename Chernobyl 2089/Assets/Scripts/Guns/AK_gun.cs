using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_gun : Gun
{
     public AK_gun()
     {
        attackSpeed = 0.2f;
        magsize = 24;
        reloadtimer = 2f;
        automatic = true;
        Damage = 2f;
     }

}
