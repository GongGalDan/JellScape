using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityUI : MonoBehaviour, IPointerDownHandler
{
    public Image img;
    public Text abilityName;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AbilityUISet(Ability ability)
    {
        img.sprite = ability.abilityImage;
        abilityName.text = ability.abilityName;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(abilityName.text);
        animator.SetTrigger("Flip");
    }
}
