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

    public List<Item> itemDB = new List<Item>();

    public GameObject fieldItemPrefab; //생성할 아이템
    public Vector3[] pos; // 생성 아이템 위치

    private void Start()
    {
        for(int i = - ; object <)
    }

}
