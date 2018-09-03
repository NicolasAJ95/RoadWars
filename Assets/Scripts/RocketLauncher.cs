using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour {

    [SerializeField]
    private Rigidbody rocket;
    [SerializeField]
    private float bulletDamage;
    [SerializeField]
    private Transform weaponBarrel;
    [SerializeField]
    private int ammoCapacity;
    [SerializeField]
    private int actualAmmo;
    [SerializeField]
    private int magazineBullets;
    [SerializeField]
    private int magazineSize;
    [SerializeField]
    private float ratio;
    [SerializeField]
    private float range;
    [SerializeField]
    private float shootForce;
    [SerializeField]
    private bool isReloading;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private bool canShoot;

    private Transform pTransform;
    private Quaternion originalPosition;
    private ParticleSystem shootingParticle;
    private Transform pCamera;

    [SerializeField]
    private GameObject targetFeedbackImg;
    [SerializeField]
    private Text bulletsGUI;

    // Use this for initialization
    void Start()
    {
       // targetFeedbackImg.SetActive(false);
        actualAmmo = ammoCapacity;
        magazineBullets = magazineSize;
        pTransform = this.GetComponent<Transform>();
        originalPosition = new Quaternion(0, 0, 0, 0);
        pCamera = Camera.main.GetComponent<Transform>();
        shootingParticle = GetComponentInChildren<ParticleSystem>();
        canShoot = true;
        bulletsGUI.text = magazineBullets.ToString() + "/" + actualAmmo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetAxis("Fire1") != 0 && canShoot && magazineBullets > 0)
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetAxis("Aim") != 0)
        {
            //pTransform.RotateAround(pCamera.forwardthis.transform.position );
            pTransform.forward = pCamera.forward;
            
        }
         else if (Input.GetAxis("Aim") == 0)
          {

              pTransform.rotation = originalPosition;
          }


    }

    public void ReceiveAmmo(int ammo)
    {
        if (actualAmmo < ammoCapacity)
        {
            actualAmmo += ammo;
            actualAmmo -= (actualAmmo - ammoCapacity);
            bulletsGUI.text = magazineBullets.ToString() + "/" + actualAmmo;
        }
    }

    IEnumerator ShootFeedback()
    {
        targetFeedbackImg.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        targetFeedbackImg.SetActive(false);
    }



    IEnumerator Shoot()
    {
        canShoot = false;
        Debug.Log("Shooting");
        bulletsGUI.text = magazineBullets.ToString() + "/" + actualAmmo;
        shootingParticle.Play();

        rocket = RocketPool.Instance.GetRocket();
        rocket.transform.position = weaponBarrel.position;
        rocket.AddForce(weaponBarrel.forward * shootForce);
      
        //StartCoroutine("ShootFeedback");
        

        magazineBullets--;

        if (magazineBullets <= 0)
        {
            StartCoroutine("Reload");
        }
        yield return new WaitForSeconds(ratio);
        canShoot = true;


    }

    IEnumerator Reload()
    {
        Debug.Log("Reloading");
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        if (actualAmmo > magazineSize)
        {
            magazineBullets = magazineSize;
            actualAmmo -= magazineSize;
        }
        else
        {
            magazineBullets = actualAmmo;
            actualAmmo -= actualAmmo;
        }

        canShoot = true;
    }
}
