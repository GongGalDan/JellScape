using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item4
{
    public Item4(string _Type, string _Name, string _Explain,
        string _addDamage, string _addShootRate, string _addRange, string _addDefence, bool _isUsing)
    {
        Type = _Type; Name = _Name; Explain = _Explain; 
        addDamage = _addDamage; addShootRate = _addShootRate; addRange = _addRange; addDefence = _addDefence;
        isUsing = _isUsing;
    }

    public string Type, Name, Explain, addDamage, addShootRate, addRange, addDefence;
    public bool isUsing;
}

public class ItemDB4 : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item4> AllItemList;

    private void Start()
    {
        // 전체 아이템 리스트
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        for(int i = 0; i< line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item4(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7] == "True"));
        }
    }

}
