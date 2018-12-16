using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamagable
{

    [Tooltip("Horizontal movementspeed in meter per second")]
    public float _horMovSpeed = 1;

    private Animator _animator;
    private Slider _hpSlider;
    private float _maxXPos = 5;//How far left/right the player can move
    private int _curHp;//current hitpoints of the player
    private int _maxHp = 100;//maximum hitpoints of the player

    //Stats for bullets. This is not very elegant!
    //private int _bulletSpeed = 8;
    //private int _bulletDmg = 1;
    //private Bullet.BulletType _bulletType = Bullet.BulletType.Friendly;
    //TODO reference a Bulletstat - ScriptableObject (= use flyweight)

    public BulletStat bullet;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Run", true);
        _hpSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        _Hp = 100;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Bullet.InstantiateBullet(transform.position + Vector3.up + Vector3.forward, transform.forward, _bulletSpeed, _bulletDmg, _bulletType);
            Bullet.InstantiateBullet(transform.position + Vector3.up + Vector3.forward, transform.forward, bullet, bullet._bulletType);
        }
    }

    //Movement of the Player
    void FixedUpdate()
    {
        float inputXAxis = Input.GetAxis("Horizontal");
        float targetXPos = Mathf.Clamp(transform.position.x + inputXAxis * _horMovSpeed * Time.fixedDeltaTime, -_maxXPos, _maxXPos);

        transform.position = new Vector3(targetXPos, transform.position.y, 0);
    }

    public void Die()
    {
        Debug.Log("You died!");
        SceneManager.LoadScene(0);//Reload the Scene
    }

    public void ReceiveDamage(int dmg)
    {
        _Hp -= dmg;
    }

    /// <summary>
    /// Updates hp and UI
    /// </summary>
    public int _Hp
    {
        get { return _curHp; }
        set
        {
            _curHp = Mathf.Clamp(value,0, 100);//can have max 100 hp
            if(_curHp<=0)
            {
                Die();
            }
            _hpSlider.value = _curHp / (float) _maxHp;
        }
    }
}
