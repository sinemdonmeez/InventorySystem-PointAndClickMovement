using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    /* ------------------------------------------ */

    public static SlotManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<SlotManager>();

            return _instance;
        }
    }
    static SlotManager _instance;

    /* ------------------------------------------ */

    public Dictionary<Item, SlotHover> Slots = new Dictionary<Item, SlotHover>();

    public GameObject SlotItemPrefab;

    public GameObject SlotPrefab;

    public GameObject SlotPrefabParent;

    /* ------------------------------------------ */

    SlotHover _slotHover;

    SlotItem _slotItem;

    /* ------------------------------------------ */

    private void Awake()
    {
        _slotHover = SlotPrefab.GetComponent<SlotHover>();
        _slotItem = SlotItemPrefab.GetComponent<SlotItem>();
    }

    /* ------------------------------------------ */

    public void AddItem(Item item)
    {
        if (Slots.ContainsKey(item))
        {
            UserData.Inventory[item]++;
            Slots[item].GetComponentInChildren<SlotItem>().UpdateUI(item);

        }
        else
        {
            _slotHover.Item = item;
            GameObject parent = Instantiate(SlotPrefab, SlotPrefabParent.transform);
            Slots.Add(item, parent.gameObject.GetComponent<SlotHover>());
            _slotItem._item = item;

            GameObject go = Instantiate(SlotItemPrefab, parent.transform);
            UserData.Inventory.Add(item, 1);
            go.GetComponent<SlotItem>().UpdateUI(item);

        }
    }

    /* ------------------------------------------ */

}
