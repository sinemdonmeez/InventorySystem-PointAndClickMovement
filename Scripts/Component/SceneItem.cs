using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItem : MonoBehaviour
{
    /* ------------------------------------------ */

    public Item Item;

    /* ------------------------------------------ */

    private void OnMouseDown()
    {
        GameManager.ClickedItem = this.gameObject;
    }
    private void Awake()
    {
        GameManager.SceneItems.Add(this);
    }
    private void OnDisable()
    {
        if (GameManager.SceneItems.Contains(this))
            GameManager.SceneItems.Remove(this);
    }

    /* ------------------------------------------ */

}
