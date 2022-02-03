using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //스위칭
    public List<GameObject> itemlist; //item object를 넣고
    public List<GameObject> currentItems = new List<GameObject>();//현재 입수한 아이템이 표시되도록 add해준다


    public float switchDelay;
    bool isSwitching;

    Player2 player;
    UsableItem usableItem;
    Animator animator;
    private void Start()
    {
        player = GetComponent<Player2>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        UpdateItem();
        removeItem();
    }


    void addAbility(GameObject currentItem) //addAbility의 매개변수 선언.
    {
        //player의 ability에 GameObejct인 currentItem에 usableItem을 불러와서 ability를 더해줌
        player.currentDamage += currentItem.GetComponent<UsableItem>()._addDamage;
        player.currentShootRate -= currentItem.GetComponent<UsableItem>()._addShootRate;
        player.currentRange += currentItem.GetComponent<UsableItem>()._addRange;
        player.currentDefence += currentItem.GetComponent<UsableItem>()._addDefence;
    }

    void deleteAbility(GameObject currentItem)
    {
        player.currentDamage -= currentItem.GetComponent<UsableItem>()._addDamage;
        player.currentShootRate += currentItem.GetComponent<UsableItem>()._addShootRate;
        player.currentRange -= currentItem.GetComponent<UsableItem>()._addRange;
        player.currentDefence -= currentItem.GetComponent<UsableItem>()._addDefence;
    }

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
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);

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
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);

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
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);

                Destroy(other.gameObject);
            }

        
    }

     void UpdateItem()
    {
        if (currentItems.Count == 0)
            return;

        currentItems[0].SetActive(true);



        if(currentItems.Count == 2)
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


    void swap()
    {
        GameObject swpItm;
        swpItm = currentItems[0];
        currentItems[0] = currentItems[1];
        currentItems[1] = swpItm;
    }


    void removeItem()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentItems[0].SetActive(false); //끄고
            currentItems.Remove(currentItems[0]);//지운다.
        }
    }

    IEnumerator SwitchDelay()
    {
        isSwitching = true;
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }
}
