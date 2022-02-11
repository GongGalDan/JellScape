using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    Player player;
    PlayerData playerData;
    public GameObject bulletPrefab; //총알의 모양
    public Transform bulletPos; //총알이 발사되는 위치
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
            bullet.transform.position = bulletPos.position; //bullotpos의 위치에서
            bullet.transform.forward = bulletPos.forward; //bulletpos의 forward로 나아간다

            Destroy(bullet, player.range);
        }
    }

}
