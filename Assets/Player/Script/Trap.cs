using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum ConditionType{µÐÈ­, ¹Ì²ô·¯Áü, µ¥¹ÌÁö};
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
        if (condition == ConditionType.µÐÈ­)
        {
            playerStats.currentSpeed -= 1;
            Debug.Log("µÐÈ­");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;

            
            yield return new WaitForSeconds(3);
            //***********¼öÁ¤*************
            playerStats.currentSpeed = 3; //»Ì±â·Î ´õÇØÁø ´É·ÂÄ¡¸¦ ³Ö¾î¼­ ¿ø·¡´ë·Î µ¹¸°´Ù.
        }

        if (condition == ConditionType.¹Ì²ô·¯Áü)
        {
            rigidbody.AddForce(playerStats.moveVec * 20, ForceMode.Impulse);
            Debug.Log("¹Ì²ô·¯Áü");
            playerStats.currentHp -= damage;
            Debug.Log("¹Ì²ô·¯ÁüÇÇÇØ");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

        if (condition == ConditionType.µ¥¹ÌÁö)
        {
            playerStats.currentHp -= damage;
            Debug.Log("µ¥¹ÌÁö");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

    }
}
