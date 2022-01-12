using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun gun; //현재 무기

    private float currentFireRate; //연사 속도 계산

    public GameObject bulletFactory; //총알
    public Transform firePos; //발사위치

    void Start()
    {
        gun = GameObject.Find("BasicWeapon").GetComponent<Gun>();
    }

    void Update()
    {
        GunFireRateCalc();
        Shoot();
    }

    private void GunFireRateCalc() // 연사속도 재계산
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void Shoot() // 발사
    {
        if (Input.GetMouseButtonDown(0) && currentFireRate <= 0) //누르고, 속도가 0보다 작거나 같을경우
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePos.position;
            bullet.transform.forward = firePos.forward;

            currentFireRate += gun.fireRate;

            Destroy(bullet, gun.range); //1.0f = 1초뒤에 삭제 = 사거리 활용
        }

    }
}
