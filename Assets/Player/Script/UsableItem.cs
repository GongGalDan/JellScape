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

    Player2 player; //체력, speed 이동속도
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
            Debug.Log("획득한 아이템이 없습니다.");
            return;
        }


        if(Input.GetMouseButtonDown(1) && items.currentItems.Count != 0 && useDelay <=0)
        {
           if(items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("아폴로로 공격 중");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                useDelay += apoloDelay;
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("스틱으로 공격 중");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                useDelay += stickDelay;
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("캡슐로 공격 중");
                animator.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[3])
            {
                Debug.Log("얼음 갑옷으로 방어 중");
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
