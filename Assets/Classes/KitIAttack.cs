using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitIAttack : IAttack
{
    [Header("Abilities")]
	[Space]

    [SerializeField] private List<IAbility> inputAbilities;

    private void Awake() {
        this.kitAbilities = new IKit(this.inputAbilities);
    }
}
 