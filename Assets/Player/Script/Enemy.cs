using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
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
            currentHp -= 20; //아폴로의 데미지
            Debug.Log(currentHp + "아폴로에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= 20; //스틱이 데미지
            Debug.Log(currentHp + "스틱에게 맞음");
        }


        if(currentHp <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
