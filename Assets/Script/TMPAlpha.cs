using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPAlpha : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.5f;
    private TextMeshProUGUI text;

    private float waitTime = 0.5f;
    private float start = 1f;
    private float end = 0f;

	private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void FadeOut()
    {
        StopCoroutine("AlphaLerp");
        StartCoroutine("AlphaLerp");    
    }

    private IEnumerator AlphaLerp()
    {
        float currentTime = 0;
        float percent = 0;

		text.color = Color.white;

		yield return new WaitForSeconds(waitTime);

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            Color color = text.color;
            color.a = Mathf.Lerp(start,end,percent);
            text.color = color;

            yield return null;
        }
    }
}
