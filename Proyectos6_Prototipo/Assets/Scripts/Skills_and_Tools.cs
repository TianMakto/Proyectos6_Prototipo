using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills_and_Tools : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

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
