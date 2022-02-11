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
    PlayerData playerdata;



    void Start()
    {
        playerStats= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerdata = GameObject.Find("GameManager").GetComponent<PlayerData>();
        trapArea.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            playerStats.speed -= 1;
            Debug.Log("��ȭ");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;

            
            yield return new WaitForSeconds(3);
            
            playerStats.speed = playerdata.speed; //�̱�� ������ �ɷ�ġ�� �־ ������� ������.
        }

        if (condition == ConditionType.�̲�����)
        {
            rigidbody.AddForce(playerStats.moveVec.normalized * 20, ForceMode.Impulse);
            Debug.Log("�̲�����");
            playerStats.hp -= damage;
            Debug.Log("�̲���������");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

        if (condition == ConditionType.������)
        {
            playerStats.hp -= damage;
            Debug.Log("������");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

    }
}
