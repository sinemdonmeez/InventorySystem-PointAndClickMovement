using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    /* ------------------------------------------ */

    public static StateManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<StateManager>();

            return _instance;
        }
    }
    static StateManager _instance;

    /* ------------------------------------------ */

    public List<CharacterStateManager> CharacterStateManagers;

    /* ------------------------------------------ */
  
}
