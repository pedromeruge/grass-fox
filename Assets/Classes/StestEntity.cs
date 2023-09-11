using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StestEntity : SEntity
{
    Transform m_PlayerPos; // posi��o atual do jogador (guardado no gameObject ICollisions)

    private void Awake()
    {
        this.tag = SEntityConsts.TAG_TESTENEMY;

        if (m_PlayerPos == null)
        {
            m_PlayerPos = this.transform.Find("ICollisions").transform;
        }
    }

    //D� a posi��o atual do jogador
    public Transform getCurrPlayerPos()
    {
        return this.m_PlayerPos;
    }


    public Rigidbody2D getPlayerRb()
    {
        Rigidbody2D rb = this.transform.Find("ICollisions").GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rb n�o encontrado");
        return rb;
    }
}
