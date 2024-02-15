    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackInputHandler : MonoBehaviour
{
    private List<IAttack> playerKits;

    // assume-se que existe um IAttack nos filhos de cada root_Player
    private void Awake() {
        playerKits = new List<IAttack>();
        //Debug.Log(GameObject.FindGameObjectsWithTag(SEntityConsts.TAG_PLAYER).Length);
        foreach (SpEntity player in GameObject.FindObjectsOfType<SpEntity>()) 
        {
            IAttack playerKit = player.GetComponentInChildren<IAttack>(); // procurar kit de ataque nos players da cena
            if (playerKit != null)
            {
                playerKits.Add(playerKit);
            }
      
        }
    }

    private void Update() {

    }
}
