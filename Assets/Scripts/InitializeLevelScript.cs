using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.playerConfigs.ToArray();
        for (int i=0;i<playerConfigs.Length; i++) {
            var player = Instantiate(playerPrefab,transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

}
