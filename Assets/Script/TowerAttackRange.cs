using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRange : MonoBehaviour
{
    private float diameter;
    private float startRange;

	private void Awake()
    {
        OffAttackRange();
    }

    public void OnAttackRange(Vector3 position, float startRange, float range)
    {
        gameObject.SetActive(true);

        this.startRange = startRange;

        diameter = range * 2.0f;
        transform.localScale = Vector3.zero;

        StopCoroutine("ChangeScale");
        StartCoroutine("ChangeScale");

        transform.position = position;
    }
    public void OffAttackRange()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator ChangeScale()
    {
        float newRange = startRange;
        while(newRange < diameter * 0.99f)
        {
            newRange = Mathf.Lerp(newRange, diameter, 5 * Time.deltaTime);
            transform.localScale = newRange * Vector3.one;
            yield return null;
        }

    }
}
