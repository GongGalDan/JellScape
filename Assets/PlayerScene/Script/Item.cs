using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum MainType {Item}; //������
    public enum SubType {Weapon, Buff, Special }; //������ ����
    public MainType mainType; //maintype ����
    public SubType subType; //subtype ����
    public int value; //�������� ����
    public int number; //������ ��ȣ

}