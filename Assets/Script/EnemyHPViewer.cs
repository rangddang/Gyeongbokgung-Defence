using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHP enemyHP;
    private Slider hpslider;

    public void Setup(EnemyHP enemyHP)
    {
        this.enemyHP = enemyHP;
        hpslider = GetComponent<Slider>();
    }

    private void Update()
    {
        hpslider.value = enemyHP.CurrentHP / enemyHP.MaxHP;
    }
}
