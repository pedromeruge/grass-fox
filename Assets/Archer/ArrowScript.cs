using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //[SerializeField] private float depth = 0.3f; //quanto a seta se deve deslocar para dentro do objeto, quando colide (usar?)
    [SerializeField] private Animator animator;
    private bool hit = false; // atingiu algum objeto na sua trajetoria
    private bool selected = false; // indica se player tem o foco de pickup nesta seta
    private GameObject owner; // pointer para o player que criou esta seta, para n o atingir
    void Awake()
    {
        this.tag = SEntityConsts.TAG_ARROW;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hit) // se ainda n acertou em nada
        {
            GameObject objectHit = SEntity.getObjRoot<SEntity>(other.gameObject);
            if (objectHit.CompareTag(SEntityConsts.TAG_GROUND)) // se atingir terreno
            {
                ArrowStick(other);
                this.hit = true;
                animator.SetBool("Stuck", true);
                //Debug.Log("Hit Wall");
            }
            else if (objectHit.CompareTag(SEntityConsts.TAG_ENEMY) || (objectHit.CompareTag(SEntityConsts.TAG_PLAYER) && objectHit != this.owner)) // NOTA: temporariamente assim para seta n�o matar proprio player no inicio
                                                                                                                                                   // usando pool de setas mais tarde deve ser mais f�cil evitar usar isto
                                                                                                                                                   // isto impossiblita refletir setas para matar o pr�prio player, we want that shit!
            {
                Destroy(objectHit);
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
        Destroy(SEntity.getTaggedRoot(this.gameObject,SEntityConsts.TAG_ARROW),time);
    }

    public void SetParent(GameObject newOwner)
    {
        if (newOwner != null)
        {
        this.owner = newOwner;
        }
        else
        {
            Debug.Log("owner inv�lido aka nulo!");
        }
    }
}
