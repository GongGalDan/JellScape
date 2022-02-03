using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;
    UsableItem useItem;

    MeshRenderer mesh;
    Material material;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        useItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UsableItem>();

        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
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
            currentHp -= useItem.Damage; //아폴로의 데미지
            Debug.Log(currentHp + "아폴로에게 맞음");
            material.color = new Color(0,100,0);
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= useItem.Damage; //스틱의 데미지
            Debug.Log(currentHp + "스틱에게 맞음");
            material.color = new Color(100, 100, 0);
        }


        if(currentHp <= 0)
        {
            gameObject.layer = 11;
            Destroy(gameObject, 0.3f);
        }
    }
}
