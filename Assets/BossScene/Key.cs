using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{ 
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50f * Time.deltaTime));
    }
}
