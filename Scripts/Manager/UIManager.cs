using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /* ------------------------------------------ */

    public static UIManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<UIManager>();

            return _instance;
        }
    }
    static UIManager _instance;

    /* ------------------------------------------ */

    public UIInventoryGroup InventoryGroup;
    public UIInGameGroup InGameGroup;

    /* ------------------------------------------ */

}
