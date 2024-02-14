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
   private void Awake() {
    var rootMenu = GameObject.Find("Players"); // cada carta de player vai surgir debaixo do component "Players"
    if (rootMenu != null) {
        var menu = Instantiate(playerCardPrefab, rootMenu.transform);
        input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>(); //link do inputsystemUI no prefab
        prefabScript = menu.GetComponent<CharacterSelectorController>();
        prefabScript.SetPlayerIndex(input.playerIndex);

    }
   }

   // N PERECBO COMO É QUE SE FAZ ISTO DE MANEIRA MAIS CLEAN ;_;
   // Acho que se quisesse fazer por c# script, o script no prefab tinha de ter acesso a este PlayerInput, o que acabava por ser desnecessariamente complicado acho.
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
}
