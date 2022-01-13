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
        if (Input.GetAxis("Mouse ScrollWheel")>0 && !isSwitching)
        {
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
