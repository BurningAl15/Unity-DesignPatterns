using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5;

    private Animator animator;


	// Use this for initialization
	void Awake () {
        animator = transform.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);

        if (Input.GetButtonDown("Fire1"))
            animator.SetTrigger("Attack");
	}
}
