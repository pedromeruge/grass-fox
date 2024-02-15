using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform players;
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.playerConfigs.ToArray();
        Debug.Log(playerConfigs.Length);
        for (int i=0;i<playerConfigs.Length; i++) {
            var player = Instantiate(playerPrefab,players); // spawnar em spawn points pré-definidos talvez
            // var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation,gameObject.transform);
            player.GetComponentInChildren<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

}
