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
        prefabScript = menu.GetComponent<CharacterSelectorController>();
        prefabScript.SetPlayerIndex(input.playerIndex);

    }
   }

   // N PERECBO COMO É QUE SE FAZ ISTO DE MANEIRA MAIS CLEAN ;_;
   public void OnChangeCharacter(InputAction.CallbackContext ctx) {
    prefabScript.OnChangeCharacter(ctx);
   }

   public void OnReady(InputAction.CallbackContext ctx) {
    prefabScript.OnReady(ctx);
   }
}
