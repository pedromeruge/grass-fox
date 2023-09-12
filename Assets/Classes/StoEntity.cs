using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script temporary offensive Entity
//Script de objetos criados por armas, de caráter temporário
public class StoEntity : SEntity
{
    private void Awake()
    {
        this.tag = SEntityConsts.TAG_TEMPOFFENSIVE;
    }
}
