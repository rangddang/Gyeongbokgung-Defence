using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.down * 20.0f;
    private Transform target;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        this.target = target;

        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

        rectTransform.position = screenPos + distance;
    }
}
