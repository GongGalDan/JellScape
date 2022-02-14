using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    ScenesManager sm;

    private void Start()
    {
        sm = GameObject.Find("SceneManager").GetComponent<ScenesManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sm.ToEnding();
        }
    }
}
