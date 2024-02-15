using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//segue agrega��o (sen�o n�o dava)
public class IKit
{
    protected List<IAbility> kitAbilities;

    public IKit()
    {
        this.kitAbilities = new List<IAbility>();
    }

    public IKit(List<IAbility> temp)
    {
        this.kitAbilities = new List<IAbility>(temp);
    }

    public IKit(IKit temp)
    {
        this.kitAbilities = temp.kitAbilities;
    }

    public List<IAbility> getKitAbilities()
    {
        List < IAbility > list = new List<IAbility>();
        return new List<IAbility>(this.kitAbilities);
    }

    public int getAbilityCount()
    {
        return this.kitAbilities.Count;
    }

    public IAbility getAbility(int index)
    {
        return new IAbility(this.kitAbilities[index]);
    }

    public IKit clone()
    {
        return new IKit(this);
    }
}
