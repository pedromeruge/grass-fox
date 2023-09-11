using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEntity : MonoBehaviour
{
    // Quando se sabe especificamente o tipo de root do objeto
    //Melhor type checking no futuro, n estou a ver direito agora como?

    [Obsolete("getTaggedRoot está deprecated, usar GetRoot<T>")]
    public static GameObject getTaggedRoot(GameObject obj, string tag)
    {
        if (obj == null)
        {
            Debug.LogError("Obj is null");
            return null;
        }

        GameObject root = obj;

        while (root != null && !root.CompareTag(tag))
        {
            root = root.transform.parent.gameObject;
        }
        // if (didn´t find root) do ???
        //Debug.Log("isRoot==SEntity: " + (root.GetComponent<SEntity>() != null));
        return root;
    }

    //outra solucao seria usar this.transform.root, mas isso só funciona se os componentes estivessem no topo da cena atual, senão quebrava

    //obtém objeto base de qualquer tipo T de obj, na cena
    public static GameObject getObjRoot<T>(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("Obj is null");
            return null;
        }

        GameObject root = obj;

        while (root != null && root.GetComponent<T>() == null) // custoso este getComponent, outra solucao?
        {
            root = root.transform.parent.gameObject;
        }
        // if (didn´t find root) do ???
        //Debug.Log("isRoot==SEntity: " + (root.GetComponent<SEntity>() != null));
        return root;
    }

    //obtém script do objeto base de qualquer tipo de obj na cena
    public static SEntity getObjRootScript(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("Obj is null");
            return null;
        }

        GameObject root = obj;

        while (root != null && !root.tag.StartsWith("root"))
        {
            root = root.transform.parent.gameObject;
        }
        if (root == null)
        { // fazer o quê?
            Debug.LogError("Couldn´t find root");
            return null;
        }

        SEntity script = root.GetComponent<SEntity>();
        if (script == null)
        {
            Debug.LogError("Couldn´t find root script");
        }
        return script;
    }

    // obter objeto especificamente de player
    public static GameObject getPlayerObjWithName(GameObject obj, string name)
    {
        if (obj == null || !obj.CompareTag(SEntityConsts.TAG_PLAYER))
        { // se obj n for root do player
            Debug.LogError("objeto argumento não é root de player");
            return null;
        }
        return obj.transform.Find(name).gameObject;
    }

    //Devolve gameObject com o nome dado, partindo do objeto root dado
    public static GameObject getObjWithName(GameObject obj, string name)
    {
        if (obj == null || !obj.tag.StartsWith("root"))
        {
            Debug.LogError("objeto argumento não é root de obj");
        }
        return obj.transform.Find(name).gameObject;
    }

    //ignorar colisões entre dois colliders dados
    public static void MakeIgnoreCollision(Collider2D a, Collider2D b)
    {
        if (a == null || b == null)
        {
            Debug.LogError((a == null) ? "First " : "Second " + " argument Collider2D" + "is null");
        }
        Physics2D.IgnoreCollision(a, b);
    }

    //ignorar colisões entre todos os colliders de cada objeto dado
    // state: true -> ignora, false-> colidem outra vez
    public static void MakeIgnoreCollisions(Collider2D[] a, Collider2D[] b, bool state)
    {
        if (a == null || b == null)
        {
            Debug.LogError((a == null) ? "First " : "Second " + " argument GameObject" + "is null");
        }

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                Physics2D.IgnoreCollision(a[i], b[j], state);
            }
        }
    }


    // ignorar colisões entre dois objetos, sabendo tipos ??? são todos GameObject
    // como é que distinguo esta shit ;_;;;;
    public static void MakeIgnoreCollision<T, U>(T a, U b)
    {
        if (a == null || b == null)
        {
            Debug.LogError((a == null) ? "First " : "Second " + " argument GameObject" + "is null");
        }
    }

    //aplica força a um rb, dado o vetor força
    public static void MakeApplyForces(Rigidbody2D obj, Vector2 force)
    {
        obj.AddForce(force);
    }


    //aplica força a lista de rb, dado o vetor força
    public static void MakeApplyForces(Rigidbody2D[] obj, Vector2 force)
    {

    }
}
