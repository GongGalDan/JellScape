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
    public string abilityTag;
    Animator animator;
    bool isFliped;
    // ���� ���� �Ǿ�����
    bool isSelected;
    // �̱� â������ ����
    bool isPicked;

    PlayerData playerData;

    public void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
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
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        // ������ �� Ŭ�� ���� ��
        else if (isFliped)
        {
            if (isPicked)
            {
                isPicked = false;
                playerData.numSelectedAbilities--;
                // ���� ���� �ִϸ��̼�
                animator.SetTrigger("Deselect");

                return;
            }
            if (playerData.numSelectedAbilities == 2) return;
            if (!isPicked)
            {
                isPicked = true;
                playerData.numSelectedAbilities++;
                // ���� �ִϸ��̼�
                animator.SetTrigger("Select");
            }
        }
    }

    public void ApplyAbilities()
    {
        if (!isPicked) return;

        Debug.Log(abilityName.text);

        if (abilityTag == "invincible")
        {
            playerData.invincible = true;
        }
        else if (abilityTag == "headShot")
        {
            playerData.headShot = true;
        }
        else if (abilityTag == "bombJelly")
        {
            playerData.bombJelly = true;
        }
        else if (abilityTag == "hotJelly")
        {
            playerData.hotJelly = true;
        }
        else if (abilityTag == "frozenJelly")
        {
            playerData.frozenJelly = true;
        }
        else if (abilityTag == "poisonJelly")
        {
            playerData.poisonJelly = true;
        }
        else if (abilityTag == "sparkJelly")
        {
            playerData.sparkJelly = true;
        }
        else if (abilityTag == "frontJelly")
        {
            playerData.frontJelly = true;
        }
        else if (abilityTag == "sideJelly")
        {
            playerData.sideJelly = true;
        }
        else if (abilityTag == "addDamage")
        {
            playerData.addDamage++;
        }
        else if (abilityTag == "addShootRate")
        {
            playerData.addShootRate++;
        }
        else if (abilityTag == "addRange")
        {
            playerData.addRange++;
        }
        else if (abilityTag == "addCritical")
        {
            playerData.addCritical++;
        }
        else if (abilityTag == "addHp")
        {
            playerData.addHp++;
        }
        else if (abilityTag == "addDefence")
        {
            playerData.addDefence++;
        }
        else if (abilityTag == "addSpeed")
        {
            playerData.addSpeed++;
        }

        for (int i = 0; i < playerData.abilities.Count; i++)
        {
            if (playerData.abilities[i].abilityTag == abilityTag)
            {
                playerData.abilities[i].isSelected = true;
            }
        }

        playerData.UpdatePlayerData();
    }
}