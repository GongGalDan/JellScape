using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    PlayerData playerData;
    public GameObject bulletPrefab; //총알의 모양
    public Transform baiscPos; //총알이 발사되는 위치
    public Transform frontPos; //frontJelly 위치
    public Transform sidePos1; //sideJEly
    public Transform sidePos2;
    Animator animator;

    private float shootReady; //연사속도계산

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
            shootReady += player.shootRate; //딜레이시간
            //yield return new WaitForSeconds(0.05f);
            animator.SetTrigger("doThrow");

            yield return new WaitForSeconds(0.3f);
            GameObject bullet = Instantiate(bulletPrefab); //bullet은 prefab모양으로
            bullet.transform.position = baiscPos.position; //bullotpos의 위치에서
            bullet.transform.forward = baiscPos.forward; //bulletpos의 forward로 나아간다

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
