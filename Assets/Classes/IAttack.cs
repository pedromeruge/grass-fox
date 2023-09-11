using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//segue composição
public class IAttack : MonoBehaviour {
    protected IKit kitAbilities;

    public void UseAbility(int pos) {
        if (pos >= 0 && pos < kitAbilities.getAbilityCount()) {
            Debug.Log("Used: " + this.kitAbilities.getAbility(pos).getAbilityDesc());
            this.kitAbilities.getAbility(pos).Use();
        }
        else
        {
            Debug.Log("Ability unavailabe in that position");
        }
    }

    public IKit KitAbilities
    {
        get { return this.kitAbilities.clone(); }
        set { this.kitAbilities = value.clone(); }
    }
}
