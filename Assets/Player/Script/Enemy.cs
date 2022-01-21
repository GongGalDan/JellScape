using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;
    UsableItem useItem;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        useItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UsableItem>();


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
            currentHp -= useItem.apoloDamage; //아폴로의 데미지
            Debug.Log(currentHp + "아폴로에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= useItem.stickDamage; //스틱의 데미지
            Debug.Log(currentHp + "스틱에게 맞음");
        }


        if(currentHp <= 0)
        {
            //총이 통과하도록 설정하는거 적기
            Destroy(gameObject, 0.3f);
        }
    }
}
