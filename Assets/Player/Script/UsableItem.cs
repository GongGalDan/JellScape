using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    public float Damage;
    public BoxCollider meleeArea;
    public CapsuleCollider SpecialArea;

    public float _addDamage;
    public float _addShootRate;
    public float _addRange;
    public float _addDefence;

    float useDelay=0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;

    Player2 player; //ü��, speed �̵��ӵ�
    Items items;
    Animator animator;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        items = GameObject.FindGameObjectWithTag("Player").GetComponent<Items>();
        animator = GetComponentInParent<Animator>();
        meleeArea.enabled = false;
    }


    void Update()
    {
        Use();
        UseDelay();
    }

    void UseDelay()
    {
        if (useDelay > 0)
        {
            useDelay -= Time.deltaTime;
        }
    }


    void Use()
    {
        if (Input.GetMouseButtonDown(1) && items.currentItems.Count == 0)
        {
            Debug.Log("ȹ���� �������� �����ϴ�.");
            return;
        }


        if (Input.GetMouseButtonDown(1) && items.currentItems.Count != 0 && useDelay <= 0)
        {

            if (items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("�����η� ���� ��");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                animator.SetTrigger("doAttack");
                useDelay += apoloDelay;
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("��ƽ���� ���� ��");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                animator.SetTrigger("doAttack");
                useDelay += stickDelay;
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("���� �������� ��� ��");
                animator.SetTrigger("doDie");
            }
        }

    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.4f);
        meleeArea.enabled = true;
        Debug.Log("���ݽ���");

        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = false;
        Debug.Log("���ݳ�");

        yield return new WaitForSeconds(0.5f);
    }
}
