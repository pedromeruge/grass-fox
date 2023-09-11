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
            else if (objectHit.CompareTag(SEntityConsts.TAG_ENEMY) || (objectHit.CompareTag(SEntityConsts.TAG_PLAYER) && objectHit != this.owner)) // NOTA: temporariamente assim para seta não matar proprio player no inicio
                                                                                                                                                   // usando pool de setas mais tarde deve ser mais fácil evitar usar isto
                                                                                                                                                   // isto impossiblita refletir setas para matar o próprio player, we want that shit!
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
        Destroy(this.GetComponent<Rigidbody2D>()); // destruir o rigidbody2D para n poder ser mais afetado por forças
    }

    //indica que está selecionada para ser a seta pegada
    // ativa uma animação
    public void HighlightArrow()
    {
        if (this.hit)
        {
            this.selected = true;
            animator.SetBool("Selected", true);
        }
    }

    //indica que já não está selecionada para ser a seta pegada
    // desativa a animação
    public void UnHighlightArrow()
    {
        this.selected = false;
        animator.SetBool("Selected", false);

    }

    //destroi a seta, após x segundos
    public void DestroyArrow(float time)
    {
        //animator.SetBool("Destroy", true); // adicionar animações depois??
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
            Debug.Log("owner inválido aka nulo!");
        }
    }
}
