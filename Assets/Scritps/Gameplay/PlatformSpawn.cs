/*using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;   */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public float spawnTimer;
    public GameObject enemy;
    public GameObject[] randomSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(3f, 10f);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            int randomIndex = Random.Range(0, randomSpawn.Length);
            Vector3 spawnPosition = new Vector3(randomSpawn[randomIndex].transform.position.x, transform.position.y, transform.position.z);

            Quaternion spawnRotation = transform.rotation;

            if (randomIndex == 1)
            {
                spawnRotation *= Quaternion.Euler(180, 0, 180); 
            }
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, spawnRotation);
            spawnTimer = Random.Range(3f, 10f);
        }
    }
}
