using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //[SerializeField] private float depth = 0.3f; //quanto a seta se deve deslocar para dentro do objeto, quando colide (usar?)
    [SerializeField] private Animator animator;
    public int damage = 0;
    private bool hit = false; // atingiu algum objeto na sua trajetoria
    private bool selected = false; // indica se player tem o foco de pickup nesta seta
    private SpEntity owner; // pointer para o player que criou esta seta, para n o atingir
    void Awake()
    {
        this.tag = SEntityConsts.TAG_TEMPOFFENSIVE;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hit) // se ainda n acertou em nada
        {
            SEntity objectHit = SEntity.getObjRoot<SEntity>(other.gameObject);
            if (objectHit is SgEntity) // se atingir terreno
            {
                ArrowStick(other);
                animator.SetBool("Stuck", true);
                this.hit = true;
                //Debug.Log("Hit Wall");
            }
            else if (objectHit is SpEntity) // usando pool de setas mais tarde deve ser mais f�cil evitar usar isto
            {
                objectHit.GetComponentInChildren<Stats>().damage(this.damage);


                DestroyArrow(0f);
            }
            else
            {
                Debug.Log("Arrow hit unknown surface");
                DestroyArrow(0f);
            }
        }
    }

    //seta ficar apegada a objeto que acertou
    private void ArrowStick(Collision2D obj)
    {
        //this.transform.parent = obj.transform; // faz a seta filha do outro objeto, para se mover com ele (no caso de inimigos?)
        Destroy(this.GetComponent<Rigidbody2D>()); // destruir o rigidbody2D para n poder ser mais afetado por for�as
    }

    //indica que est� selecionada para ser a seta pegada
    // ativa uma anima��o
    public void HighlightArrow()
    {
        if (this.hit)
        {
            this.selected = true;
            animator.SetBool("Selected", true);
        }
    }

    //indica que j� n�o est� selecionada para ser a seta pegada
    // desativa a anima��o
    public void UnHighlightArrow()
    {
        this.selected = false;
        animator.SetBool("Selected", false);

    }

    //destroi a seta, ap�s x segundos
    public void DestroyArrow(float time)
    {
        //animator.SetBool("Destroy", true); // adicionar anima��es depois??
        StoEntity root_arrow = SEntity.getObjRoot<StoEntity>(this.gameObject);
        if (root_arrow == null) Debug.LogError("Root is null");
        Destroy(root_arrow.gameObject,time);
    }

    public void SetParent(SpEntity newOwner)
    {
        if (newOwner != null)
        {
        this.owner = newOwner;
        }
        else
        {
            Debug.Log("owner nulo!");
        }
    }
}
