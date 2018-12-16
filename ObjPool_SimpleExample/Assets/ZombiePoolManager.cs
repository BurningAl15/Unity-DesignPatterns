using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePoolManager : MonoBehaviour {

    private static ZombiePoolManager _instance;
	public static ZombiePoolManager instance
	{
		get
		{
			if(_instance == null)
				_instance = ZombiePoolManager.FindObjectOfType<ZombiePoolManager>();
			return _instance;
		}
	}

    [SerializeField]
    List<GameObject> _pool;

    //[SerializeField]
    //Queue<GameObject> _pool;

    public GameObject _enemyToSpawn;//used to spawn the Bullets if _poolType is set to None
    [SerializeField]
    int poolSize;

	void Start () {
		InitEnmPool();
	}
	
    public void InitEnmPool()
    {
        _pool = new List<GameObject>();
        //_pool=new Queue<GameObject>();
        for (int i=0;i<poolSize;i++)
	    {
            //GameObject newBullet=Instantiate(_enemyToSpawn);
            //_pool.Enqueue(newBullet);
            //newBullet.SetActive(false);

            //List
            _pool.Add(Instantiate(_enemyToSpawn));
            _pool[i].SetActive(false);
	    }
    }

    //Getting and returning objects from the pool
    //Get from pool
    public GameObject GetEnmFromPool(Vector3 pos, Quaternion rot)
    {
        //QUEUE
        //Lazy
        //if(_pool.Count<=0)
        //{
        //    GameObject instantiatedZombie = _pool.Dequeue();
        //    instantiatedZombie.name="Zombie";    
        //    instantiatedZombie.SetActive(false);
        //    _pool.Enqueue(instantiatedZombie);
        //}

        //GameObject newZombie = _pool.Dequeue();
        //newZombie.SetActive(true);
        //newZombie.transform.position = pos;
        //newZombie.transform.rotation = rot;
        //_pool.RemoveAt(_pool.Count - 1);

        //LIST
        if(_pool.Count!=0)
        {
            GameObject newZombie = _pool[_pool.Count-1];
            newZombie.SetActive(true);
            newZombie.transform.position = pos;
            newZombie.transform.rotation = rot;
            //_pool.RemoveAt(_pool.Count - 1);
            _pool.Remove(newZombie);

            return newZombie;
        }
        else
            return null;
    }

    //Return to pool
    public void ReturnEnmToPool(GameObject go)
    {
        //_pool.Enqueue(go);
        go.SetActive(false);
        _pool.Add(go);
    }
}
