using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompScript : MonoBehaviour
{
    [SerializeField][Range(0.6f, 1f)] private float k_StompThreshold = 0.8f; // quanto maior, mais vertical tem de ser o salto para contar como stomp
    [SerializeField] private int damage = 0;

    Transform m_playerPos; // saber orienta��o do player, para aplicar o dano
    void Start()
    {  
        SpEntity player = SEntity.getObjRoot<SpEntity>(this.gameObject);
        if (player == null) Debug.LogError("player root is null");
        this.m_playerPos = player.GetComponentInChildren<ICollisions>().transform; 
    }

    /*
    // 8 bits: xxxxabcd => a - top hit (8), b - bottom hit (4), c - left hit (2), d - right hit (1)
    // assume que colide com o objeto pretendido
    //n funciona direito
    private Byte checkDirection(Collision2D collision)
    {
        Byte res = 0x00;
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 hitObjCenterPoint = collision.collider.bounds.center;
        res = (byte) (contactPoint.y > hitObjCenterPoint.y ? (res | 0x08) : (res | 0x04));
        res = (byte)(contactPoint.x > hitObjCenterPoint.x ? (res | 0x01) : (res | 0x02));
        return res;
    }
    */ 

    //devolve se o player que entra em contacto aparece por cima do outro
    private bool checkDirectionTop(Collision2D collision)
    {
        bool res = false;
        Vector3 direction = (collision.collider.gameObject.transform.position - this.m_playerPos.position).normalized; // vetor direcionado do centro do objeto que cai para o que � atingido, normalizado ( com norma 1)
        if (direction.y < -this.k_StompThreshold) res = true; // indica que objeto cai por cima do outro
        return res;
    }

    //NOTA: Isto não está a funcionar porque o rigidbody passou para a zona do ICollisons
    // Como fazer para passar esta responsabilidade de stomp para lá de forma limpa???
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // //////////VER NOTA ACIMA
        Collider2D hitObj = collision.collider;
        SEntity entity = SEntity.getObjRoot<SEntity>(hitObj.gameObject);

        Debug.Log(this.gameObject.name + " stomped: " + entity.name);
        if (entity is SpEntity) {
            bool IsCrouching = false; // entity.GetComponentInChildren<CharacterController2D>().IsCrouching();
            if (checkDirectionTop(collision) && !IsCrouching) 
            { 
                entity.GetComponentInChildren<Stats>().damage(this.damage);
            }

        }
    }
}
