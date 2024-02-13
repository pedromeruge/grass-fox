using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryColliderScript : MonoBehaviour
{
    [SerializeField] private float parryTime = 0.5f;
    private Animator animator; // n�o usado
    private Transform playerTransform;
    private bool isParrying = false;
    private List<Collider2D> currentColliders = new List<Collider2D>(); // lista de itens a colidir com zona de parry neste momento
    // Start is called before the first frame update

    void Awake()
    {
        SpEntity player = SEntity.getObjRoot<SpEntity>(this.gameObject);
        playerTransform = player.GetComponentInChildren<ICollisions>().transform;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!currentColliders.Contains(other)) {currentColliders.Add(other);}
        if ((isParrying) == true) {
            ParryLogic();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentColliders.Remove(other);
    }

    public void Parry() {
        if (!isParrying) {
            StartCoroutine(ParryRoutine());
        }
    }

    public IEnumerator ParryRoutine() {
        isParrying = true;
        yield return new WaitForSeconds(parryTime);
        isParrying = false;
    }
    // Afeta todos os players em contacto com a �rea de ataque do player (�rea circular)
    // D� dano e exer�e for�as contrarias
    public void ParryLogic()
    {
        //Para cada objeto atingido
        foreach (Collider2D hitObj in currentColliders)
        {
            SEntity entity = SEntity.getObjRoot<SEntity>(hitObj.gameObject);

            if (entity is null) Debug.LogError("entity hit has null root");

            // TODO: melhorar deteção de colisão está unreliable
            if (entity is StoEntity && ((StoEntity) entity).isStuck == false) {
                // Debug.Log("Parried entity");
                Rigidbody2D rb = hitObj.GetComponentInChildren<Rigidbody2D>();
                int facingRight = playerTransform.localScale.x > 0 ? 1 : -1; // seta para a esq. ou dir.
                float arrowSpeed = Mathf.Max(Mathf.Abs(rb.velocity.x),Mathf.Abs(rb.velocity.y));

                rb.velocity = new Vector2(1 * Mathf.Sign(playerTransform.localScale.x), 0) * arrowSpeed * 1.2f; // decidi aumentar o speed no rebound
                float angleInDegrees = Mathf.Acos(facingRight) * Mathf.Rad2Deg;
                rb.transform.rotation = Quaternion.Euler(0,0, angleInDegrees);
            }
        }
    }
}
