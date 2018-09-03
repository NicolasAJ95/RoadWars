using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField]
    private float damage;
    [SerializeField]
    private float explosionRatio;

    private Rigidbody rocketRb;

    void Start () {
        rocketRb = GetComponent<Rigidbody>();
	}

    private void ExplosionDamage()
    {
        GameObject explosion = VfxPool.Instance.GetVFX();
        explosion.transform.position = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRatio);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].CompareTag("Enemy"))
            colliders[i].SendMessage("ReceiveDamage", damage);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        ExplosionDamage();
        
        RocketPool.Instance.ReleaseRocket(rocketRb);
    }
}
