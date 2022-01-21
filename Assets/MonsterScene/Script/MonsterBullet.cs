using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletForce;

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletForce * Time.deltaTime);
        Destroy(gameObject, 10.0f);
    }

    // 추가 충돌 처리 필요
}
