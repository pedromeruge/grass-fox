using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    private ParryColliderScript parryScript;

    void Awake()
    {
        SpEntity player = SEntity.getObjRoot<SpEntity>(this.gameObject);
        if (player == null) Debug.LogError("player root is null");
        this.parryScript = player.GetComponentInChildren<ParryColliderScript>();
    }
    
    // Afeta todos os players em contacto com a �rea de ataque do player (�rea circular)
    // D� dano e exer�e for�as contrarias
    public void Parry()
    {
        parryScript.Parry();
    }
}
