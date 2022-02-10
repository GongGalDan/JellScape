using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    public GameObject bulletPrefab; //�Ѿ��� ���
    public TrailRenderer basicEffect; //�Ѿ� ����Ʈ
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

    // ���� �Ӽ� �ɷµ�� �ٲ��ֱ�
    /*
    void ChangeBullet()
    {
        TrailRenderer swap;
        if(Input.GetKeyDown("1"))
        {
            basicEffect.startColor = Color.red;
        }

        if (Input.GetKeyDown("2"))
        {
            basicEffect.startColor = Color.blue;
        }

        if (Input.GetKeyDown("3"))
        {
            basicEffect.startColor = Color.green;
        }

        if (Input.GetKeyDown("4"))
        {
            basicEffect.startColor = Color.yellow;
        }

        if (Input.GetKeyDown("5"))
        {
            basicEffect.startColor = Color.black;
        }

    }*/

}
