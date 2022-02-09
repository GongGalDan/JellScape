using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbility : MonoBehaviour
{
    private PlayerData playerData;
    public List<Ability> randomAbilities;
    public int total;
    public List<Ability> result = new List<Ability>();
    public Transform parent;
    public GameObject cardPrefab;

    void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        // 데이터 추출
        randomAbilities = playerData.abilities;
        ResultSelected();
    }

    // 가중치 뽑기
    public void ResultSelected()
    {
        for (int i = 0; i < 3; i++)
        {
            // 초기화
            InitAbilities();
            
            Debug.Log(i + " total : " + total);

            // 결과 추출
            result.Add(RandomPick());
            
            // 결과 카드 생성
            AbilityUI abilityUI = Instantiate(cardPrefab, parent).GetComponent<AbilityUI>();
            abilityUI.AbilityUISet(result[i]);
        }

        // 다음 뽑기를 위해 리셋
        ResetAbilities();
    }

    // 초기화
    private void InitAbilities()
    {
        total = 0;

        for (int i = 0; i < randomAbilities.Count; i++)
        {
            // 한번 뽑힌 능력은 같은 뽑기에서 제외
            if (randomAbilities[i].isPicked) continue;
            // 속성 능력은 한번만 뽑히도록 설정
            if (playerData.isElementPicked && randomAbilities[i].isElement) continue;
            // 한번만 선택할 수 있고 이미 선택한 능력은 제외
            if (randomAbilities[i].isSelected && randomAbilities[i].isPickableOnce) continue;

            total += randomAbilities[i].weight;
        }
    }

    private void ResetAbilities()
    {
        for (int i = 0; i < randomAbilities.Count; i++)
        {
            randomAbilities[i].isPicked = false;
        }
    }

    private Ability RandomPick()
    {
        int weight = 0;
        int selectNum = 0;

        // 랜덤 숫자 추출
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        
        for (int i = 0; i < randomAbilities.Count; i++)
        {
            // 한번 뽑힌 능력은 같은 뽑기에서 제외
            if (randomAbilities[i].isPicked) continue;
            // 속성 능력은 한번만 뽑히도록 설정
            if (playerData.isElementPicked && randomAbilities[i].isElement) continue;
            // 한번만 선택할 수 있고 이미 선택한 능력은 제외
            if (randomAbilities[i].isSelected && randomAbilities[i].isPickableOnce) continue;

            // 가중치 더해주기
            weight += randomAbilities[i].weight;
            // 뽑혔을 경우
            if (selectNum <= weight)
            {
                // 능력 생성
                Ability temp = new Ability(randomAbilities[i]);
                // 뽑은 것 으로 설정
                randomAbilities[i].isPicked = true;

                return temp;
            }
        }
        return null;
    }
}