using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float _speed;
    public System.Action _onDestroy;

    void Update () {
        transform.position += transform.forward * _speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Destroy the Zombie
        if (collision.gameObject.tag == "Zombie")
        {           
            //Destroy(collision.gameObject);
            ZombiePoolManager.instance.ReturnEnmToPool(collision.gameObject);
        }
        //Destroy the Bullet
        PoolManager.instance.ReturnObjToPool(this.gameObject);
    }
}
