using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour {

    public float enemySpawnRate = 1.0f;

    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public GameObject Enemy2PowerUpPrefab;
    public GameObject Enemy3Prefab;
    


    public int poolSize;
    private List<GameObject> enemies = new List<GameObject>();
    private float lastSpawn = 0.0f;



    public static GameObject enemiesPoolContainer;
    public static GameObject EnemiesPoolContainer
    {
        get { intializeEnemiesPoolContainer(); return enemiesPoolContainer; }
        set { intializeEnemiesPoolContainer(); enemiesPoolContainer = value; }
    }

    public static void intializeEnemiesPoolContainer()
    {
        if (enemiesPoolContainer == null)
        {
            enemiesPoolContainer = new GameObject();
            enemiesPoolContainer.name = "Enemies Pool Container";
        }
    }


    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (this.lastSpawn < this.enemySpawnRate)
        {
            this.lastSpawn += Time.deltaTime;

        }
        else
        {
            SpawnRandom();

            this.lastSpawn = 0.0f;
        }
    }
        

    private void SpawnRandom()
    {
        float pos = Random.value;
        int spawn = (int)Mathf.Round(Random.value * (4));
        switch (spawn)
        {
            case 1:
            case 2:
                Debug.Log("Spawn Enemy1");
                SpawnEnemy1(pos);
                break;
            case 3:        
                pos = pos * 6 - 5;
                if(pos < 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Debug.Log("Spawn Enemy2");
                        SpawnEnemy2(pos);
                        pos += 0.3f;


                    }

                }
                else
                {

                    for (int i = 0; i < 4; i++)
                    {
                        Debug.Log("Spawn Enemy2");
                        SpawnEnemy2(pos);
                        pos -= 0.3f;


                    }

                }
                
                Debug.Log("Spawn Enemy2PU");
                SpawnEnemy2PowerUp(pos);
                
                break;

            case 4:
                Debug.Log("Spawn Enemy3");
                SpawnEnemy3(pos);
                break;

        }
    }

    

    void SpawnEnemy1(float pos)
    {

        GameObject enemy1;
        if (this.enemies.Count < this.poolSize)
        {

            enemy1 = (GameObject)Instantiate(Enemy1Prefab);
            enemies.Add(enemy1);
            enemy1.transform.SetParent(EnemiesPoolContainer.transform);

        }
        else
        {
            enemy1 = enemies.Find(x => !x.activeInHierarchy);
        }
        
        enemy1.GetComponent<HealthManager>().ResetHealt();
        enemy1.transform.position = new Vector3( pos * 10 - 5 , 8.5f, 0);
        enemy1.SetActive(true);
    }

    void SpawnEnemy2(float pos)
    {

        GameObject enemy2;
        if (this.enemies.Count < this.poolSize)
        {

            enemy2 = (GameObject)Instantiate(Enemy2Prefab);
            enemies.Add(enemy2);
            enemy2.transform.SetParent(EnemiesPoolContainer.transform);

        }
        else
        {
            enemy2 = enemies.Find(x => !x.activeInHierarchy);
        }
        
        enemy2.GetComponent<HealthManager>().ResetHealt();
        enemy2.transform.position = new Vector3( pos, 8.5f, 0 );
        enemy2.SetActive(true);

    }

    void SpawnEnemy2PowerUp(float pos)
    {

        GameObject enemy2PowerUp;
        if (this.enemies.Count < this.poolSize)
        {

            enemy2PowerUp = (GameObject)Instantiate(Enemy2PowerUpPrefab);
            enemies.Add(enemy2PowerUp);
            enemy2PowerUp.transform.SetParent(EnemiesPoolContainer.transform);

        }
        else
        {
            enemy2PowerUp = enemies.Find(x => !x.activeInHierarchy);
        }
        
        enemy2PowerUp.GetComponent<HealthManager>().ResetHealt();
        enemy2PowerUp.transform.position = new Vector3( pos, 8.5f, 0);
        enemy2PowerUp.SetActive(true);
    }

    void SpawnEnemy3(float pos)
    {

        GameObject enemy3;
        if (this.enemies.Count < this.poolSize)
        {

            enemy3 = (GameObject)Instantiate(Enemy3Prefab);
            enemies.Add(enemy3);
            enemy3.transform.SetParent(EnemiesPoolContainer.transform);

        }
        else
        {
            enemy3 = enemies.Find(x => !x.activeInHierarchy);
        }
        
        enemy3.GetComponent<HealthManager>().ResetHealt();
        enemy3.transform.position = new Vector3( pos * 8 - 5, 8.5f, 0);
        enemy3.SetActive(true);

    }

   


}
