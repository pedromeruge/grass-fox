using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLayoutManager : MonoBehaviour
{
    [SerializeField] public List<IKitInfo> kits = new List<IKitInfo>();
    public static CharacterLayoutManager Instance {get; private set;}

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}
