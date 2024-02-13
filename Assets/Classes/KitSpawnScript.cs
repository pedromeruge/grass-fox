using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kits/Kit")]

public class KitSpawnScript : IKitInfo
{
    [SerializeField] private string s_kitName;
    [SerializeField] private string s_kitDesc;
    [SerializeField] private Sprite s_splashArt;
    // [SerializeField] private int k_lives;
    //[SerializeField] private float k_moveSpeed;


    void Awake() {
        this.kitName = this.s_kitName;
        this.kitDesc = this.s_kitDesc;
        this.splashArt = this.s_splashArt;
        // this.lives = this.k_lives;
        //this.moveSpeed = this.k_moveSpeed;
    }

}
