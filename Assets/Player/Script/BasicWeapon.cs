using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    public GameObject bulletPrefab; //�Ѿ��� ���
    public Transform bulletPos; //�Ѿ��� �߻�Ǵ� ��ġ
    Animator animator;

    private float shootReady; //����ӵ����

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        BulletShootReady();
        StartCoroutine("Shoot");
    }

    void BulletShootReady()
    {
        if (shootReady > 0)
            shootReady -= Time.deltaTime;
    }

    IEnumerator Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shootReady <= 0)
        {
            shootReady += player.shootRate; //�����̽ð�
            //yield return new WaitForSeconds(0.05f);
            animator.SetTrigger("doThrow");

            yield return new WaitForSeconds(0.3f);
            GameObject bullet = Instantiate(bulletPrefab); //bullet�� prefab�������
            bullet.transform.position = bulletPos.position; //bullotpos�� ��ġ����
            bullet.transform.forward = bulletPos.forward; //bulletpos�� forward�� ���ư���

            Destroy(bullet, player.range);
        }
    }

    

}
