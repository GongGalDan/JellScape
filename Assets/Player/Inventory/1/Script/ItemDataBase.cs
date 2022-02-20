using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<ItemType> itemDB;
    public List<GameObject> currentItems = new List<GameObject>(); //

}
