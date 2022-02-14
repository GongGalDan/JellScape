using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    PlayerData playerData;
    public GameObject bulletPrefab; //�Ѿ��� ���
    public Transform baiscPos; //�Ѿ��� �߻�Ǵ� ��ġ
    public Transform frontPos; //frontJelly ��ġ
    public Transform sidePos1; //sideJEly
    public Transform sidePos2;
    Animator animator;

    private float shootReady; //����ӵ����

    private void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
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
        if (Input.GetMouseButtonDown(0) && shootReady <= 0 && playerData.hp !=0)
        {
            shootReady += player.shootRate; //�����̽ð�
            //yield return new WaitForSeconds(0.05f);
            animator.SetTrigger("doThrow");

            yield return new WaitForSeconds(0.3f);
            GameObject bullet = Instantiate(bulletPrefab); //bullet�� prefab�������
            bullet.transform.position = baiscPos.position; //bullotpos�� ��ġ����
            bullet.transform.forward = baiscPos.forward; //bulletpos�� forward�� ���ư���

            if (playerData.frontJelly == true)
            {
                FrontJelly();
            }

            if(playerData.sideJelly ==true)
            {
                SideJelly1();
                SideJelly2();
            }

            Destroy(bullet, player.range);
        }
    }

    void FrontJelly()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = frontPos.position; 
        bullet.transform.forward = frontPos.forward;

        Destroy(bullet, player.range);
    }

    void SideJelly1()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = sidePos1.position;
        bullet.transform.forward = -sidePos1.right;

        Destroy(bullet, player.range);
    }

    void SideJelly2()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = sidePos2.position;
        bullet.transform.forward = sidePos2.right;

        Destroy(bullet, player.range);

    }

}
