using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;
    Attack equipWeapon;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        equipWeapon = GetComponent<Attack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            currentHp -= player.currentDamage;
            Debug.Log(currentHp);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Apolo"))
        {
            currentHp -= equipWeapon.damage; //아폴로의 데미지
            Debug.Log(currentHp + "아폴로에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= equipWeapon.damage; //스틱이 데미지
            Debug.Log(currentHp + "스틱에게 맞음");
        }


        if(currentHp <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
