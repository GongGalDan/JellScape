using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    public GameObject bulletPrefab; //총알의 모양
    public TrailRenderer basicEffect; //총알 이펙트
    public Transform bulletPos; //총알이 발사되는 위치
    Animator animator;

    private float shootReady; //연사속도계산

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
            shootReady += player.shootRate; //딜레이시간
            //yield return new WaitForSeconds(0.05f);
            animator.SetTrigger("doThrow");

            yield return new WaitForSeconds(0.3f);
            GameObject bullet = Instantiate(bulletPrefab); //bullet은 prefab모양으로
            bullet.transform.position = bulletPos.position; //bullotpos의 위치에서
            bullet.transform.forward = bulletPos.forward; //bulletpos의 forward로 나아간다

            Destroy(bullet, player.range);
        }
    }

    // 뽑은 속성 능력들로 바꿔주기
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
