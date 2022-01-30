using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{

    public EnemyDefensive DefEnemy;
    public EnemyKamikaze KamiEnemy;
    public GameObject[] enemyArray; 

    public Transform parentE;
    bool canSpawn;
    public int spawnRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

        private void CreateEnemies()
    {
        for(int i = 0; i < enemyArray.Length; i++)
        {
            enemyArray[i] = Instantiate(enemyArray[i], new Vector3(i,0,0), Quaternion.identity, parentE);
            enemyArray[i].transform.localPosition = new Vector3(i,0,0);
        }
        
    }
        IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }

private void Spawn(){

            if(!canSpawn) return;
        for(int i = 0; i < enemyArray.Length; i++)
        {
            if(!enemyArray[i].isSpawning)
            {
                enemyArray[i].transform.position = transform.position;
                enemyArray[i].Spawn(new Vector3(0, 1, 0), 0f);
                enemyArray[i].isSpawning = true;
                canSpawn = false;
                StartCoroutine(SpawnDelay());
                Debug.Log("Im Here!");
                return;
            }
        }

}

}
