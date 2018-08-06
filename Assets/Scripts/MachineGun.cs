using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour {

    public float bulletDamage;
    private int ammoCapacity = 180;
    public int actualAmmo;
    public float ratio;
    public float range;
    public bool isReloading;
    public float reloadTime;
    public bool canShoot;

    private Transform pTransform;
    private ParticleSystem shootingParticle;
    private Transform pCamera;

    // Use this for initialization
    void Start () {
        actualAmmo = ammoCapacity;
        pTransform = this.GetComponent<Transform>();
        pCamera = Camera.main.GetComponent <Transform>();
        shootingParticle = GetComponentInChildren<ParticleSystem>();
        canShoot = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot && actualAmmo > 0)
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //pTransform.RotateAround(pCamera.forwardthis.transform.position );
            pTransform.forward = pCamera.forward;
        }

    }

    IEnumerator Shoot()
    {
        shootingParticle.Play();
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Debug.Log("shooting");
            canShoot = false;
          
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            Debug.Log("shooting");
            canShoot = false;
        }

        actualAmmo--;
        yield return new WaitForSeconds(ratio);
        canShoot = true;
    }
}
