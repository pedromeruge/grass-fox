using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlataformScript : MonoBehaviour
{
    private Collider2D PlataformCollider;
    [SerializeField] private Collider2D[] playerColliders; // meter o circleCollider na pos 0, senão o dropOffPlataform falha!
    [SerializeField] [Range (0.1f,1f)] private float playerCollisionOffTime = 0.5f;

    //se poss�vel cai da plataforma
    // devolve se foi poss�vel

    private void Start() 
    {
        if (this.PlataformCollider == null)
            this.PlataformCollider = GameObject.FindWithTag("OneWayPlataform").GetComponent<CompositeCollider2D>();
    }
    public bool dropOffPlataform()
    {
        bool ret = false;
        bool onPlataform = playerColliders[0].IsTouching(this.PlataformCollider); // indica se player está em contacto com plataforma
        if (onPlataform) // se estiver sobre plataform
        {
            StartCoroutine(DisablePlatPlayerCollision());
            ret = true;
        }
        return ret;
    }

    // corotina!!
    // fun��o que decorre ao longo de v�rios frames, chamada como rotina
    // assim n�o bloqueia a main thread ao ser usada em fun��es de update (que s�o instant�neas)
    // remove a colis�o do player para atravessar a plataforma
    private IEnumerator DisablePlatPlayerCollision()
    {
        int collidersNumber = this.playerColliders.Length;
        //desativa colis�o entre player e plataforma
        for (int i = 0; i<collidersNumber; i++)
        {
            Physics2D.IgnoreCollision(this.playerColliders[i], this.PlataformCollider); 
        }

        yield return new WaitForSeconds(this.playerCollisionOffTime);

        //reativa colis�o entre player e plataforma
        for (int i = 0; i < collidersNumber; i++)
        {
            Physics2D.IgnoreCollision(this.playerColliders[i], this.PlataformCollider, false); 
        }
    }
}
