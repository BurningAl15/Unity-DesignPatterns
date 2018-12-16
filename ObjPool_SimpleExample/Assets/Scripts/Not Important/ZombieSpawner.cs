using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    //public GameObject _zombiePrefab;

    public float _spawnInterval = 0.5f;
    private float _spawnTimer;

    void Update () {
        _spawnTimer += Time.deltaTime;
        if(_spawnTimer > _spawnInterval)
        {
            _spawnTimer = 0;
            SpawnZombie();
        }
	}

    void SpawnZombie()
    {
        Vector3 rndSpawnPos = new Vector3(Random.Range(-8f, 8f), 0, 30);

        ZombiePoolManager.instance.GetEnmFromPool(rndSpawnPos,Quaternion.Euler(0, 180, 0));
        //Instantiate(_zombiePrefab, rndSpawnPos, Quaternion.Euler(0, 180, 0));
    }
}
