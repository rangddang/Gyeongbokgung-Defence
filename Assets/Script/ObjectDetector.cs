using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner towerSpawner;
    [SerializeField] private TowerDataViewer towerDataViewer;
	[SerializeField] private BuildTowerViewer buildTowerViewer;

	private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;
    private Transform hitTransform;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject() == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			if (hitTransform == null || hitTransform.CompareTag("Tower") == false)
			{
				towerDataViewer.OffPanel();
                buildTowerViewer.OffPanel();
			}
			hitTransform = null;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitTransform = hit.transform;
				if (hit.transform.CompareTag("Tile"))
                {
                    //towerSpawner.SpawnTower(hit.transform);
                    towerSpawner.ReadyToSpawnTower(hit.transform);
                    //buildTowerViewer.OnPanel(hit.transform.position);
				}
                else if (hit.transform.CompareTag("Tower"))
                {
                    towerDataViewer.OnPanel(hit.transform);
                }
			}

        }
    }
}
