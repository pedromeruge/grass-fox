using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIAttack : IAttack
{
    [Header("Abilities")]
	[Space]

    [SerializeField] private List<IAbility> archerAbilities;

    private void Awake() {
        this.kitAbilities = new IKit(this.archerAbilities);
    }
}
 