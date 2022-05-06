using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SlotItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /* ------------------------------------------ */

    public Image MainIcon;

    public GameObject Explanation;

    public TextMeshProUGUI TxtExplanation;

    public TextMeshProUGUI TxtItemAmount;

    public Item _item;

    /* ------------------------------------------ */

    void Start()
    {
        Explanation.SetActive(false);
        MainIcon.sprite = _item.ItemImage;
        TxtExplanation.text = _item.ItemDescription;
    }

    /* ------------------------------------------ */

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Explanation.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Explanation.SetActive(false);
        
    }

    /* ------------------------------------------ */

    public void UseItem() 
    {
        if (UserData.Inventory[_item] > 1)
        {
            UserData.Inventory[_item]--;
            UpdateUI(_item);
            //SlotManager.instance.Slots.Remove(_item);

        }
        else
        {
            Destroy(gameObject);
            UserData.Inventory.Remove(_item);
            Destroy(SlotManager.instance.Slots[_item].gameObject);
            SlotManager.instance.Slots.Remove(_item);
        }
        UserData.CurrencyUpdate(_item.Type, _item.Amount);
        
        Debug.Log(_item.ItemName + " has been used.");
    }

    public void DeleteItem()
    {
        if (UserData.Inventory[_item] > 1)
        {
            UserData.Inventory[_item]--;

            UpdateUI(_item);
            //SlotManager.instance.Slots.Remove(_item);

        }
        else
        {
            Destroy(gameObject);
            UserData.Inventory.Remove(_item);
            Destroy(SlotManager.instance.Slots[_item].gameObject);
            SlotManager.instance.Slots.Remove(_item);
        }
        Debug.Log(_item.ItemName + " has been deleted");
    }

    /* ------------------------------------------ */

    public void UpdateUI(Item item) 
    {
        TxtItemAmount.text = UserData.Inventory[item].ToString();
    }

    /* ------------------------------------------ */

}
