using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum ConditionType{µÐÈ­, ¹Ì²ô·¯Áü, µ¥¹ÌÁö};
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
        if (condition == ConditionType.µÐÈ­)
        {
            playerStats.currentSpeed -= 1;
            Debug.Log("µÐÈ­");
            yield return new WaitForSeconds(3);
            playerStats.currentSpeed += 1;

            yield return null;
        }

        if (condition == ConditionType.¹Ì²ô·¯Áü)
        {
            rigidbody.AddForce(transform.forward, ForceMode.Impulse);
            Debug.Log("¹Ì²ô·¯Áü");
            playerStats.currentHp -= damage;
            Debug.Log("¹Ì²ô·¯ÁüÇÇÇØ");
            yield return new WaitForSeconds(1f);

            yield return null;
        }

        if (condition == ConditionType.µ¥¹ÌÁö)
        {
            playerStats.currentHp -= damage;
            Debug.Log("µ¥¹ÌÁö");
            yield return null;
        }

    }
}
