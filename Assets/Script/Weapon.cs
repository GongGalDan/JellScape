using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range }; //�б�, ��(�⺻)
    public Type type;
    public int damage; //���� ������
    public float rate; //���� �ӵ�
    public float range; //���� ��Ÿ�

    public BoxCollider meleeArea; //�б� ����
    public TrailRenderer trailEffect; //����Ʈ

    public Transform bulletPos; //�Ѿ� ��ġ
    public GameObject bullet; //�Ѿ�
    public float bulletspeed; //�Ѿ� �ӵ�

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
        yield return new WaitForSeconds(rate); //rate��ŭ ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        //2
        yield return new WaitForSeconds(rate); //rate��ŭ �ð��� ������
        meleeArea.enabled = false; // ���� ����
        //3
        yield return new WaitForSeconds(rate);
        trailEffect.enabled = false; //����Ʈ ����

    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * bulletspeed;

        
    }

}

