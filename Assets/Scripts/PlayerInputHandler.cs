using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users; // InputUser
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    [SerializeField] private PlayerInput input;
    // private ControlsCharSelector controls;

    void Awake()
    {
        // controls = new ControlsCharSelector(); // devia ser os controlos do gameplay não do menu, aonde é que ficam os de menu???
    }

    public void InitializePlayer(PlayerConfiguration pc) {
        playerConfig = pc;
        PlayerInput prevPlayerInput = playerConfig.Input;
        //se isto falhar tentar o que está abaixo
        // input.SwitchCurrentControlScheme(prevPlayerInput.currentControlScheme, new InputDevice[0]);
        // foreach (var device in prevPlayerInput.devices)
        //     InputUser.PerformPairingWithDevice(device, input.user);
        input.SwitchCurrentControlScheme(prevPlayerInput.currentControlScheme, prevPlayerInput.devices.ToArray());
    }

    // private void Input_onActionTriggered(InputAction.CallbackContext obj) {
    //     if (obj.action.name == controls.PlayerMovement.Movement.name) {
    //         OnMove(obj);
    //     }
    // }
}
