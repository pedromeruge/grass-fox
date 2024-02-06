using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatEntity : SgEntity
{
    private void Awake()
    {
        this.tag = SEntityConsts.TAG_ONEWAYPLAT;
    }
}

