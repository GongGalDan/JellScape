using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum MainType {Item};
    public enum SubType {Weapon, Buff, Special };
    public MainType mainType;
    public SubType subType;
    public int value;

}
