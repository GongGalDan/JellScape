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
        // ������ ����
        randomAbilities = playerData.abilities;
        ResultSelected();
    }

    // ����ġ �̱�
    public void ResultSelected()
    {
        for (int i = 0; i < 3; i++)
        {
            // �ʱ�ȭ
            InitAbilities();
            
            Debug.Log(i + " total : " + total);

            // ��� ����
            result.Add(RandomPick());
            
            // ��� ī�� ����
            AbilityUI abilityUI = Instantiate(cardPrefab, parent).GetComponent<AbilityUI>();
            abilityUI.AbilityUISet(result[i]);
        }

        // ���� �̱⸦ ���� ����
        ResetAbilities();
    }

    // �ʱ�ȭ
    private void InitAbilities()
    {
        total = 0;

        for (int i = 0; i < randomAbilities.Count; i++)
        {
            // �ѹ� ���� �ɷ��� ���� �̱⿡�� ����
            if (randomAbilities[i].isPicked) continue;
            // �Ӽ� �ɷ��� �ѹ��� �������� ����
            if (playerData.isElementPicked && randomAbilities[i].isElement) continue;
            // �ѹ��� ������ �� �ְ� �̹� ������ �ɷ��� ����
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

        // ���� ���� ����
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        
        for (int i = 0; i < randomAbilities.Count; i++)
        {
            // �ѹ� ���� �ɷ��� ���� �̱⿡�� ����
            if (randomAbilities[i].isPicked) continue;
            // �Ӽ� �ɷ��� �ѹ��� �������� ����
            if (playerData.isElementPicked && randomAbilities[i].isElement) continue;
            // �ѹ��� ������ �� �ְ� �̹� ������ �ɷ��� ����
            if (randomAbilities[i].isSelected && randomAbilities[i].isPickableOnce) continue;

            // ����ġ �����ֱ�
            weight += randomAbilities[i].weight;
            // ������ ���
            if (selectNum <= weight)
            {
                // �ɷ� ����
                Ability temp = new Ability(randomAbilities[i]);
                // ���� �� ���� ����
                randomAbilities[i].isPicked = true;

                return temp;
            }
        }
        return null;
    }
}