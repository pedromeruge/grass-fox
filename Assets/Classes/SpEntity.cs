using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

//Script Player Entity
// classe de player na cena de gameplay
public class SpEntity : SEntity
{
    [SerializeField] IKitInfo playerKitInfo;

    private void Awake()
    {
        this.tag = SEntityConsts.TAG_PLAYER;
    }

    //D� a posi��o atual do jogador
    public Transform getCurrPos()
    {
        return this.GetComponentInChildren<ICollisions>().transform;
    }


    public Rigidbody2D getRb()
    {
        Rigidbody2D rb = this.transform.Find("ICollisions").GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rb não encontrado");
        return rb;
    }
}
