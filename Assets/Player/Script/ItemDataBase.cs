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

    public GameObject fieldItemPrefab; //������ ������
    public Vector3[] pos; // ���� ������ ��ġ

    private void Start()
    {
        for(int i = - ; object <)
    }

}
