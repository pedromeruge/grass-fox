using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    // private PlayerControls controls;

    void Awake()
    {
        // controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration pc) {
        playerConfig = pc;

    }
}
