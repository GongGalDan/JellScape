using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : InheritSingleton<GameManager>
{
    // º¸½ºÀü
    public int numOfCollectedKeys;

    protected override void Awake()
    {
        base.Awake();
        var obj = FindObjectsOfType<GameManager>();

        if (obj.Length == 1) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);
    }

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        
    }
}