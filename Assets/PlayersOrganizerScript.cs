using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersOrganizerScript : MonoBehaviour
{
    List<GameObject> scenePlayers;

    private void Awake() {
        scenePlayers = new List<GameObject>();
    }

    public void addPlayer(GameObject player) {
        if (player == null || player.CompareTag("RootPlayer")) return;
        scenePlayers.Add(player);
    }


    
}
