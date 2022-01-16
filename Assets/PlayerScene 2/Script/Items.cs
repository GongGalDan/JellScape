using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<GameObject> items; //item object를 넣고
    public List<GameObject> currentItems; //현재 입수한 아이템이 표시되도록 add해준다
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
            Debug.Log("아폴로");
            currentItems.Add(apolo);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("stick"))
        {
            Debug.Log("스틱");
            currentItems.Add(stick);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if(other.CompareTag("capsule"))
        {
            Debug.Log("캡슐");
            currentItems.Add(capsule);
            player.currentItem++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("icesuit"))
        {
            Debug.Log("얼음");
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
