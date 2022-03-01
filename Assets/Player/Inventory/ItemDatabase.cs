using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{ // 타입, 이름, 설명, 무기 착용여부
    public Item(string _Type, string _Name, string _Explain, bool _isUsing)
    {
        Type = _Type; Name = _Name; Explain = _Explain; 
        isUsing = _isUsing;
    }

    public string Type, Name, Explain;
    public bool isUsing;
}

public class ItemDatabase : MonoBehaviour
{
    public TextAsset itemDatabase; // 메모장 파일
    public List<Item> AllItemList; // 아이템리스트

    private void Start()
    {
        // 전체 아이템 리스트
        string[] line = itemDatabase.text.Substring(0, itemDatabase.text.Length - 1).Split('\n');
        for(int i = 0; i< line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3]== "True"));
        }
    }

}
