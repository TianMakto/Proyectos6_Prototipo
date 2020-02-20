using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeOfLevel
{
    Underground,
    Surface
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] typeOfLevel levelType;
    private static LevelManager instance;

    public static LevelManager Instance
    {
        get => instance;
    }
    
    public typeOfLevel LevelType
    {
        get => levelType;
    }

    private void Awake()
    {
        instance = this;
    }
}
