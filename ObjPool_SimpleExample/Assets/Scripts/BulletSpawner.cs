using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform _bulletSpawnPos;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            SpawnBullet();
    }

    private void SpawnBullet()
    {
        //GameObject newBullet = Instantiate(_objectToSpawn, _bulletSpawnPos.position, _bulletSpawnPos.rotation);
        GameObject newBullet = PoolManager.instance.GetObjFromPool(_bulletSpawnPos.position, _bulletSpawnPos.rotation);
    }
}
