using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityUI : GameManager, IPointerDownHandler
{
    public Image img;
    public Text abilityName;
    public Text abilityGrade;
    public string abilityTag;
    Animator animator;
    bool isFliped;

    protected override void Start()
    {
        base.Start();
        isFliped = false;
        animator = GetComponent<Animator>();
    }

    // �ʱ� ����
    public void AbilityUISet(Ability ability)
    {
        img.sprite = ability.abilityImage;
        abilityName.text = ability.abilityName;
        abilityTag = ability.abilityTag;
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
            if (abilityTag == "invincible")
            {
                invincible = true;
            }
            else if (abilityTag == "headShot")
            {
                headShot = true;
            }
            else if (abilityTag == "bombJelly")
            {
                bombJelly = true;
            }
            else if (abilityTag == "hotJelly")
            {
                hotJelly = true;
            }
            else if (abilityTag == "freezeJelly")
            {
                freezeJelly = true;
            }
            else if (abilityTag == "poisonJelly")
            {
                poisonJelly = true;
            }
            else if (abilityTag == "sparkJelly")
            {
                sparkJelly = true;
            }
            else if (abilityTag == "frontJelly")
            {
                frontJelly = true;
            }
            else if (abilityTag == "sideJelly")
            {
                sideJelly = true;
            }
            else if (abilityTag == "damage")
            {
                damage++;
            }
            else if (abilityTag == "attackSpeed")
            {
                attackSpeed++;
            }
            else if (abilityTag == "range")
            {
                range++;
            }
            else if (abilityTag == "critical")
            {
                critical++;
            }
            else if (abilityTag == "hp")
            {
                hp++;
            }
            else if (abilityTag == "defence")
            {
                defence++;
            }
            else if (abilityTag == "speed")
            {
                speed++;
            }
        }
    }
}
