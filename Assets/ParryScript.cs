using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    [SerializeField] [Range (0.1f,1f)] private float k_AttackX = .2f;
    [SerializeField] [Range (0.1f,1f)] private float k_AttackY = .2f;
    [SerializeField] private Vector2 k_attackForce = Vector2.zero; // for�a exercida sobre objetos
    [SerializeField] private Transform m_AttackPos; // pos. central do ataque
    [SerializeField] private LayerMask m_WhatIsParryable; // layers com que o parry pode interagir

    private Animator animator; // n�o usado
    private Transform m_playerPos; // saber orienta��o do player

    void Start()
    {
        animator = this.GetComponent<Animator>();
        SpEntity player = SEntity.getObjRoot<SpEntity>(this.gameObject);
        if (player == null) Debug.LogError("player root is null");
        this.m_playerPos = player.GetComponentInChildren<ICollisions>().transform; 
    }
    
    // Afeta todos os players em contacto com a �rea de ataque do player (�rea circular)
    // D� dano e exer�e for�as contrarias
    public void Parry()
    {
        //melhor usar OverlapBox ??? overlapBox tem formato de output em array??
        Collider2D[] hitObjsColl = Physics2D.OverlapBoxAll(this.m_AttackPos.position, new Vector2(k_AttackX,k_AttackY),0f,m_WhatIsParryable);

        Debug.DrawLine(this.m_AttackPos.position - (Vector3.right * (this.k_AttackX/2)), this.m_AttackPos.position + (Vector3.right * (this.k_AttackX/2)),Color.red,1f,false);
        Debug.DrawLine(this.m_AttackPos.position - (Vector3.up * (this.k_AttackY/2)), this.m_AttackPos.position + (Vector3.up * (this.k_AttackY/2)),Color.red,1f,false);
        //Para cada objeto atingido
        foreach (Collider2D hitObj in hitObjsColl)
        {
            SEntity entity = SEntity.getObjRoot<SEntity>(hitObj.gameObject);

            if (entity is null) Debug.LogError("entity hit has null root");
            if (entity is StoEntity) {
                Rigidbody2D rb = hitObj.GetComponentInChildren<Rigidbody2D>();
                Vector2 appliedForce = rb.velocity;
                appliedForce.x *= this.m_playerPos.localScale.x > 0 ? 1 : -1; // orientar o sentido da for�a para esq. ou dir.
                rb.AddForce(appliedForce);
            }
        }
    }
}
