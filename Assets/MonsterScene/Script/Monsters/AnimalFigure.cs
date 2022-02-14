using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFigure : MonsterMeleeFSM
{
    PlayerData playerData;
    public GameObject enemyCanvasGo;
    public GameObject meleeAtkArea;


    private void OnDrawGizmosSelected()
    {
        if (monster == null) return;

        Gizmos.color = Color.yellow;
        // 인식 범위 표시
        Gizmos.DrawWireSphere(transform.position, monster.detectRange);
        Gizmos.color = Color.red;
        // 공격 범위 표시
        Gizmos.DrawWireSphere(transform.position, monster.meleeAttackRange);
    }

    override protected void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        base.Start();
        hp = monster.hp;
        speed = monster.speed;
        SetMeleeAtkArea();
    
    }

    override protected void Update()
    {
        base.Update();

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // -------------------------------------------------
    // 몬스터 HP와 플레이어와 데미지 입는 방식 구현 필요 
    // -------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            if(playerData.isElementPicked == true)
            {
                StartCoroutine("ElementJelly");
            }

            if(playerData.headShot == true)
            {
                int headShotRandom = Random.Range(0, 101);
                if (headShotRandom < 3)
                {
                    hp -= 1000;
                    Debug.Log("헤드 샷");
                }
            }

            int criticalRandom = Random.Range(0, 101);
            if(criticalRandom < playerStats.critical)
            {
                //hp -= playerStats.damage * 2;
               // Debug.Log("크리티컬 데미지");
            }
            else
            {
                //hp -= playerStats.damage;
               // Debug.Log("일반 데미지");
            }
            Destroy(other.gameObject); //충돌 하면 bullet이 사라지도록
            //Debug.Log(hp + "bullet에게 맞음");

        }

        if (other.CompareTag("Apolo"))
        { // 스크립트를 gameobject에서 찾아서 참조한다.
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
           // hp -= useItem.Damage;
            Debug.Log(hp + "apolo에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
           // hp -= useItem.Damage;
            Debug.Log(hp + " stick에게 맞음");
        }

        /*
        if (other.CompareTag("Player"))
         {
           playerStats.hp -= monster.meleeAttackDamage * 100/(100 + playerStats.defence);
           Debug.Log(playerStats.hp + "몬스터에게 맞음");
         }*/
    }

    IEnumerator ElementJelly()
    {
        if (playerData.hotJelly == true)
        {
            hp -= 5;
            yield return new WaitForSeconds(1f);
            hp -= 5;
            yield return new WaitForSeconds(1f);
            hp -= 5;

        }

        if (playerData.frozenJelly == true)
        {
            speed *= 0.5f;
        }

        if (playerData.poisonJelly == true)
        {
            hp -= 10;
            yield return new WaitForSeconds(3f);
            hp -= 10;
        }

        if (playerData.sparkJelly == true)
        {

            RaycastHit[] rayHits = Physics.SphereCastAll
                (transform.position, 10, Vector3.up, 0, LayerMask.GetMask("Monster"));

            int count = 0;


            foreach (RaycastHit hitMonster in rayHits)
            { //rayHits범위에 있는 몬스터들을 hitMonster에 정렬

                if (count >2)
                    continue;

                count++;
                hitMonster.transform.GetComponent<MonsterBase>().hp -= 10;
                
                Debug.Log(hp +"전기");
            }

            /*
            GameObject nearMonster;
            List<GameObject> sparkMonster; 
            nearMonster = GameObject.FindGameObjectWithTag("Monster").GetComponent<GameObject>();
            float Distance = Vector3.Distance(gameObject.transform.position, nearMonster.transform.position);

            if (Distance <= 10)
            {
                foreach(sparkMonster in nearMonster)
                {

                }
            }
            List<GameObject> */

        }

        if (playerData.bombJelly ==true)
        {
            RaycastHit[] rayHits = Physics.SphereCastAll
                (transform.position, 10, Vector3.up, 0,LayerMask.GetMask("Monster"));

            foreach (RaycastHit hitMonster in rayHits)
            { //rayHits범위에 있는 몬스터들을 hitMonster에 정렬
                hitMonster.transform.GetComponent<MonsterBase>().hp -= 20;
                Debug.Log("폭탄");
            }
        }
    }


    // 공격 범위 설정
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
