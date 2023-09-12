using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject arrow; // prefab usado para dar spawn de novas setas

    [SerializeField] private int maxArrows = 3; // n�mero de setas m�ximo
    [SerializeField] private float speed = 40f; // velocidade da seta em movimento
    [SerializeField] const float k_PickUpArrow_radius = 2f; // raio de procurar setas � volta do player
    [SerializeField] private LayerMask m_WhatIsArrow; // layer das setas 
    private Vector3 arrowOffset = new Vector3(0f, -0.4f, 0);
    private int arrowsLeft; // n�mero de setas dispon�veis
    private GameObject currArrow = null; // seta atualmente mais pr�xima do player, poss�vel de ser recolhida

    //necessário com a divisão do player em vários gameObjects
    private ICollisions collisions;
    private SpEntity root_Player;

    void Awake() {
        if (this.root_Player == null)
        {
            this.root_Player = SEntity.getObjRoot<SpEntity>(this.gameObject);
            if (this.root_Player == null) return;
        }
        if (this.collisions == null)
        {
            this.collisions = root_Player.GetComponentInChildren<ICollisions>(); // sem null checks, lazy
            if (this.collisions == null) return;
        }
        this.arrowsLeft = maxArrows;
    }

    private void FixedUpdate()
    {
        //Debug.Log("número de setas no fixedUpdate: " + this.arrowsLeft.ToString() + this.gameObject.ToString());
        if (arrowsLeft < maxArrows) // quando há setas para apanhar, procurar a mais proxima para apanhar, se possível
        {
            GameObject prevArrow = this.currArrow;
            LocatePickableArrow();

            if (prevArrow != null && prevArrow != currArrow) // caso a seta selecionada mude, tira a seleção da anterior
            {
                prevArrow.GetComponent<ArrowScript>().UnHighlightArrow();
            }
            if (currArrow != null) // se houver seta a ser selecionada
            {
                //Debug.Log("arrowHighlighted: " + currArrow.ToSafeString());
                currArrow.GetComponent<ArrowScript>().HighlightArrow();

            }
        }
    }

    //lançar seta
    public void Shoot() {
        //Debug.Log("número de setas ao disparar: " + this.arrowsLeft.ToString() + this.gameObject.ToString());
        if (this.arrowsLeft > 0) {
            this.arrowsLeft -= 1;
            //Debug.Log("spawn de seta");
            StartCoroutine(spawnArrow());
        }
    }

    //pegar em seta
    public void PickUpArrow() {
        if (currArrow != null)
            {
                arrowsLeft += 1;
                //Debug.Log("ArrowsLeft: " + this.arrowsLeft);
                currArrow.GetComponent<ArrowScript>().DestroyArrow(0f);
                currArrow = null;
            }
    }

    //de todas as setas � volta do player, identifica a que est� mais pr�xima, ou null se n houver
    private void LocatePickableArrow()
    {
        Collider2D closestArrow = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currPos = this.collisions.transform.position;
        Collider2D[] arrows = Physics2D.OverlapCircleAll(currPos, k_PickUpArrow_radius, m_WhatIsArrow); // procura todas as arrows (layer 7)
        foreach(var arr in arrows)
        {
            Vector3 directionToTarget = arr.transform.position - currPos;
            float dSqrToArrow = directionToTarget.sqrMagnitude; // evita-se fazer sqrt que o Physics2D.Distance envolve
            //Debug.Log("seta: " + arr.ToSafeString() + "dist: " + dSqrToArrow);
            if (closestDistSqr > dSqrToArrow)
            {
                closestDistSqr = dSqrToArrow;
                closestArrow = arr;
            }
        }
        this.currArrow = (closestArrow == null) ? null : closestArrow.gameObject;
    }

    //spawn de seta, com velocidade, sprite e direção ajustada à orientação do jogador
    private IEnumerator spawnArrow()
    {
        int facingRight = collisions.transform.localScale.x > 0 ? 1 : -1; // seta para a esq. ou dir.

        //Vector3 spawnPos = this.transform.position + new Vector3(this.arrowOffset.x * facingRight, this.arrowOffset.y, this.arrowOffset.z); // lugar de spawn da seta

        GameObject copy = Instantiate(arrow, collisions.transform.position, Quaternion.identity); //spawn da seta

        //desativar  colisões com player, ao criar a seta, para não o empurrar
        Collider2D[] playerColliders = collisions.GetComponents<Collider2D>();

        // if (playerColliders == null) do ???
        Collider2D[] arrowColliders = copy.GetComponents<Collider2D>();
        SEntity.MakeIgnoreCollisions(playerColliders, arrowColliders,true);

        // define o player pai da seta
        Rigidbody2D newArrow = copy.GetComponent<Rigidbody2D>();
        copy.GetComponent<ArrowScript>().SetParent(this.root_Player); 

        //atribui velocidade e d~ireção
        newArrow.velocity = new Vector3(speed * facingRight, 0, 0); // ajusta a velocidade da seta � dire��o
        //n consegui fazer quaternion afetar a rota��o da seta, tive que copiar a do player controller manualmente
        // Multiply the player's x local scale by -1.
        Vector3 theScale = newArrow.transform.localScale;
        theScale.x *= facingRight;
        newArrow.transform.localScale = theScale;

        //espera 0.1s
        yield return new WaitForSeconds(0.1f);

        // retorna colisões (se seta ainda não foi destruída)
        if (copy != null)
        {
            SEntity.MakeIgnoreCollisions(playerColliders, arrowColliders, false);
        }

    }
    
}
