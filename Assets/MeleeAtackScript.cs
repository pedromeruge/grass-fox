using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeAtackScript : MonoBehaviour
{
    [SerializeField] [Range (0.1f,1f)] private float k_AttackRadius = .2f;
    [SerializeField] private Vector2 k_attackForce = Vector2.zero; // força exercida sobre inimigos quando atacados
    [SerializeField] private Transform m_AttackPos; // pos. central do ataque
    [SerializeField] private LayerMask m_WhatIsHittable; // layers com que o ataque pode interagir

    Animator animator; // não usado
    Transform m_playerPos; // saber orientação do player, para aplicar o dano

    void Start()
    {
        animator = this.GetComponent<Animator>();
        this.m_playerPos = SEntity.getPlayerObjWithName(SEntity.getTaggedRoot(this.gameObject, SEntityConsts.TAG_PLAYER), "ICollisions").transform; // sem null checks, lazy
    }
    
    // Afeta todos os players em contacto com a área de ataque do player (área circular)
    // Dá dano e exerçe forças contrarias
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

          // Empurrar o inimigo (força devia ser exercida no lado do script do objeto ao receber dano??)

            //Cálculo da força
            Vector2 appliedForce = this.k_attackForce;
            appliedForce.x *= this.m_playerPos.localScale.x > 0 ? 1 : -1; // orientar o sentido da força para esq. ou dir.

            SEntity script = SEntity.getObjRootScript(hitObj.gameObject);
            Debug.Log("Hit" + script.gameObject.name);

            //Aplicar força se for player
            if (script is SpEntity)
            {
                SEntity.MakeApplyForces(((SpEntity)script).getPlayerRb(), this.k_attackForce);
            }

            // if (script is script de outros objeto interagíveis) do ...
            // -> evitável se conseguisse garantir que todos os outros tipos de script implementam rigidbody algures - como ?!??!?
            if (script is StestEntity)
            {
                SEntity.MakeApplyForces(((StestEntity)script).getPlayerRb(), this.k_attackForce);
            }
        }
    }
}
