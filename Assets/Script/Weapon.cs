using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range }; //둔기, 총(기본)
    public Type type;
    public int damage; //무기 데미지
    public float rate; //무기 속도
    public float range; //무기 사거리

    public BoxCollider meleeArea; //둔기 범위
    public TrailRenderer trailEffect; //이펙트

    public Transform bulletPos; //총알 위치
    public GameObject bullet; //총알
    public float bulletspeed; //총알 속도

    public void Use()
    {
        if (type == Type.Melee)
        {
            StartCoroutine("Swing");
        }
        else if(type == Type.Range)
        {
            StartCoroutine("Shot");
        }
    }

    IEnumerator Swing()
    {
        //1
        yield return new WaitForSeconds(rate); //rate만큼 대기
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        //2
        yield return new WaitForSeconds(rate); //rate만큼 시간이 지나면
        meleeArea.enabled = false; // 공격 멈춤
        //3
        yield return new WaitForSeconds(rate);
        trailEffect.enabled = false; //이펙트 멈춤

    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * bulletspeed;

        
    }

}

