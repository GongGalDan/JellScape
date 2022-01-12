using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun gun; //현재 무기
    public float bulletspeed; //총알 속도

    private float currentFireRate; //연사 속도 계산


    public GameObject bullet;
    public Transform firePos;

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
            currentFireRate -= Time.deltaTime; //
    }

    private void Shoot() // 발사
    {
        if (Input.GetMouseButton(0) && currentFireRate <= 0) //누르고, 속도가 0보다 작거나 같을경우
        {
            GameObject intantBullet = Instantiate(bullet, firePos.position, firePos.rotation); //instantiate 인스턴스화 (변수, 위치, 각도)
            Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = firePos.forward * Time.deltaTime * bulletspeed;

            Destroy(gameObject, 3); 
            Debug.Log("총알 발사함");
        }
    }
}
