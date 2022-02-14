using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneManager : MonoBehaviour
{
    int randNum;

    // Ű ����Ʈ
    GameObject leftUpKeys;
    GameObject rightUpKeys;
    GameObject leftDownKeys;
    GameObject rightDownKeys;

    void Start()
    {
        // Ű ����Ʈ �ʱ�ȭ
        leftUpKeys = transform.GetChild(0).GetChild(0).gameObject;
        rightUpKeys = transform.GetChild(0).GetChild(1).gameObject;
        leftDownKeys = transform.GetChild(0).GetChild(2).gameObject;
        rightDownKeys = transform.GetChild(0).GetChild(3).gameObject;

        // ���� Ű ����
        randNum = Random.Range(0, 4);
        leftUpKeys.transform.GetChild(randNum).gameObject.SetActive(true);

        randNum = Random.Range(0, 4);
        rightUpKeys.transform.GetChild(randNum).gameObject.SetActive(true);

        randNum = Random.Range(0, 4);
        leftDownKeys.transform.GetChild(randNum).gameObject.SetActive(true);

        randNum = Random.Range(0, 4);
        rightDownKeys.transform.GetChild(randNum).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}