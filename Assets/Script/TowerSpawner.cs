using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private TowerTemplate[] towerTemplate;
    //[SerializeField] private GameObject towerPrefab;
    //[SerializeField] private int towerBuildGold = 50;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerGold playerGold;
    [SerializeField] private SystemTextViewer systemTextViewer;
    [SerializeField] private TowerDataViewer towerDataViewer;
	[SerializeField] private BuildTowerViewer buildTowerViewer;
	private bool isOnTowerButton = false;
    private Tile tile;
    private int towerType;


	public void ReadyToSpawnTower(Transform tileTransform)
    {
		tile = tileTransform.GetComponent<Tile>();

		if (tile.IsBuildTower == true)
		{
			systemTextViewer.PrintText(SystemType.Build);
			return;
		}

		buildTowerViewer.OnPanel(tileTransform.position);

        isOnTowerButton = true;
    }

    public void SpawnTower(int type)
    {
        towerType = type;

        if(isOnTowerButton == false)
        {
            return;
        }

		if (towerTemplate[towerType].weapon[0].cost > playerGold.CurrentGold)
		{
			systemTextViewer.PrintText(SystemType.Money);
			return;
		}

		isOnTowerButton = false;

        tile.IsBuildTower = true;

        playerGold.CurrentGold -= towerTemplate[towerType].weapon[0].cost;

        Vector3 position = tile.transform.position + Vector3.back;
        GameObject clone = Instantiate(towerTemplate[towerType].towerPrefab, position, Quaternion.identity);

        clone.GetComponent<TowerWeapon>().Setup(enemySpawner, playerGold, tile);

        buildTowerViewer.OffPanel();

        towerDataViewer.OnPanel(clone.transform);
    }
}
