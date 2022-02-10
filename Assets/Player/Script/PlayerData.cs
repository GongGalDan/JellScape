using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // �÷��̾� �⺻ �ɷ�ġ
    [SerializeField]
    public float hp = 100;
    [SerializeField]
    public float damage = 10;
    [SerializeField]
    public float shootRate = 0.5f;
    [SerializeField]
    public float speed = 3;
    [SerializeField]
    public float range = 0.5f;
    [SerializeField]
    public float defence = 0;
    [SerializeField]
    public float critical = 10;

    // �÷��̾� �߰� �ɷ�
    // S Rank
    public bool invincible;
    public bool headShot;
    public bool bombJelly;
    // A Rank
    public bool hotJelly;
    public bool frozenJelly;
    public bool poisonJelly;
    public bool sparkJelly;
    // B Rank
    public bool frontJelly;
    public bool sideJelly;
    public int addDamage;
    public int addShootRate;
    public int addRange;
    public int addCritical;
    // C Rank
    public int addHp;
    public int addDefence;
    public int addSpeed;
    // �Ӽ� �ɷ��� �ѹ��� ���� �� �ֵ���
    // �÷��̾��� �������� �Ӽ��� ������ �ִ��� 
    public bool isElementPicked;
    // �̱�â���� �����ϴ� ����
    public int numSelectedAbilities;


    public List<Ability> abilities = new List<Ability>();

    private void Start()
    {
        UpdatePlayerData();
    }

    // �÷��̾� �ɷ�ġ ������Ʈ
    public void UpdatePlayerData()
    {
        hp = 100 + (addHp * 20);
        damage = 10 + (addDamage * 10);
        shootRate = 0.5f + (addShootRate * 0.1f);
        speed = 3 + (addSpeed * 1);
        range = 0.5f + (addRange * 0.2f);
        defence = 0 + (addDefence * 50);
        critical = 10 + (addCritical * 20);
    }

    // �÷��̾� �ɷ�ġ �Ѱ��ֱ�
    public void SetPlayerData(float hp, float damage, float shootRate, float speed, float range
        , float defence, float critical)
    {
        hp = this.hp;
        damage = this.damage;
        shootRate = this.shootRate;
        speed = this.speed;
        range = this.range;
        defence = this.defence;
        critical = this.critical;
    }
}

