using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    GameManager gm;
    public UnityEvent OnGetKey;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50f * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.numOfCollectedKeys++;
            OnGetKey.Invoke();

            gameObject.SetActive(false);
        }
    }
}