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
    bool isFliped;

    private void Start()
    {
        isFliped = false;
        animator = GetComponent<Animator>();
    }
    public void AbilityUISet(Ability ability)
    {
        img.sprite = ability.abilityImage;
        abilityName.text = ability.abilityName;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isFliped)
        {
            animator.SetTrigger("Flip");
            isFliped = true;
        }
        else if (isFliped)
        {
            Debug.Log(abilityName.text);
            // ������ ȿ��(�ִϸ��̼�, ȿ����) + �ɷ�ġ �ο�
        }
    }
}
