using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbility : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();
    public int total;
    public List<Ability> result = new List<Ability>();
    public Transform parent;
    public GameObject cardPrefab;

    void Start()
    {
        total = 0;

        for (int i = 0; i < abilities.Count; i++)
        {
            total += abilities[i].weight;
        }
   
        ResultSelected();
    }

    public void ResultSelected()
    {
        for (int i = 0; i < 3; i++)
        {
            result.Add(RandomPick());
            AbilityUI abilityUI = Instantiate(cardPrefab, parent).GetComponent<AbilityUI>();
            abilityUI.AbilityUISet(result[i]);
        }
    }

    public Ability RandomPick()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < abilities.Count; i++)
        {
            weight += abilities[i].weight;
            if (selectNum <= weight)
            {
                Ability temp = new Ability(abilities[i]);
                return temp;
            }
        }
        return null;
    }


}
