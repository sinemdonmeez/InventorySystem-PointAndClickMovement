using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInGameGroup : MonoBehaviour
{
    /* ------------------------------------------ */

    public TextMeshProUGUI TxtCoin, TxtBlueGem, TxtPurpleGem;

    /* ------------------------------------------ */

    public void FunInventory() 
    {
        if (UIManager.instance.InventoryGroup.gameObject.activeSelf)
        {
            GameManager.instance.ResumeGame();
        }
        else 
        {
            GameManager.instance.PauseGame();
        }
        UIManager.instance.InventoryGroup.gameObject.SetActive(!UIManager.instance.InventoryGroup.gameObject.activeSelf);
    }

    public void UpdateCurrencyUI(Item.ItemType type)
    {
        if(type== Item.ItemType.Coin)
            TxtCoin.text = UserData.Currency[type].ToString();
        if (type == Item.ItemType.BlueGem)
            TxtBlueGem.text = UserData.Currency[type].ToString();
        if (type == Item.ItemType.PurpleGem)
            TxtPurpleGem.text = UserData.Currency[type].ToString();
    }

    /* ------------------------------------------ */
}
