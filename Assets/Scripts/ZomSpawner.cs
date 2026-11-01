using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomSpawner : MonoBehaviour
{
    public Zombie[] zombiePrefab;
    public ZombieData[] zombieDatas;
    public Transform[] spawnPoint;


    private readonly List<Zombie> zombies = new List<Zombie>();

    private int wave = 0;

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");

    }

    private void Update()
    {
        if (zombies.Count == 0)
        {
            SpawnWave();
        }
    }
    private void SpawnWave()
    {
        wave++;
        int count = Mathf.RoundToInt(wave * 1.5f);
        for (int i = 0; i < count; ++i)
        {
            CreateZombie();
        }
        
        
    }
    private void CreateZombie()
    {

        Transform point = spawnPoint[Random.Range(0, spawnPoint.Length)];

        int randomValue = Random.Range(0, 100);
        int selectedIndex = 0;


        if (randomValue < 70)
        {
            selectedIndex = 0;
        }
        else if (randomValue < 90)
        {
            selectedIndex = 1;
        }
        else 
        {
            selectedIndex = 2;
        }


        Zombie prefabToSpawn = zombiePrefab[selectedIndex];
        ZombieData data = zombieDatas[selectedIndex];


        Zombie zombie = Instantiate(prefabToSpawn, point.position, point.rotation);


        zombie.Setup(data);


        zombies.Add(zombie);


        zombie.OnDead.AddListener(() => zombies.Remove(zombie));
        zombie.OnDead.AddListener(() => Destroy(zombie.gameObject, 0.5f));
    }

    public void OnEndGame()
    {
        for (int i = zombies.Count - 1; i >= 0; --i)
        {
            zombies[i].Death();
        }
    }
}
