using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : InheritSingleton<GameManager>
{
    public List<Ability> abilities = new List<Ability>();

    // �÷��̾� �߰� �ɷ�
    // S Rank
    protected bool invincible;
    protected bool headShot;
    protected bool bombJelly;
    // A Rank
    protected bool hotJelly;
    protected bool freezeJelly;
    protected bool poisonJelly;
    protected bool sparkJelly;
    // B Rank
    protected bool frontJelly;
    protected bool sideJelly;
    protected int damage;
    protected int attackSpeed;
    protected int range;
    protected int critical;
    // C Rank
    protected int hp;
    protected int defence;
    protected int speed;

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
