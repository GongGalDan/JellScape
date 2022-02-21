﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public Transform slotsParent;
    //스위칭
    public List<GameObject> itemlist; //item object를 넣고
    public List<GameObject> currentItems = new List<GameObject>();//현재 입수한 아이템이 표시되도록 add해준다

    public float switchDelay;
    bool isSwitching;

    Player player;
    UsableItem usableItem;
    Animator animator;
    public Slot4[] slots;

    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        //slots = slotsParent.GetComponentsInChildren<Slot4>();
        usableItem = GetComponentInChildren<UsableItem>();
    }

    void Update()
    {
        UpdateItem();
        removeItem();
    }

    //아이템 능력치를 더해주는 함수
    void addAbility(GameObject currentItem) 
    {
        player.damage += currentItem.GetComponent<UsableItem>()._addDamage;
        player.shootRate -= currentItem.GetComponent<UsableItem>()._addShootRate;
        player.range += currentItem.GetComponent<UsableItem>()._addRange;
        player.defence += currentItem.GetComponent<UsableItem>()._addDefence;
    }

    //아이템 능력치를 빼주는 함수
    void deleteAbility(GameObject currentItem)
    {
        player.damage -= currentItem.GetComponent<UsableItem>()._addDamage;
        player.shootRate += currentItem.GetComponent<UsableItem>()._addShootRate;
        player.range -= currentItem.GetComponent<UsableItem>()._addRange;
        player.defence -= currentItem.GetComponent<UsableItem>()._addDefence;
    }

    //아이템 획득
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apolo"))
        {
            if (currentItems.Count == 2)
            {
                Debug.Log("더이상 먹을 수 없습니다.");
                return;
            }

            currentItems.Add(itemlist[0]);
            //slots[0].image.sprite = usableItem.itemImage;

            if (currentItems.Count == 1)
            {
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);
            }

            Destroy(other.gameObject);

        }

        else if(other.CompareTag("Stick"))
        {
            if (currentItems.Count == 2)
            {
                Debug.Log("더이상 먹을 수 없습니다.");
                return;
            }

            currentItems.Add(itemlist[1]);
            //slots[0].image.sprite = usableItem.itemImage;

            if (currentItems.Count == 1)
             {
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);
             }

             Destroy(other.gameObject);
        }

        else if (other.CompareTag("Icesuit"))
        {
            if(currentItems.Count == 2)
            {
                Debug.Log("더이상 먹을 수 없습니다.");
                return;
            }
            Debug.Log("얼음");

            currentItems.Add(itemlist[2]);
            //slots[0].image.sprite = usableItem.itemImage;

            if (currentItems.Count == 1)
            {
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);
            }

                Destroy(other.gameObject);
        }
    }

    //아이템 사용
     void UpdateItem()
    {
        if (currentItems.Count == 0)
            return;

        currentItems[0].SetActive(true);


        if (currentItems.Count == 2)
        {
            currentItems[1].SetActive(false);
        }

        if(Input.GetAxis("Mouse ScrollWheel") !=0 && !isSwitching) //isSwitching이 false일 때
        {
            if (currentItems.Count != 2)
                return;
            else
            {
                animator.SetTrigger("doSwap");
                deleteAbility(currentItems[0]);
                swap();
                addAbility(currentItems[0]);
                StartCoroutine(SwitchDelay());
            }
        }
    }

    //아이템 교체
    void swap()
    {
        GameObject swpItm;
        swpItm = currentItems[0];
        currentItems[0] = currentItems[1];
        currentItems[1] = swpItm;
    }

    //아이템 제거
    void removeItem()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentItems[0].SetActive(false); //끄고
            deleteAbility(currentItems[0]);//능력치 삭제
            currentItems.Remove(currentItems[0]);//지운다.
            addAbility(currentItems[0]);//가지고 있던 아이템이 0번째가 되서 능력치를 더해준다.
        }
    }

    IEnumerator SwitchDelay()
    {
        isSwitching = true;
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }
}
