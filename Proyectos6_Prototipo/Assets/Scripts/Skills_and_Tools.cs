using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills_and_Tools : MonoBehaviour
{
    //static Skills_and_Tools instance;

    //public static Skills_and_Tools Instance
    //{
    //    get => instance;
    //}

    //private void Awake()
    //{
    //    instance = this;
    //}

    bool doubleJump;
    bool hook;

    public bool hasDoubleJump()
    {
        return doubleJump;
    }

    public void CatchDJ()
    {
        if (!doubleJump)
        {
            doubleJump = true;
        }
    }

    public bool hasHooK()
    {
        return hook;
    }

    public void CatchHook()
    {
        if (!hook)
        {
            hook = true;
        }
    }
}
