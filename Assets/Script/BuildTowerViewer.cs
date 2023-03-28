using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTowerViewer : MonoBehaviour
{
    private RectTransform myTransform;

    private void Awake()
    {
        myTransform = GetComponent<RectTransform>();
        OffPanel();
    }

    public void OnPanel(Vector3 position)
    {
        gameObject.SetActive(true);

        myTransform.position = Camera.main.WorldToScreenPoint(position);

        //StopCoroutine("PanelAnimation");
        //StartCoroutine("PanelAnimation");
    }
    public void OffPanel()
    {
		gameObject.SetActive(false);
	}

    private IEnumerator PanelAnimation()
    {
        yield return null;
    }
}
