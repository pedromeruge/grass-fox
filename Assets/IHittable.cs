using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHittable: SEntity
{
    // precisa de ter rigidbody ou precisa de ter colliders?
    Rigidbody2D rb; // aplicar forças a este rb, se for da classe hittable?

    // função aplicada quando objeto é atingido
    public abstract void Hit();
}
