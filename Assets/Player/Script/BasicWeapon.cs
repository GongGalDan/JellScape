using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player2 player;
    public GameObject bulletPrefab; //�Ѿ��� ���
    public Transform bulletPos; //�Ѿ��� �߻�Ǵ� ��ġ

    private float shootReady; //����ӵ����
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
        if (shootReady > 0)
            shootReady -= Time.deltaTime;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shootReady <=0 ) //���콺0 = ��Ŭ���� ������
        {
            GameObject bullet = Instantiate(bulletPrefab); //bullet�� prefab�������
            bullet.transform.position = bulletPos.position; //bullotpos�� ��ġ����
            bullet.transform.forward = bulletPos.forward; //bulletpos�� forward�� ���ư���

            shootReady += player.shootrate;

            Destroy(bullet, player.range);
        }
    }

}
