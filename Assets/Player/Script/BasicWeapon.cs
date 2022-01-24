using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player2 player;
    public GameObject bulletPrefab; //총알의 모양
    public Transform bulletPos; //총알이 발사되는 위치
    public float delay;

    private float shootReady; //연사속도계산
    private void Start()
    {
        player = GetComponentInParent<Player2>();
    }

    private void Update()
    {
        BulletShootReady();
        Shoot();
    }

    void BulletShootReady()
    {
        if (shootReady < 0)
            shootReady += Time.deltaTime;
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && shootReady >=0 ) //마우스0 = 좌클릭을 누르면
        {
            GameObject bullet = Instantiate(bulletPrefab); //bullet은 prefab모양으로
            bullet.transform.position = bulletPos.position; //bullotpos의 위치에서
            bullet.transform.forward = bulletPos.forward; //bulletpos의 forward로 나아간다

            shootReady -= player.currentShootRate; //딜레이시간

            Destroy(bullet, player.currentRange);
        }
    }

}
