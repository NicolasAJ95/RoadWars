using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {

    [SerializeField]
    private int bulletsAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Ammo received");
        col.SendMessageUpwards("ReceiveAmmo", bulletsAmount);
        Destroy(this.gameObject);
        if (col.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Ammo received");
            col.SendMessageUpwards("ReceiveAmmo", bulletsAmount);
        }
    }
}
