using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player player;
    UsableItem useItem;

    MeshRenderer mesh;
    Material material;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        useItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UsableItem>();

        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            int criticalRandom = Random.Range(0, 101);
            if (criticalRandom < player.currentCritical)
            {
                currentHp -= player.currentDamage * 2;
                Debug.Log("크리티컬 데미지");
            }
            else
            {
                currentHp -= player.currentDamage;
                Debug.Log("일반 데미지");
            }
            Destroy(other.gameObject); //충돌 하면 bullet이 사라지도록
            Debug.Log(currentHp + "bullet에게 맞음");
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
