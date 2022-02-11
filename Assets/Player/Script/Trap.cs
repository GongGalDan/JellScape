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
        if (condition == ConditionType.µÐÈ­)
        {
            playerStats.speed -= 1;
            Debug.Log("µÐÈ­");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;

            
            yield return new WaitForSeconds(3);
            
            playerStats.speed = playerdata.speed; //»Ì±â·Î ´õÇØÁø ´É·ÂÄ¡¸¦ ³Ö¾î¼­ ¿ø·¡´ë·Î µ¹¸°´Ù.
        }

        if (condition == ConditionType.¹Ì²ô·¯Áü)
        {
            rigidbody.AddForce(playerStats.moveVec.normalized * 20, ForceMode.Impulse);
            Debug.Log("¹Ì²ô·¯Áü");
            playerStats.hp -= damage;
            Debug.Log("¹Ì²ô·¯ÁüÇÇÇØ");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

        if (condition == ConditionType.µ¥¹ÌÁö)
        {
            playerStats.hp -= damage;
            Debug.Log("µ¥¹ÌÁö");
            trapArea.enabled = false;

            yield return new WaitForSeconds(1f);
            trapArea.enabled = true;
        }

    }
}
