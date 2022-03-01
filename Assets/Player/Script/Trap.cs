using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // 아이템 종류
    public enum ConditionType{둔화, 미끄러짐, 데미지};
    public ConditionType condition;
    public BoxCollider trapArea;

    public float damage;

    Player playerStats;
    Rigidbody rigidbody;
    PlayerData playerdata;

    void Start()
    {
        playerStats= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerdata = GameObject.Find("GameManager").GetComponent<PlayerData>();
        trapArea.enabled = true;
    }

    // 충돌 처리
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("Condition");
        }
    }

    // 방해요소 능력
    IEnumerator Condition()
    {
        if (condition == ConditionType.둔화)
        {
            // 닿으면 속도가 느려짐
            playerStats.speed -= 1;
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true; // 1초마다 중첩되도록

            yield return new WaitForSeconds(3);
            
            playerStats.speed = playerdata.speed; 
            // 3초가 지나면 뽑기로 더해진 능력치를 넣어서 원래대로 돌린다.
        }

        if (condition == ConditionType.미끄러짐)
        { 
            // 닿으면 미끄러짐
            rigidbody.AddForce(playerStats.moveVec.normalized * 20, ForceMode.Impulse);
            playerStats.hp -= damage;
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

        if (condition == ConditionType.데미지)
        {
            // 닿으면 피해를 입음
            playerStats.hp -= damage;
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }
    }
}
