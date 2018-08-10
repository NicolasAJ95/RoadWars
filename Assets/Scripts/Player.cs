using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float health;
    private float specialMeter;

    [SerializeField]
    private bool drivingState;
    [SerializeField]
    private bool shootingState;

    [SerializeField]
    private Animator pAnimator;

	// Use this for initialization
	void Start () {
        pAnimator = GetComponent<Animator>();
        health = 100;
        specialMeter = 10;
        drivingState = true;
	}
	
	// Update is called once per frame
	void Update () {
      /*  if (Input.GetKey(KeyCode.LeftShift))
        {
            pAnimator.SetBool("isShooting", true);
            pAnimator.SetBool("isDriving", false);
            shootingState = true;
            drivingState = false;
        } else if (Input.GetKeyUp(KeyCode .LeftShift))
        {
            pAnimator.SetBool("isShooting", false);
            pAnimator.SetBool("isDriving", true);
            shootingState = false;
            drivingState = true;
        }*/
        if (Input.GetAxis("Aim") != 0)
        {
            pAnimator.SetBool("isShooting", true);
            pAnimator.SetBool("isDriving", false);
            shootingState = true;
            drivingState = false;
        } else if (Input.GetAxis("Aim") == 0)
        {
            pAnimator.SetBool("isShooting", false);
            pAnimator.SetBool("isDriving", true);
            shootingState = false;
            drivingState = true;
        }


    }

    public void ReceiveDamage(float damage)
    {
        health = -damage;
    }
}
