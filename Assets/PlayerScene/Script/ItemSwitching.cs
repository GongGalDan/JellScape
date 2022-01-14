using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitching : MonoBehaviour
{
    public float switchDelay = 1f;
    public GameObject[] weapons;
    public bool[] hasWaepons;

    private int index = 0;
    public bool isSwitching = false;

    private void Start()
    {
        InitializeWeapon();
    }

    private void Update()
    {
        swap();
       
    }

    void swap()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !isSwitching) // 0이 아닐때 = 위로올리거나(양수) 밑으로 내릴때(음수) = 가만히 안있을때
        {
            //if (currentIItems.count != 2) //아이템개수가 2개가 아니면 = 2개면 실행한다
                return;//기능을 안한다

            Debug.Log("d");
            index++;
            if (index >= weapons.Length)
                index = 0;
            StartCoroutine(SwitchDelay(index));
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
        {
            index--;
            if (index < 0)
                index = weapons.Length - 1;
            StartCoroutine(SwitchDelay(index));
        }
    }



    private void InitializeWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        index = 0;
    }

    IEnumerator SwitchDelay(int newIndex)
    {
        isSwitching = true;
        SwitchWeapons(newIndex);
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }

    void SwitchWeapons(int newIndex)
    {
        for(int i=0; i<weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

       weapons[newIndex].SetActive(true);

    }
}
