using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // �÷��̾� �⺻ �ɷ�ġ
    [SerializeField]
    private float hp = 100;
    [SerializeField]
    private float damage = 10;
    [SerializeField]
    private float shootRate = 0.5f;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float range = 0.5f;
    [SerializeField]
    private float defence = 0;
    [SerializeField]
    private float critical = 10;

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
}

