using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    //Weapon Properties
    private float bulletDamage; 
    private int ammoCapacity;    
    private int actualAmmo;
    private float ratio;
    private float range;
    private bool isReloading;
    private float reloadTime;
    private bool canShoot;

    //Getters n Setters
    public float BulletDamage
    {
        get
        {
            return this.bulletDamage;
        }
        set
        {
            this.bulletDamage = value;
        }
    }

    public int AmmoCapacity
    {
        get
        {
            return this.ammoCapacity;
        }
        set
        {
            this.ammoCapacity = value;
        }
    }

    public int ActualAmmo
    {
        get
        {
            return this.actualAmmo;
        }
        set
        {
            this.actualAmmo = value;
        }
    }

    public float Ratio
    {
        get
        {
            return this.ratio;
        }
        set
        {
            this.ratio = value;
        }
    }

    public float Range
    {
        get
        {
            return this.range;
        }
        set
        {
            this.range = value;
        }
    }

    public bool IsReloading
    {
        get
        {
            return this.isReloading;
        }
        set
        {
            this.isReloading = value;
        }
    }

    public float ReloadTime
    {
        get
        {
            return this.reloadTime;
        }
        set
        {
            this.reloadTime = value;
        }
    }

    //Weapon Actions
    protected virtual void Shoot()
    {

    }

    protected virtual void Reload()
    {

    }


}
