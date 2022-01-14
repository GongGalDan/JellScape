using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityUI : MonoBehaviour, IPointerDownHandler
{
    public Image img;
    public Text abilityName;
    public Text abilityGrade;
    Animator animator;
    bool isFliped;

    private void Start()
    {
        isFliped = false;
        animator = GetComponent<Animator>();
    }

    // 초기 세팅
    public void AbilityUISet(Ability ability)
    {
        img.sprite = ability.abilityImage;
        abilityName.text = ability.abilityName;
    }

    // UI 클릭시 이벤트
    public void OnPointerDown(PointerEventData eventData)
    {
        // 뒤집히지 않았을 때
        if (!isFliped)
        {
            // 뒤집기
            animator.SetTrigger("Flip");
            isFliped = true;
        }
        // 뒤집힌 후 클릭 했을 때
        else if (isFliped)
        {
            Debug.Log(abilityName.text);
            // 뽑히는 효과(애니메이션, 효과음) + 능력치 부여
        }
    }
}
