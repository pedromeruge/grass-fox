using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeAtackScript : MonoBehaviour
{
    [SerializeField] [Range (0.1f,1f)] private float k_AttackRadius = .2f;
    [SerializeField] private Vector2 k_attackForce = Vector2.zero; // for�a exercida sobre inimigos quando atacados
    [SerializeField] private Transform m_AttackPos; // pos. central do ataque
    [SerializeField] private LayerMask m_WhatIsHittable; // layers com que o ataque pode interagir

    Animator animator; // n�o usado
    Transform m_playerPos; // saber orienta��o do player, para aplicar o dano

    void Start()
    {
        animator = this.GetComponent<Animator>();
        this.m_playerPos = SEntity.getPlayerObjWithName(SEntity.getTaggedRoot(this.gameObject, SEntityConsts.TAG_PLAYER), "ICollisions").transform; // sem null checks, lazy
    }
    
    // Afeta todos os players em contacto com a �rea de ataque do player (�rea circular)
    // D� dano e exer�e for�as contrarias
    public void Attack()
    {
        //melhor usar OverlapBox ??? overlapBox tem formato de output em array??
        Collider2D[] hitObjsColl = Physics2D.OverlapCircleAll(this.m_AttackPos.position, this.k_AttackRadius, this.m_WhatIsHittable);

        //Debug.DrawLine(this.m_AttackPos.position - (Vector3.right * this.k_AttackRadius), this.m_AttackPos.position + (Vector3.right * this.k_AttackRadius),Color.red,1f,false);
        //Debug.DrawLine(this.m_AttackPos.position - (Vector3.up * this.k_AttackRadius), this.m_AttackPos.position + (Vector3.up * this.k_AttackRadius), Color.red, 1f, false);

        //Para cada objeto atingido
        foreach (Collider2D hitObj in hitObjsColl)
        {
          // Dano ao inimigo

          // Empurrar o inimigo (for�a devia ser exercida no lado do script do objeto ao receber dano??)

            //C�lculo da for�a
            Vector2 appliedForce = this.k_attackForce;
            appliedForce.x *= this.m_playerPos.localScale.x > 0 ? 1 : -1; // orientar o sentido da for�a para esq. ou dir.

            SEntity script = SEntity.getObjRootScript(hitObj.gameObject);
            Debug.Log("Hit" + script.gameObject.name);

            //Aplicar for�a se for player
            if (script is SpEntity)
            {
                SEntity.MakeApplyForces(((SpEntity)script).getPlayerRb(), this.k_attackForce);
            }

            // if (script is script de outros objeto interag�veis) do ...
            // -> evit�vel se conseguisse garantir que todos os outros tipos de script implementam rigidbody algures - como ?!??!?
            if (script is StestEntity)
            {
                SEntity.MakeApplyForces(((StestEntity)script).getPlayerRb(), this.k_attackForce);
            }
        }
    }
}
