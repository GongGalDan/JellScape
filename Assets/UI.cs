using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Image img;
    float alpha;
    int temp;

    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("Panel").GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorAlpha();
        alpha += temp;
        img.color = new Color(255, 0, 0, alpha);
    }

    void ChangeColorAlpha()
    {
        if (alpha <= 0)
        {
            temp = 1;
        }
        else if (alpha >= 50)
        {
            temp = -1;
        }
    }
}
