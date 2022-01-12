using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum MainType {Item}; //아이템
    public enum SubType {Weapon, Buff, Special }; //아이템 종류
    public MainType mainType; //maintype 설정
    public SubType subType; //subtype 설정
    public int value; //아이템의 개수
    public int number; //아이템 번호

}