using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<GameObject> items; //item object�� �ְ�
    public List<GameObject> currentItems; //���� �Լ��� �������� ǥ�õǵ��� add���ش�
    GameObject apolo;
    GameObject stick;
    GameObject capsule;
    GameObject icesuit;

    Player2 player;

    private void Start()
    {
        player = GetComponent<Player2>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.currentItem == player.maxItem)
            return;

        else if (other.CompareTag("Apolo"))
        {
            Debug.Log("������");
            currentItems.Add(apolo);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("stick"))
        {
            Debug.Log("��ƽ");
            currentItems.Add(stick);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if(other.CompareTag("capsule"))
        {
            Debug.Log("ĸ��");
            currentItems.Add(capsule);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("icesuit"))
        {
            Debug.Log("����");
            currentItems.Add(icesuit);
            player.currentItem++;
            Destroy(gameObject);
        }
    }

    void UpdateItem()
    {
        currentItems[0].SetActive(true);
        if(Input.GetAxis("Mouse ScrollWheel") !=0 )
        {
            if (currentItems.Count != 2)
                return;
            GameObject  swpItm;
            swpItm = currentItems[0];
            currentItems[0] = currentItems[1];
            currentItems[1] = swpItm;
        }
    }

    
}
