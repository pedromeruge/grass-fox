using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private float horizontalMove = 0f;
    public bool crouch = false,
                jump = false;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private Animator animator;

    private OneWayPlataformScript s_OnewayPlataformScript;

    void Awake()
    {
        if (controller == null) 
        {
        controller = this.GetComponent<CharacterController2D>();
        }

        if (s_OnewayPlataformScript == null) 
        {
        this.s_OnewayPlataformScript = this.GetComponent<OneWayPlataformScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // d� logo para qualquer input de xx, ou seja arrow keys e A e D
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // garante que qualquer movimento positivo ou negativo � movimento

        if (Input.GetButtonDown("Jump")) // s� um comando espec�fico para salto, pr�-definido � space
        {
            jump = true; // vai passar true a move no fixedUpdate
            animator.SetBool("IsJumping", true);
            //Debug.Log("isJumping?: true");
        }

        /*
        // parar de segurar o salto
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        */
        if (Input.GetButtonDown("Down"))
        {
            bool droppedPlataform = s_OnewayPlataformScript.dropOffPlataform();
            if (!droppedPlataform)
            {
                crouch = true;
            }
        }

        else if (Input.GetButtonUp("Down"))
        {
            crouch = false; // mete sempre a false mesmo quando desce plataformas, mas caguei
        }
    }

    //usado ao aterrar no chao no characterController, para identificar a chegada ao ch�o para as anima��es
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
        //Debug.Log("isJumping?: false");
    }

    public void OnJumping()
    {
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsFalling", false);
    }

    public void OnFalling()
    {
        //animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    //update apropriado para updates de physics!
    // time.fixeddeltatime garante speed id�ntico para qualquer sistema
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
