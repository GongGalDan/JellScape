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
        //Bullet 충돌 처리
        if (other.CompareTag("Bullet"))
        {
            //속성젤리
            if(playerData.isElementPicked == true)
            {
                StartCoroutine("ElementJelly");
            }

            //헤드샷 
            if(playerData.headShot == true)
            {
                int headShotRandom = Random.Range(0, 100);
                if (headShotRandom < 3)
                {
                    hp -= 1000;
                    Debug.Log("헤드 샷");
                }
            }

            if (playerData.isElementPicked == false)
            {
                //크리티컬 데미지
                int criticalRandom = Random.Range(0, 101);
                if (criticalRandom < playerStats.critical)
                {
                    hp -= playerStats.damage * 2;
                    Debug.Log(hp + "크리티컬 데미지");
                }
                else
                {
                    hp -= playerStats.damage;
                    Debug.Log(hp + "일반 데미지");
                }
            }
            Destroy(other.gameObject); //충돌 하면 bullet이 사라지도록
        }

        //아이템 공격
        if (other.CompareTag("Apolo"))
        {  
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + "apolo에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + " stick에게 맞음");
        }
        
        /* player 충돌 처리
        if (other.CompareTag("Player"))
         {
           //플레이어 hp는 몬스터 데미지와 방어력공식 만큼 줄어든다.
           playerStats.hp -= monster.meleeAttackDamage * 100/(100 + playerStats.defence);
           Debug.Log(playerStats.hp + "몬스터에게 맞음");
         }*/
    }

    //ElementJelly 능력치
    IEnumerator ElementJelly()
    {
        //hotJelly 능력
        if (playerData.hotJelly == true)
        {
            //3초간 1초마다 hp가 5씩 줄어든다.
            hp -= 5;
            Debug.Log("hotjelly 1");
            yield return new WaitForSeconds(1f);
            hp -= 5;
            Debug.Log("hotjelly 2");
            yield return new WaitForSeconds(1f);
            hp -= 5;
            Debug.Log("hotjelly 3");
        }

        //frozenJelly
        if (playerData.frozenJelly == true)
        {
            //적의 이동속도가 느려진다.
            speed *= 0.5f;
            Debug.Log("iceJelly");
        }

        //poisonJelly
        if (playerData.poisonJelly == true)
        {
            //hp가 10씩 3초마다 줄어든다.
            hp -= 10;
            Debug.Log("poisionJelly 1");
            yield return new WaitForSeconds(3f);
            hp -= 10;
            Debug.Log("poisionJelly 2");
        }

        //sparkJelly
        if (playerData.sparkJelly == true)
        {
            //범위안에 있는 몬스터들 중 2마리만 피해를 입는다.
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
        }

        //bombJelly
        if (playerData.bombJelly ==true)
        {
            RaycastHit[] rayHits = Physics.SphereCastAll
                (transform.position, 10, Vector3.up, 0,LayerMask.GetMask("Monster"));

            foreach (RaycastHit hitMonster in rayHits)
            { 
                //rayHits범위에 있는 몬스터들을 hitMonster에 정렬, 범위에 있는 몬스터들 hp가 20만큼 줄어든다.
                hitMonster.transform.GetComponent<MonsterBase>().hp -= 20;
                Debug.Log(hp + "폭탄");
            }
        }
    }

    // 공격 범위 설정
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
