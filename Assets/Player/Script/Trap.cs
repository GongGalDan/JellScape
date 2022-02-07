using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum ConditionType{��ȭ, �̲�����, ������};
    public ConditionType condition;

    public float damage;
    

    Player playerStats;
    Rigidbody rigidbody;
    GameObject player;



    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* private void OnCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                StartCoroutine("Condition");
            
        }
    }*/


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("Condition");
        }
    }


    IEnumerator Condition()
    {
        if (condition == ConditionType.��ȭ)
        {
            playerStats.currentSpeed -= 1;
            Debug.Log("��ȭ");
            yield return new WaitForSeconds(3);
            playerStats.currentSpeed += 1;

            yield return null;
        }

        if (condition == ConditionType.�̲�����)
        {
            rigidbody.AddForce(transform.forward, ForceMode.Impulse);
            Debug.Log("�̲�����");
            playerStats.currentHp -= damage;
            Debug.Log("�̲���������");
            yield return new WaitForSeconds(1f);

            yield return null;
        }

        if (condition == ConditionType.������)
        {
            playerStats.currentHp -= damage;
            Debug.Log("������");
            yield return null;
        }

    }
}
