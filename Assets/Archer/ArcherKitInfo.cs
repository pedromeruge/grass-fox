using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kits/Archer")]

public class ArcherKitInfo : IKitInfo
{
    [SerializeField] private string s_kitName;
    [SerializeField] private string s_kitDesc;
    // [SerializeField] private int k_lives;
    //[SerializeField] private float k_moveSpeed;
    //[SerializeField] private Animator Animator;
    //[SerializeField] private Animator animator??

    void Awake() {
        this.kitName = this.s_kitName;
        this.kitDesc = this.s_kitDesc;
        // this.lives = this.k_lives;
        //this.moveSpeed = this.k_moveSpeed;
    }

}
