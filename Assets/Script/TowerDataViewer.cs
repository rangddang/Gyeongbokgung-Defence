using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField] private Image imageTower;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TextMeshProUGUI textDamage;
    [SerializeField] private TextMeshProUGUI textRate;
    [SerializeField] private TextMeshProUGUI textRange;
    [SerializeField] private TowerAttackRange towerAttackRange;
    [SerializeField] private Button buttonUpgrade;
    [SerializeField] private SystemTextViewer systemTextViewer;
    [SerializeField] private TextMeshProUGUI textButtonUpgrade;
    [SerializeField] private TextMeshProUGUI textButtonSell;

    private TowerWeapon currentTower;

    private void Awake()
    {
        OffPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform towerWeapon)
    {
        if (currentTower == towerWeapon.GetComponent<TowerWeapon>() && gameObject.active == true) return;

        currentTower = towerWeapon.GetComponent<TowerWeapon>();

        gameObject.SetActive(true);

        UpdateTowerData();

        towerAttackRange.gameObject.SetActive(true);

        towerAttackRange.OnAttackRange(towerWeapon.position, 0, currentTower.Range);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);

        towerAttackRange.OffAttackRange();
    }

    private void UpdateTowerData()
    {
        imageTower.sprite = currentTower.TowerSprite;
        textName.text = currentTower.Name;
        textLevel.text = "Level." + currentTower.Level.ToString();
        textDamage.text = "Damage: " + currentTower.Damage.ToString();
        textRate.text = "Rate: " + currentTower.Rate.ToString();
        textRange.text = "Range: " + currentTower.Range.ToString();
        textButtonUpgrade.text = "Upgrade\n";
        textButtonSell.text = "Sell\n";

        buttonUpgrade.interactable = currentTower.Level < currentTower.MaxLevel ? true : false;
    }

    public void OnClickEventTowerUpgrade()
    {
        float newRange = currentTower.Range * 2;

		bool isSuccess = currentTower.Upgrade();

        if (isSuccess)
        {
            UpdateTowerData();

            towerAttackRange.OnAttackRange(currentTower.transform.position, newRange, currentTower.Range);
        }
        else
        {
            systemTextViewer.PrintText(SystemType.Money);
        }
    }

    public void OnClickEventTowerSell()
    {
        currentTower.SellTower();

        OffPanel();
    }
}
