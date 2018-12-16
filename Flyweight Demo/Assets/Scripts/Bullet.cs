using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamagable
{

    //private float _speed;
    //private int _dmg;
    //private BulletType _bulletType;
    public BulletStat bullet;

    private Vector3 _dir;
    private Renderer _myRenderer;

    public enum BulletType
    {
        Hostile = 0,
        Friendly = 1
    }

    /// <summary>
    /// Instantiates a new bullet
    /// </summary>
    /// <param name="pos">Position, where to instantiate the Bullet</param>
    /// <param name="dir">Direction in which the bullet should move</param>
    /// <param name="speed">speed of the Bullet</param>
    /// <param name="dmg">Damage the bullet should deal</param>
    /// <param name="bulletType">Determines if the bullet is friendly or hostile</param>
    public static Bullet InstantiateBullet(Vector3 pos, Vector3 dir, BulletStat bs, BulletType bulletType)
    {
        GameObject bulletPrefab = Resources.Load<GameObject>("BulletPrefab");
        Bullet bullet = GameObject.Instantiate(bulletPrefab, pos, Quaternion.identity).GetComponent<Bullet>();
        bullet.bullet=bs;
        bullet._dir = dir;
        bullet._BulletType = bulletType;
        return bullet;
    }

    private void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        transform.position += _dir * bullet._speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagedObj = other.GetComponent<IDamagable>();
        if (damagedObj != null)
        {
            damagedObj.ReceiveDamage(bullet._dmg);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }



    /// <summary>
    /// Called when hit by another bullet
    /// </summary>
    public void ReceiveDamage(int dmg)
    {
        Destroy(this);
    }


    private BulletType _BulletType
    {
        get { return bullet._bulletType; }
        set
        {
            bullet._bulletType = value;
            if (bullet._bulletType == BulletType.Friendly)
            {
                gameObject.layer = LayerMask.NameToLayer("FriendlyBullet");
                _myRenderer.material.color = Color.cyan;
            }
            else if (bullet._bulletType == BulletType.Hostile)
            {
                gameObject.layer = LayerMask.NameToLayer("HostileBullet");
                _myRenderer.material.color = Color.red;
            }
        }
    }
}
