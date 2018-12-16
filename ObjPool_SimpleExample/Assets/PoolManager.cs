using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    private static PoolManager _instance;
	public static PoolManager instance
	{
		get
		{
			return _instance;
		}
	}


    public GameObject _objectToSpawn;//used to spawn the Bullets if _poolType is set to None
    [SerializeField]
    int poolSize;
    //Using lists for ObjectPooling
    [SerializeField]
    List<GameObject> _pool;

    //Using queue for ObjectPooling
    [SerializeField]
    Queue<GameObject> _poolQueue;

    private void Start()
    {
        if(_instance==null)
            _instance=this;
        else if(_instance!=this)
        {
            Debug.Log("Error!");
        }

        InitObjPool();
    }
	
    public void InitObjPool()
    {
	    //_pool=new List<GameObject>();
        _poolQueue=new Queue<GameObject>();
	    for(int i=0;i<poolSize;i++)
	    {
            GameObject newBullet=Instantiate(_objectToSpawn);
		    //_pool.Add(Instantiate(_objectToSpawn));
            _poolQueue.Enqueue(newBullet);
		    newBullet.SetActive(false);
	    }
    }

    //Getting and returning objects from the pool
    //Get from pool
    public GameObject GetObjFromPool(Vector3 pos, Quaternion rot)
    {
	    if(_poolQueue.Count<=0)
        {
            GameObject instantiatedZombie = _poolQueue.Dequeue();
            instantiatedZombie.name="Bullet";    
            instantiatedZombie.SetActive(false);
            _poolQueue.Enqueue(instantiatedZombie);
        }

        GameObject newBullet=_poolQueue.Dequeue();
        newBullet.SetActive(true);
	    newBullet.transform.position=pos;
	    newBullet.transform.rotation=rot;

	    //For List
	    //GameObject newBullet=_pool[_pool.Count-1];
        //newBullet.SetActive(true);
	    //newBullet.transform.position=pos;
	    //newBullet.transform.rotation=rot;
	    //_pool.RemoveAt(_pool.Count-1);
	    //_pool.Remove(newBullet);
	
	    return newBullet;
    }

    //Return to pool
    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);

        _poolQueue.Enqueue(go);
        //For List
	    //_pool.Add(go);
    }
}
