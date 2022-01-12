using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun gun; //���� ����

    private float currentFireRate; //���� �ӵ� ���

    public GameObject bulletFactory; //�Ѿ�
    public Transform firePos; //�߻���ġ

    void Start()
    {
        gun = GameObject.Find("BasicWeapon").GetComponent<Gun>();
    }

    void Update()
    {
        GunFireRateCalc();
        Shoot();
    }

    private void GunFireRateCalc() // ����ӵ� ����
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void Shoot() // �߻�
    {
        if (Input.GetMouseButtonDown(0) && currentFireRate <= 0) //������, �ӵ��� 0���� �۰ų� �������
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePos.position;
            bullet.transform.forward = firePos.forward;

            currentFireRate += gun.fireRate;

            Destroy(bullet, gun.range); //1.0f = 1�ʵڿ� ���� = ��Ÿ� Ȱ��
        }

    }
}
