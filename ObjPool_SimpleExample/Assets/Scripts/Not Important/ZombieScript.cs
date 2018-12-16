using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

    public float _movSpeed;

	void FixedUpdate () {
        transform.position += transform.forward * _movSpeed * Time.fixedDeltaTime;
	}
}
