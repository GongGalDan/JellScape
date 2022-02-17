using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashRed : MonoBehaviour
{
    private Image img;
    private Coroutine currentFlashRoutine;
    float timeForOneFlash = 1f;
    float maxAlpha = 0.25f;
    Color newColor = Color.red;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void StartFlash()
    {
        img.color = newColor;

        // 최대 alpha 값 제한
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (currentFlashRoutine != null)
        {
            StopCoroutine(currentFlashRoutine);
        }
        currentFlashRoutine = StartCoroutine(Flash(timeForOneFlash, maxAlpha));
    }

    IEnumerator Flash(float timeForOneFlash, float maxAlpha)
    {
        for (int j = 0; j < 5; j++)
        {
            float flashInDuration = timeForOneFlash / 2;
            for (float i = 0; i < flashInDuration; i += Time.deltaTime)
            {
                Color tempColor = img.color;
                tempColor.a = Mathf.Lerp(0, maxAlpha, i / flashInDuration);
                img.color = tempColor;

                // 다음 프레임까지 기다린다.
                yield return null;
            }

            float flashOutDuration = timeForOneFlash / 2;
            for (float i = 0; i < flashOutDuration; i += Time.deltaTime)
            {
                Color tempColor = img.color;
                tempColor.a = Mathf.Lerp(maxAlpha, 0, i / flashOutDuration);
                img.color = tempColor;

                // 다음 프레임까지 기다린다.
                yield return null;
            }
        }
        img.color = new Color32(0, 0, 0, 0);
    }
}
