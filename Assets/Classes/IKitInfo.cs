using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IKitInfo : ScriptableObject
{
    public string kitName; 
    public string kitDesc;

    public Sprite splashArt;
    // protected int lives; // número de corações do player, cada dano tira x corações??
    //protected float moveSpeed;
}
