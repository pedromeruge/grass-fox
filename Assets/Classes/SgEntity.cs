using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SgEntity : SEntity
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.tag = SEntityConsts.TAG_GROUND;
    }
}
