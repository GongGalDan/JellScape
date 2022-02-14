using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    PlayerData playerData;
    public Material bulletColor;
    Rigidbody rigid;
    [SerializeField] Material trailColor;
    float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * bulletSpeed;//속도 = 방향 * 속력
        Material bulletColor;
        trailColor = GetComponent<TrailRenderer>().material;
    }

    private void Update()
    {
        ChangeBullet();
    }


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
            bulletColor.color = new Color(250 / 255f, 50 / 255f, 70 / 255f);
            trailColor.color = new Color(145 / 255f, 47 / 255f, 60 / 255f);
        }

        if (playerData.frozenJelly == true)
        {
            bulletColor.color = new Color(38 / 255f, 208 / 255f, 255 / 255f);
            trailColor.color = new Color(47 / 255f, 88 / 255f, 145 / 255f);
        }

        if (playerData.poisonJelly == true)
        {
            bulletColor.color = new Color(38 / 255f, 255 / 255f, 45 / 255f);
            trailColor.color = new Color(78 / 255f, 148 / 255f, 46 / 255f);
        }

        if (playerData.sparkJelly == true)
        {
            bulletColor.color = new Color(226 / 255f, 255 / 255f, 38 / 255f);
            trailColor.color = new Color(148 / 255f, 143 / 255f, 46 / 255f);
        }

        if (playerData.bombJelly == true)
        {
            bulletColor.color = new Color(30 / 255f, 31 / 255f, 30 / 255f);
            trailColor.color = Color.black;
        }
    }

}
