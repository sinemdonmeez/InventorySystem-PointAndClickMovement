using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    /* ------------------------------------------ */

    public Item Item;

    Image _image;

    Color32 Default = new Color32(48, 67, 67, 255);
    Color32 Hover = new Color32(80,97,97,255);

    /* ------------------------------------------ */

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = Hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = Default;
    }

    /* ------------------------------------------ */

}
