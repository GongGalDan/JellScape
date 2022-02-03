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

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateItem();
        removeItem();
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
                    
                Debug.Log("아폴로");
                currentItems.Add(itemlist[0]);
                Debug.Log("아폴로를 추가하였습니다.");
                Debug.Log("아이템의 개수가 증가하였습니다.");
                Destroy(other.gameObject);
                Debug.Log("필드에서 삭제 됩니다.");
            }


            else if(other.CompareTag("Stick"))
            {
                if (currentItems.Count == 2)
                {
                Debug.Log("더이상 먹을 수 없습니다.");
                return;
                }
                Debug.Log("스틱");
                currentItems.Add(itemlist[1]);
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
                swap();
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
