using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public enum MainType {Item}; //������
    public enum SubType {Weapon, Buff, Special }; //������ ����

    public MainType mainType; //maintype ����
    public SubType subType; //subtype ����
    public string itemName; //������ �̸�
    public Sprite itemImage; //������ �̹���
    public GameObject itemPrefab; //������ ������
    public int value; //�������� ����
    public int number; //������ ��ȣ

}