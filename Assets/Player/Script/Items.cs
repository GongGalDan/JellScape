using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //����Ī
    public List<GameObject> itemlist; //item object�� �ְ�
    public List<GameObject> currentItems = new List<GameObject>();//���� �Լ��� �������� ǥ�õǵ��� add���ش�


    public float switchDelay;
    bool isSwitching;

    Player player;
    UsableItem usableItem;
    Animator animator;
    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        UpdateItem();
        removeItem();
    }


    void addAbility(GameObject currentItem) //addAbility�� �Ű����� ����.
    {
        //player�� ability�� GameObejct�� currentItem�� usableItem�� �ҷ��ͼ� ability�� ������
        player.damage += currentItem.GetComponent<UsableItem>()._addDamage;
        player.shootRate -= currentItem.GetComponent<UsableItem>()._addShootRate;
        player.range += currentItem.GetComponent<UsableItem>()._addRange;
        player.defence += currentItem.GetComponent<UsableItem>()._addDefence;
    }

    void deleteAbility(GameObject currentItem)
    {
        player.damage -= currentItem.GetComponent<UsableItem>()._addDamage;
        player.shootRate += currentItem.GetComponent<UsableItem>()._addShootRate;
        player.range -= currentItem.GetComponent<UsableItem>()._addRange;
        player.defence -= currentItem.GetComponent<UsableItem>()._addDefence;
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.CompareTag("Apolo"))
            {
                if (currentItems.Count == 2)
                {
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }

                currentItems.Add(itemlist[0]);

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
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }

                currentItems.Add(itemlist[1]);

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
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }
                Debug.Log("����");

                currentItems.Add(itemlist[2]);

                if (currentItems.Count == 1)
                {
                usableItem = currentItems[0].GetComponent<UsableItem>();
                addAbility(currentItems[0]);
                }

                Destroy(other.gameObject);
            }

        
    }

     void UpdateItem()
    {
        if (currentItems.Count == 0)
            return;

        currentItems[0].SetActive(true);


        if (currentItems.Count == 2)
        {
            currentItems[1].SetActive(false);
        }
        if(Input.GetAxis("Mouse ScrollWheel") !=0 && !isSwitching) //isSwitching�� false�� ��
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
            currentItems[0].SetActive(false); //����
            deleteAbility(currentItems[0]);//�ɷ�ġ ����
            currentItems.Remove(currentItems[0]);//�����.
            addAbility(currentItems[0]);//������ �ִ� �������� 0��°�� �Ǽ� �ɷ�ġ�� �����ش�.
        }
    }

    IEnumerator SwitchDelay()
    {
        isSwitching = true;
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }
}
