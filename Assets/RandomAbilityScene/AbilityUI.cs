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

    // �ʱ� ����
    public void AbilityUISet(Ability ability)
    {
        img.sprite = ability.abilityImage;
        abilityName.text = ability.abilityName;
    }

    // UI Ŭ���� �̺�Ʈ
    public void OnPointerDown(PointerEventData eventData)
    {
        // �������� �ʾ��� ��
        if (!isFliped)
        {
            // ������
            animator.SetTrigger("Flip");
            isFliped = true;
        }
        // ������ �� Ŭ�� ���� ��
        else if (isFliped)
        {
            Debug.Log(abilityName.text);
            // ������ ȿ��(�ִϸ��̼�, ȿ����) + �ɷ�ġ �ο�
        }
    }
}
