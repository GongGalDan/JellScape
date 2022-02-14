using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : InheritSingleton<ScenesManager>
{
    GameManager gm;

    protected override void Awake()
    {
        base.Awake();
        var obj = FindObjectsOfType<ScenesManager>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (obj.Length == 1) DontDestroyOnLoad(gameObject); 
        else Destroy(gameObject);
    }

    protected override void Start(){}

    protected override void Update()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("RandomAbility");
            }
        }
        if (SceneManager.GetActiveScene().name == "RandomAbility")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Boss");
            }
        }
        if (SceneManager.GetActiveScene().name == "Boss")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Monsters");
            }
        }
        if (SceneManager.GetActiveScene().name == "Monsters")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void ToEnding()
    {
        if (gm.numOfCollectedKeys < 4) return;
        
        SceneManager.LoadScene("Ending");
    }
}
