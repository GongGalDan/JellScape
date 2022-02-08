using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbility : MonoBehaviour
{
    GameManager gm;
    public List<Ability> randomAbilities;
    public int total;
    public List<Ability> result = new List<Ability>();
    public Transform parent;
    public GameObject cardPrefab;

    private bool isElementPicked;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        randomAbilities = gm.abilities;
        ResultSelected();
    }

    public void ResultSelected()
    {
        for (int i = 0; i < 3; i++)
        {
            InitAbilities();
            
            Debug.Log(i + " total : " + total);

            result.Add(RandomPick());
            
            AbilityUI abilityUI = Instantiate(cardPrefab, parent).GetComponent<AbilityUI>();
            abilityUI.AbilityUISet(result[i]);
        }
    }

    void InitAbilities()
    {
        total = 0;

        for (int i = 0; i < randomAbilities.Count; i++)
        {
            if (randomAbilities[i].isPicked) continue;
            if (isElementPicked && randomAbilities[i].isElement) continue;
            
            total += randomAbilities[i].weight;
        }
    }

    public Ability RandomPick()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        for (int i = 0; i < randomAbilities.Count; i++)
        {
            if (randomAbilities[i].isPicked) continue;
            if (isElementPicked && randomAbilities[i].isElement) continue;

            weight += randomAbilities[i].weight;
            if (selectNum <= weight)
            {
                Ability temp = new Ability(randomAbilities[i]);

                randomAbilities[i].isPicked = true;

                if (randomAbilities[i].isElement)
                {
                    isElementPicked = true;
                }

                return temp;
            }
        }
        return null;
    }
}