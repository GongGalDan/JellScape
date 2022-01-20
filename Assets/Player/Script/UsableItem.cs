using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    public BoxCollider meleeArea;
    public CapsuleCollider SpecialArea;
    public TrailRenderer trailEffect;


    float useDelay=0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;

    Player2 player; //ü��, speed �̵��ӵ�
    Items items;
    Animator animator;


    private void Start()
    {
        player = GetComponent<Player2>();
        items = GetComponent<Items>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
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


        if(Input.GetMouseButtonDown(1) && items.currentItems.Count != 0 && useDelay <=0)
        {
           if(items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("�����η� ���� ��");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                useDelay += apoloDelay;
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("��ƽ���� ���� ��");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                useDelay += stickDelay;
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("ĸ���� ���� ��");
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[3])
            {
                Debug.Log("���� �������� ��� ��");
            }
        }

    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;

    }
}
