using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    AbilityUI ab1;
    AbilityUI ab2;
    AbilityUI ab3;

    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(ApplyAbilities);
    }

    public void SetAbilities()
    {
        ab1 = GameObject.Find("AbilityPanel").transform.GetChild(0).GetComponent<AbilityUI>();
        ab2 = GameObject.Find("AbilityPanel").transform.GetChild(1).GetComponent<AbilityUI>();
        ab3 = GameObject.Find("AbilityPanel").transform.GetChild(2).GetComponent<AbilityUI>();
    }

    private void ApplyAbilities()
    {
        ab1.ApplyAbilities();
        ab2.ApplyAbilities();
        ab3.ApplyAbilities();
    }
}
