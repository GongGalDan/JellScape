using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeaponController : MonoBehaviour
{
    [SerializeField]
    private BasicWeapon currentGun;

    private float currentFireRate;


    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime; //
    }
}
