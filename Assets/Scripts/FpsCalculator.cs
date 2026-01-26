using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCalculator : MonoBehaviour
{
    [SerializeField] private Text fpsText;

    private void Start()
    {
        StartCoroutine(calculateFps());
    }
    private IEnumerator calculateFps()
    {
        yield return new WaitForSecondsRealtime(1f);
        float frameRate = 1f / Time.unscaledDeltaTime;
        fpsText.text = (int)(frameRate) + " fps";
    }
}
