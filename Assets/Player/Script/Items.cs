using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<GameObject> itemlist; //item object�� �ְ�
    public List<GameObject> currentItems = new List<GameObject>();//���� �Լ��� �������� ǥ�õǵ��� add���ش�

    ItemInfo itemifo;

    private void Start()
    {
        itemifo = GetComponent<ItemInfo>();
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
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }
                    
                Debug.Log("������");
                currentItems.Add(itemlist[0]);
                Debug.Log("�����θ� �߰��Ͽ����ϴ�.");
                Debug.Log("�������� ������ �����Ͽ����ϴ�.");
                Destroy(other.gameObject);
                Debug.Log("�ʵ忡�� ���� �˴ϴ�.");
            }


            else if(other.CompareTag("Stick"))
            {
                if (currentItems.Count == 2)
                {
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }
                Debug.Log("��ƽ");
                currentItems.Add(itemlist[1]);
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Capsule"))
            {
                if(currentItems.Count == 2)
                {
                Debug.Log("���̻� ���� �� �����ϴ�.");
                return;
                }
                Debug.Log("ĸ��");
                currentItems.Add(itemlist[2]);
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
                currentItems.Add(itemlist[3]);
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
        if(Input.GetAxis("Mouse ScrollWheel") !=0 )
        {
            if (currentItems.Count != 2)
                return;
            else swap();
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
            currentItems.Remove(currentItems[0]);//�����.
        }
    }
}
