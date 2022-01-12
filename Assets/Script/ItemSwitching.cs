using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitching : MonoBehaviour
{
    public int selectWeapon = 0;

    void Start()
    {
        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }

        transform.GetChild(selectWeapon).gameObject.SetActive(true);
    }
}
