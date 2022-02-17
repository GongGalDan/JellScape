using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    public float Damage;
    public BoxCollider meleeArea;

    public string itemName;
    public Sprite itemImage; //아이템 이미지

    //아이템 추가 능력 수치
    public float _addDamage;
    public float _addShootRate;
    public float _addRange;
    public float _addDefence;

    //딜레이 시간
    float useDelay=0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;

    Player player; //체력, speed 이동속도
    Items items;
    Animator animator;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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


    //아이템 공격
    void Use()
    {
        if (Input.GetMouseButtonDown(1) && items.currentItems.Count == 0)
        {
            Debug.Log("획득한 아이템이 없습니다.");
            return;
        }

        if (Input.GetMouseButtonDown(1) && items.currentItems.Count != 0 && useDelay <= 0)
        {

            if (items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("아폴로로 공격 중");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                animator.SetTrigger("doAttack");
                useDelay += apoloDelay;
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("스틱으로 공격 중");
                StopCoroutine("Swing");
                StartCoroutine("Swing");
                animator.SetTrigger("doAttack");
                useDelay += stickDelay;
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("얼음 갑옷으로 방어 중");
                animator.SetTrigger("doDie");
            }
        }

    }

    //animation에 맞게 attack 설정
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        Debug.Log("공격시작");

        yield return new WaitForSeconds(0.01f);
        meleeArea.enabled = false;
        Debug.Log("공격끝");

        yield return new WaitForSeconds(0.5f);
    }
}
