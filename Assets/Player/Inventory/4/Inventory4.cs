using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory4 : MonoBehaviour
{
    Slot4[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<Slot4>();
    }


    void UpdateItems()
    {
        if(slots[0] = null)
        {
            slots[0] = slots[1];
            slots[1] = null;
        }

    }


    void Swap()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(slots[1] = null )
            {
                return;
            }
        }
    }

}
