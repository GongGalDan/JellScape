using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum ConditionType{��ȭ, �̲�����, ������};
    public ConditionType condition;
    public BoxCollider trapArea;

    public float damage;

    Player playerStats;
    Rigidbody rigidbody;



    void Start()
    {
        playerStats= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        trapArea.enabled = true;
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



    private void OnTriggerEnter(Collider other)
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
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;

            
            yield return new WaitForSeconds(3);
            //***********����*************
            playerStats.currentSpeed = 3; //�̱�� ������ �ɷ�ġ�� �־ ������� ������.
        }

        if (condition == ConditionType.�̲�����)
        {
            rigidbody.AddForce(playerStats.moveVec * 20, ForceMode.Impulse);
            Debug.Log("�̲�����");
            playerStats.currentHp -= damage;
            Debug.Log("�̲���������");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

        if (condition == ConditionType.������)
        {
            playerStats.currentHp -= damage;
            Debug.Log("������");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

    }
}
