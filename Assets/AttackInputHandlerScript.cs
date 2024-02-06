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
        if (Input.GetButtonDown("Attack1")) 
        {
            //Debug.Log("Ataque 1");
            playerKits[0].UseAbility(0);
        }
        else if (Input.GetButtonDown("Attack2")) 
        {
            //Debug.Log("Ataque 2");
            playerKits[0].UseAbility(1);
        }
        else if (Input.GetButtonDown("Attack3")) 
        {
            //Debug.Log("Pickup 1");
            playerKits[0].UseAbility(2);
        }
        else if (Input.GetButtonDown("Pickup1")) 
        {
            //Debug.Log("Pickup 1");
            playerKits[0].UseAbility(3);
        }
    }
}
