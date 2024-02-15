using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
public class SpawnPlayerCard : MonoBehaviour
{
    [SerializeField] private GameObject playerCardPrefab;
    [SerializeField] private PlayerInput input;
    private CharacterSelectorController prefabScript; // forma rota que arranjei de poder aceder a script dentro do prefab
    private ControlsGameplay controls;

   private void Awake() {
    var rootMenu = GameObject.Find("Players"); // cada carta de player vai surgir debaixo do component "Players"
    if (rootMenu != null) {
        var menu = Instantiate(playerCardPrefab, rootMenu.transform);
        input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>(); //link do inputsystemUI no prefab
        prefabScript = menu.GetComponent<CharacterSelectorController>();
        prefabScript.SetPlayerIndex(input.playerIndex);
        controls = new ControlsGameplay();
    }
   }

   private void OnEnable() {
        controls.Enable();
        input.onActionTriggered += Input_onActionTriggered;
   }

   private void OnDisable()
   {
       controls.CharacterSelector.Disable();
       input.onActionTriggered -= Input_onActionTriggered;
   }

    private void Input_onActionTriggered(InputAction.CallbackContext ctx) {
        if (ctx.action.name == controls.CharacterSelector.ChangeCharacter.name) {
            OnChangeCharacter(ctx);
        } else if (ctx.action.name == controls.CharacterSelector.Ready.name) {
            OnReady(ctx);
        } else if (ctx.action.name == controls.CharacterSelector.Start.name) {
            OnStartGame(ctx);
        } else if (ctx.action.name == controls.CharacterSelector.Start.name) {
            OnDisconnect(ctx);
        }
    }

   // N PERECBO COMO É QUE SE FAZ ISTO DE MANEIRA MAIS CLEAN ;_;
   // Acho que se quisesse fazer por c# script diretamente no CharacterSelectorController, o script no prefab tinha de ter acesso a este PlayerInput, how the fuck do that?
   // Repete-se aqui o método e toca a andar i guess
   public void OnChangeCharacter(InputAction.CallbackContext ctx) {
    prefabScript.OnChangeCharacter(ctx);
   }

   public void OnReady(InputAction.CallbackContext ctx) {
    prefabScript.OnReady(ctx);
   }

   public void OnStartGame(InputAction.CallbackContext ctx) {
    prefabScript.OnStartGame(ctx);
   }

   public void OnDisconnect(InputAction.CallbackContext ctx) {
    // do something??
   }
}
