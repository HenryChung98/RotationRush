using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // obstacle
    [SerializeField] protected GameObject[] obstaclePrefabs;
    [SerializeField] protected GameObject parentObstacle;
    [SerializeField] protected List<GameObject> obstaclePools = new();
    [SerializeField] protected int poolSizeObstacle = 10;

    // switcher
    [SerializeField] protected GameObject[] switcherPrefabs;
    [SerializeField] protected GameObject parentSwitcher;
    [SerializeField] protected List<GameObject> switcherPools = new();
    [SerializeField] protected int poolSizeSwitcher = 2;

    // dragon
    [SerializeField] protected GameObject dragonCautionPrefab;
    protected int dragonCautionNow = 1;
    [SerializeField] protected List<GameObject> dragonPool = new();
    // common
    protected float repeatRateMin = 1.0f;
    protected float repeatRateMax = 3.0f;
    public int spawnedNum = 0;

    protected Vector3 spawnPos;
    protected float spawnPosX;
    protected float spawnPosY;
    protected float spawnPosZ;

    protected void Awake()
    {
        for (int i = 0; i < poolSizeObstacle; i++)
        {
            foreach (GameObject obstaclePrefab in obstaclePrefabs)
            {
                GameObject poolObstacle = Instantiate(obstaclePrefab, parentObstacle.transform);
                poolObstacle.SetActive(false);
                obstaclePools.Add(poolObstacle);
            }
        }
        for (int i = 0; i < poolSizeSwitcher; i++)
        {
            foreach (GameObject switcherPrefab in switcherPrefabs)
            {
                GameObject poolObstacle = Instantiate(switcherPrefab, parentSwitcher.transform);
                poolObstacle.SetActive(false);
                switcherPools.Add(poolObstacle);
            }
        }
        GameObject poolDragon = Instantiate(dragonCautionPrefab);
        poolDragon.SetActive(false);
        dragonPool.Add(poolDragon);
    }

}
