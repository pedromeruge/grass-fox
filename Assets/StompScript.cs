using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompScript : MonoBehaviour
{
    [SerializeField][Range(0.6f, 1f)] private float k_StompThreshold = 0.8f; // quanto maior, mais vertical tem de ser o salto para contar como stomp
    void Start()
    {  
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
        Vector3 direction = (collision.collider.gameObject.transform.position - this.gameObject.transform.position).normalized; // vetor direcionado do centro do objeto que cai para o que � atingido, normalizado ( com norma 1)
        if (direction.y < -this.k_StompThreshold) res = true; // indica que objeto cai por cima do outro
        return res;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D hitObj = collision.collider;
        //if (hitObj.CompareTag("Player") || hitObj.CompareTag("Enemy")) Debug.Log(checkDirectionTop(collision));
        if (hitObj.CompareTag("Player") || hitObj.CompareTag("Enemy"))
        {
            bool IsCrouching = hitObj.gameObject.GetComponent<CharacterController2D>().IsCrouching();
            // o tag player é temporario, apenas para n dar erro nos enemies
            if (checkDirectionTop(collision) && !IsCrouching && hitObj.CompareTag("Player")) 
            { 
    // !!! Dar dano ao hitObj
                //Debug.Log(this.gameObject.name + " stomped: " + hitObj.name);
            }

        }
    }
}
