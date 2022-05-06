using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{

    /* ------------------------------------------ */

    public static ComponentManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<ComponentManager>();

            return _instance;
        }
    }
    static ComponentManager _instance;

    /* ------------------------------------------ */

    public Dictionary<Character, Idle> Idle = new Dictionary<Character, Idle>();
    public Dictionary<Character, Death> Death = new Dictionary<Character, Death>();
    public Dictionary<Character, Move> Move = new Dictionary<Character, Move>();
    public Dictionary<Character, Attack> Attack = new Dictionary<Character, Attack>();
    public Dictionary<Character, Stats> Stats = new Dictionary<Character, Stats>();
    public Dictionary<Character, Run> Run = new Dictionary<Character, Run>();
    public Dictionary<Character, CharacterStateManager> CharacterStateManager = new Dictionary<Character, CharacterStateManager>();

    /* ------------------------------------------ */

}
