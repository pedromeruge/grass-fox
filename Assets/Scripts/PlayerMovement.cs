using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private float axisX_movementInput;
    private bool jumpInput;
    private bool crouchInput;
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

    public void OnMove(InputAction.CallbackContext ctx) => axisX_movementInput = ctx.ReadValue<Vector2>().x;

    // TODO: Faz com que player possa segurar a tecla e saltar continuamente. Só devia poder saltar uma vez
    public void OnJump(InputAction.CallbackContext ctx) {
            jumpInput = ctx.ReadValueAsButton();
    }
    public void OnCrouch(InputAction.CallbackContext ctx) => crouchInput = ctx.ReadValueAsButton();

    void Update()
    {
        float horizontalMove = axisX_movementInput * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // garante que qualquer movimento positivo ou negativo � movimento

        if (jumpInput == true) // s� um comando espec�fico para salto, pr�-definido � space
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
        if (crouchInput == true)
        {
            bool droppedPlataform = s_OnewayPlataformScript.dropOffPlataform();
            if (!droppedPlataform)
            {
                crouch = true;
            }
        }

        else if (crouchInput == false)
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
        controller.Move(axisX_movementInput * Time.fixedDeltaTime * runSpeed, crouch, jump);
        jump = false;
    }
}
