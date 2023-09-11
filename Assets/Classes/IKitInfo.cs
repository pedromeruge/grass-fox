using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IKitInfo : ScriptableObject
{
    protected string kitName; 
    protected string kitDesc;
    protected int lives; // número de corações do player, cada dano tira x corações??
    //protected float moveSpeed;
    //public abstract void Attack1(); // ataque principal
    // //public abstract void Attack2(); // ataque secundário
    //public abstract void Pickup1(); // recolher objetos de kits (ex: setas,...)
}
