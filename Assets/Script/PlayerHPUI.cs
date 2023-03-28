using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] private GameObject[] imagePlayerHP;
    [SerializeField] private PlayerHP playerHP;

    private void Update()
    {
        for(int i = playerHP.MaxHP; i > playerHP.CurrentHP; i--)
        {
            if(playerHP.CurrentHP >= 0)
                imagePlayerHP[i-1].SetActive(false);
        }
	}
}
