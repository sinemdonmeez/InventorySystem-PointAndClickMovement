using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* ------------------------------------------ */

    public static GameObject ClickedItem;

    public static List<SceneItem> SceneItems=new List<SceneItem>();

    /* ------------------------------------------ */

    GameObject _player;

    GameObject _clickedItem;

    CharacterStateManager _manager;

    /* ------------------------------------------ */

    public static GameManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }
    static GameManager _instance;

    /* ------------------------------------------ */

    private void Awake()
    {
        _player = FindObjectOfType<Character>().gameObject;
        _manager = _player.GetComponent<CharacterStateManager>();
    }

    private void Update()
    {
        CheckItem();
    }

    /* ------------------------------------------ */

    public void PauseGame() 
    {
        Time.timeScale = 0;
        _manager.enabled = false;
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
        _manager.enabled = true;
    }

    void CheckItem() 
    {
        if (ClickedItem) 
        {
            _clickedItem = ClickedItem;
            SlotManager.instance.AddItem(ClickedItem.GetComponent<SceneItem>().Item);
            Debug.Log(Vector3.Distance(ClickedItem.transform.position, _player.transform.position));
            ClickedItem = null;
            
        }
        if (_clickedItem) 
        {
            if (Vector3.Distance(_clickedItem.transform.position, _player.transform.position) < 1f)
                Destroy(_clickedItem);
        }
    }
    /* ------------------------------------------ */

}
