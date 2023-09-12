using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Ground Entity
// classe de terreno na cena de gameplay
public class SgEntity : SEntity
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.tag = SEntityConsts.TAG_GROUND;
    }
}
