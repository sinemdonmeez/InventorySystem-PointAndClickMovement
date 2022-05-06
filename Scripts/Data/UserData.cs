using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    /* ------------------------------------------ */

    public static Dictionary<Item,int> Inventory = new Dictionary<Item, int>();
    public static Dictionary<Item.ItemType, int> Currency = new Dictionary<Item.ItemType, int>();

    /* ------------------------------------------ */

    public static void CurrencyUpdate(Item.ItemType type,int amount) 
    {
        if (Currency.ContainsKey(type))
        {
            Currency[type] += amount;
        }
        else 
        {
            Currency.Add(type, amount);
        }

        UIManager.instance.InGameGroup.UpdateCurrencyUI(type);
    }

    /* ------------------------------------------ */

}
