using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users; // InputUser
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    [SerializeField] private PlayerMovement movScript;

    private ControlsGameplay controls;

    void Awake()
    {
        controls = new ControlsGameplay();
    }

    public void InitializePlayer(PlayerConfiguration pc) {
        playerConfig = pc;
        // PlayerInput prevPlayerInput = playerConfig.Input;
        // input.SwitchCurrentControlScheme(prevPlayerInput.currentControlScheme, prevPlayerInput.devices.ToArray());
        playerConfig.Input.SwitchCurrentActionMap("PlayerMovement");
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void OnDisable() { // evitar leaks?
        controls.Disable();
        playerConfig.Input.onActionTriggered -= Input_onActionTriggered;
    }

    private void Input_onActionTriggered(InputAction.CallbackContext ctx) {
        if (ctx.action.name == controls.PlayerMovement.Move.name) {
            OnMove(ctx);
        } else if (ctx.action.name == controls.PlayerMovement.Jump.name) {
            OnJump(ctx);
        } else if (ctx.action.name == controls.PlayerMovement.Crouch.name) {
            OnCrouch(ctx);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        if (movScript != null) {
            movScript.axisX_movementInput = ctx.ReadValue<Vector2>().x;
        }
    }

    // TODO: Faz com que player possa segurar a tecla e saltar continuamente. Só devia poder saltar uma vez
    public void OnJump(InputAction.CallbackContext ctx) {
        if (movScript != null) {
            movScript.jumpInput = ctx.ReadValueAsButton();
        }
    }
    public void OnCrouch(InputAction.CallbackContext ctx) {
        if (movScript != null) {
            movScript.crouchInput = ctx.ReadValueAsButton();
        }
    }
}
