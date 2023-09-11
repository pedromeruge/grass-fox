using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// classe em TO DO - como é que organizo esta shit ;_;;;
public class SpEntity : SEntity
{
    [SerializeField] IKitInfo playerKitInfo;

    private void Awake()
    {
        this.tag = SEntityConsts.TAG_PLAYER;
    }

    //Dá a posição atual do jogador
    public Transform getCurrPlayerPos()
    {
        return this.transform.Find("ICollisions").transform;
    }


    public Rigidbody2D getPlayerRb()
    {
        Rigidbody2D rb = this.transform.Find("ICollisions").GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rb não encontrado");
        return rb;
    }

}
