using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun gun; //���� ����
    public float bulletspeed; //�Ѿ� �ӵ�

    private float currentFireRate; //���� �ӵ� ���


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

    private void GunFireRateCalc() // ����ӵ� ����
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime; //
    }

    private void Shoot() // �߻�
    {
        if (Input.GetMouseButton(0) && currentFireRate <= 0) //������, �ӵ��� 0���� �۰ų� �������
        {
            GameObject intantBullet = Instantiate(bullet, firePos.position, firePos.rotation); //instantiate �ν��Ͻ�ȭ (����, ��ġ, ����)
            Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = firePos.forward * Time.deltaTime * bulletspeed;

            Destroy(gameObject, 3); 
            Debug.Log("�Ѿ� �߻���");
        }
    }
}
