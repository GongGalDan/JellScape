using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigid;
    public float bulletspeed; //�Ѿ� �ӵ�

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * bulletspeed;
    }



}
