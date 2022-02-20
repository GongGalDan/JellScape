using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : InheritSingleton<GameManager>
{
    ScenesManager sm;

    // º¸½ºÀü
    public int numOfCollectedKeys;
    public int bossSceneLife;

    protected override void Awake()
    {
        base.Awake();
        var obj = FindObjectsOfType<GameManager>();

        if (obj.Length == 1) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);

        sm = GameObject.Find("SceneManager").GetComponent<ScenesManager>();
    }

    protected override void Start()
    {
        numOfCollectedKeys = 0;
        bossSceneLife = 3;
    }

    protected override void Update()
    {
        if (bossSceneLife == 0)
        {
            sm.OnPlayerDead();
            bossSceneLife = 3;
        }
    }
}