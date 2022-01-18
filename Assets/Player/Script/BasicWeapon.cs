using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    public float shootrate; //연사 속도
    public float range; //공격 범위
    public GameObject bulletPrefab; //총알의 모양
    public Transform bulletPos; //총알이 발사되는 위치

    private float shootReady; //연사속도계산

    private void Update()
    {
        BulletShootReady();
        Shoot();
    }

    void BulletShootReady()
    {
        if (shootReady > 0)
            shootReady -= Time.deltaTime;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shootReady <=0 ) //마우스0 = 좌클릭을 누르면
        {
            GameObject bullet = Instantiate(bulletPrefab); //bullet은 prefab모양으로
            bullet.transform.position = bulletPos.position; //bullotpos의 위치에서
            bullet.transform.forward = bulletPos.forward; //bulletpos의 forward로 나아간다

            shootReady += shootrate;

            Destroy(bullet, range);
        }
    }

}
