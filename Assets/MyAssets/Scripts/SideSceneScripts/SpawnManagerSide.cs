using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManagerSide : SpawnManager
{
    // declare references to external components
    private PlayerControllerSide playerControllerScript;
    private CameraHandlerSide cameraHandlerSide;

    void Start()
    {
        spawnPosX = 12.0f;
        spawnPosY = -3.25f;
        playerControllerScript = GameObject.Find("SideView_Player").GetComponent<PlayerControllerSide>();
        cameraHandlerSide = GameObject.Find("CameraHandler").GetComponent<CameraHandlerSide>();
        StartCoroutine(EnableObstacle());
    }
    IEnumerator EnableObstacle()
    {
        while (playerControllerScript.gameOver == false)
        {
            if (spawnedNum % 10 == 0)
            {
                if (repeatRateMin >= 0.2f)
                {
                    repeatRateMin -= 0.2f;
                    repeatRateMax -= 0.2f;
                }
            }

            spawnPosZ = cameraHandlerSide.isCameraFlipped ? 1.0f : -1.0f;
            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            int chanceToSwitch = Random.Range(1, 6);

            float repeatRate = Random.Range(repeatRateMin, repeatRateMax);

            // switch is spawned with 10% chance
            //if (chanceToSwitch == 10)
            //{
            //    if (switcherPools.Count > 0)
            //    {
            //        GameObject switcher = switcherPools[Random.Range(0, switcherPools.Count)];
            //        switcher.transform.position = spawnPos;
            //        switcher.transform.rotation = Quaternion.identity;
            //        switcher.SetActive(true);
            //    }
            //}
       
            if (dragonCautionNow % 10 == 0)
            {
                GameObject dragonCaution = dragonPool[0];
                dragonCaution.transform.position = spawnPos;
                dragonCaution.SetActive(true);
            }
            else if (chanceToSwitch == 5)
            {
                if (switcherPools.Count > 0)
                {
                    GameObject switcher = null;

                    // find deactivate object
                    for (int i = 0; i < switcherPools.Count; i++)
                    {
                        switcher = switcherPools[Random.Range(0, switcherPools.Count)];
                        if (!switcher.activeSelf) // check object is activate
                        {
                            break; // break if deactivate object is found 
                        }
                    }

                    if (switcher != null && !switcher.activeSelf) // execute if !null and deactivate
                    {
                        switcher.transform.position = spawnPos;
                        switcher.transform.rotation = Quaternion.identity;
                        switcher.SetActive(true);
                    }
                }
            }
            else
            {
                // Activate a random inactive obstacle if available
                if (obstaclePools.Count > 0)
                {
                    GameObject obstacle = null;


                    for (int i = 0; i < obstaclePools.Count; i++)
                    {
                        obstacle = obstaclePools[Random.Range(0, obstaclePools.Count)];
                        if (!obstacle.activeSelf) 
                        {
                            break; 
                        }
                    }

                    if (obstacle != null && !obstacle.activeSelf) 
                    {
                        obstacle.transform.position = spawnPos;
                        obstacle.transform.rotation = Quaternion.identity;
                        obstacle.SetActive(true);
                    }
                }
            }
            spawnedNum++;
            dragonCautionNow++;
            Debug.Log(dragonCautionNow);
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
