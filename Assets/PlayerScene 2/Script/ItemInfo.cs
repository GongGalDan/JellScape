using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public enum MainType { Item};
    public enum SubType { Weapon, Buff, Special};

    public string itemName;
    public MainType mainType;
    public SubType subType;
    public int value;
    public int number;


}
