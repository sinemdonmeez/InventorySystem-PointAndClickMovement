using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Identity
{
    /* ------------------------------------------ */

    public RuntimeAnimatorController Controller;

    public bool IsRunning;

    /* ------------------------------------------ */

    private void Awake()
    {
        ComponentManager.instance.Idle.Add(identity, this);
    }

    private void OnDestroy()
    {
        try
        {
            if (ComponentManager.instance.Idle.ContainsKey(identity))
                ComponentManager.instance.Idle.Remove(identity);
        }
        catch { }

    }

    /* ------------------------------------------ */

    public override void Process()
    {
        Debug.Log("duruyorum");
    }
    /* ------------------------------------------ */

    public void ChangeAnimation()
    {
        identity.Animator.runtimeAnimatorController = Controller;
    }

    /* ------------------------------------------ */

}
