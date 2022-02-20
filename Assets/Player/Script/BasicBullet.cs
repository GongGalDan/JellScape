using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    PlayerData playerData;
    Rigidbody rigidbody;

    [SerializeField] Material trailColor; //trail 색상 변경
    public Material bulletColor; //bullet 색상 변경

    float bulletSpeed = 20f;

    void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulletSpeed;//속도 = 방향 * 속력
        trailColor = GetComponent<TrailRenderer>().material;
    }

    private void Update()
    {
        ChangeBullet();
    }

    //충돌 처리
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Chest")
        {
            Destroy(gameObject);
        }
    }

    // 뽑은 속성 능력들로 바꿔주기
    void ChangeBullet()
    {
        if (playerData.hotJelly == true)
        {
            //빨강
            bulletColor.color = new Color(250 / 255f, 50 / 255f, 70 / 255f);
            trailColor.color = new Color(145 / 255f, 47 / 255f, 60 / 255f);
        }

        if (playerData.frozenJelly == true)
        {
            //파랑
            bulletColor.color = new Color(38 / 255f, 208 / 255f, 255 / 255f);
            trailColor.color = new Color(47 / 255f, 88 / 255f, 145 / 255f);
        }

        if (playerData.poisonJelly == true)
        {
            //초록
            bulletColor.color = new Color(38 / 255f, 255 / 255f, 45 / 255f);
            trailColor.color = new Color(78 / 255f, 148 / 255f, 46 / 255f);
        }

        if (playerData.sparkJelly == true)
        {
            //노랑
            bulletColor.color = new Color(226 / 255f, 255 / 255f, 38 / 255f);
            trailColor.color = new Color(148 / 255f, 143 / 255f, 46 / 255f);
        }

        if (playerData.bombJelly == true)
        {
            //검정
            bulletColor.color = new Color(30 / 255f, 31 / 255f, 30 / 255f);
            trailColor.color = new Color(0 / 255f, 0 / 255f, 0 / 255f);
        }

        else
        {
            //분홍
            bulletColor.color = new Color(245 / 255f, 54 / 255f, 178 / 255f);
            trailColor.color = new Color(245 / 255f, 54 / 255f, 121 / 255f);
        }
    }

}
