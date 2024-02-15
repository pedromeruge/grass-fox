using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users; // InputUser
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    private PlayerMovement movScript;
    private IAttack playerKit;
    private ControlsGameplay controls;

    void Awake()
    {
        controls = new ControlsGameplay();
        SpEntity player = SEntity.getObjRoot<SpEntity>(this.gameObject);
        movScript = player.GetComponentInChildren<PlayerMovement>();
        playerKit = player.GetComponentInChildren<IAttack>();
    }

    public void InitializePlayer(PlayerConfiguration pc) {
        playerConfig = pc;
        // PlayerInput prevPlayerInput = playerConfig.Input;
        // input.SwitchCurrentControlScheme(prevPlayerInput.currentControlScheme, prevPlayerInput.devices.ToArray());
        playerConfig.Input.SwitchCurrentActionMap("PlayerMoveAttack");
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void OnDisable() { // evitar leaks?
        controls.Disable();
        playerConfig.Input.onActionTriggered -= Input_onActionTriggered;
    }

    private void Input_onActionTriggered(InputAction.CallbackContext ctx) {
        if (ctx.action.name == controls.PlayerMoveAttack.Move.name) {
            OnMove(ctx);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Jump.name) {
            OnJump(ctx);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Crouch.name) {
            OnCrouch(ctx);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Attack1.name) {
            playerKit.UseAbility(0);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Attack2.name) {
            playerKit.UseAbility(1);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Attack3.name) {
            playerKit.UseAbility(2);
        } else if (ctx.action.name == controls.PlayerMoveAttack.Attack4.name) {
            playerKit.UseAbility(3);
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
