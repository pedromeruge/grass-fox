using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InitializeLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject players;

    private List<Transform> playerSpawns = new List<Transform>();

    private void Awake() {
        foreach(Transform child in transform) {
            playerSpawns.Add(child);
        }
    }

    private void Start() {
        var playersTargetCamera = players.GetComponent<CinemachineTargetGroup>();
        var playerConfigs = PlayerConfigurationManager.Instance.playerConfigs.ToArray();
        Debug.Log(playerConfigs.Length);
        for (int i=0;i<playerConfigs.Length; i++) {
            // criar player
            // var player = Instantiate(playerPrefab,players.transform); // spawnar em spawn points pré-definidos talvez
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponentInChildren<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);

            //adicionar player ao camera tracker
            playersTargetCamera.AddMember(player.GetComponentInChildren<ICollisions>().transform,1,5); // weight, radius -> o que meter??
        }
    }

}
