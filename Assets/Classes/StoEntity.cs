using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script temporary offensive Entity
//Script de objetos criados por armas, de car�ter tempor�rio
public class StoEntity : SEntity
{
    public bool isStuck = false;
    private void Awake()
    {
        this.tag = SEntityConsts.TAG_TEMPOFFENSIVE;
    }
}
