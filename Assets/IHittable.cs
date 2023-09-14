using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHittable: SEntity
{
    // precisa de ter rigidbody ou precisa de ter colliders?
    Rigidbody2D rb; // aplicar for�as a este rb, se for da classe hittable?

    // fun��o aplicada quando objeto � atingido
    public abstract void Hit();
}
