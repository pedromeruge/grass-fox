using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    [SerializeField] private int MinPlayers = 2; // mínimo necessário para começar partida
    public List<PlayerConfiguration> playerConfigs;

    public static PlayerConfigurationManager Instance {get; private set;}

    public const uint N_PLAYERS = 4;

    void Awake() {

        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public void ReadyPlayer(int index) {
        playerConfigs[index].isReady = true;
    }

    public void changeKitPlayer(int playerId, int kitId) {
        playerConfigs[playerId].currKitId = kitId;
    }

    public void StartGame() {
        if (playerConfigs.Count >= MinPlayers && playerConfigs.All( p => p.isReady == true)) {
            Debug.Log("Starting game");
            SceneManager.LoadScene("GameplayScene");
        }
        Debug.Log("Failed to start game");
    }

    public void HandlePlayerJoin(PlayerInput pi) {
        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex)) {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));

        }
    }

    public void HandlePlayerLeave(PlayerInput pi) {
    // n está a dar !???!?!
        // Debug.Log("Player left");
        // GameObject playerCard = GameObject.Find("Players").transform.GetChild(pi.playerIndex).gameObject;
        // if (playerCard != null) {
        //     Destroy(playerCard);
        //     playerConfigs.RemoveAt(pi.playerIndex);
        // }
        // else {
        //     Debug.Log("Couldn't remove player");
        // }
    }
}

public class PlayerConfiguration
{
    public PlayerInput Input {get; set;}
    public int PlayerIndex {get; set;}
    public bool isReady {get; set; }

    public int currKitId {get; set;}

    // meter aqui classe como ???

    public PlayerConfiguration(PlayerInput pi) {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        isReady = false;
        currKitId = 0;
    }
}
