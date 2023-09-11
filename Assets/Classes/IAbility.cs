using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

 [System.Serializable] // classes MonoBehaviour não podem ser Serializable!!
public class IAbility
{
    //descrição da habilidade
    [SerializeField] string abilityDesc;

    // função da respetiva abilidade, num script qualquer
    // assim pode haver diferentes habilidades que requerem a logica do mesmo script
    [SerializeField] private UnityEvent abilityFunc; // como restringir só a funcões que afetam player?? 

    // private void Awake() {
    //     if (ability == null) 
    //     {
    //         ability = new UnityEvent();
    //     }
    // }

    public IAbility(IAbility temp)
    {
        this.abilityDesc = temp.abilityDesc;
        this.abilityFunc = temp.abilityFunc; // vou supor que é imutável, no clone needed
    }

    public IAbility Clone()
    {
        return new IAbility(this);
    }

    public void Use() {
        this.abilityFunc.Invoke();
    }

    public string getAbilityDesc() {
        return this.abilityDesc;
    }

    public string getAbilityFunc()
    {
        return this.abilityDesc;
    }


}
