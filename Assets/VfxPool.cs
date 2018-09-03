using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxPool : MonoBehaviour {

    private static VfxPool instance;

    public static VfxPool Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private GameObject vfxPrefab;

    [SerializeField]
    private int size;

    private List<GameObject> vfxList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PrepareVFX();
        }
        else
            Destroy(gameObject);
    }

    private void PrepareVFX()
    {
        vfxList = new List<GameObject>();
        for (int i = 0; i < size; i++)
            AddVFX();
    }

    public GameObject GetVFX()
    {
        if (vfxList.Count == 0)
            AddVFX();
        return AllocateVFX();
    }

    public void ReleaseVFX(GameObject vfx)
    {
        vfx.gameObject.SetActive(false);
        vfxList.Add(vfx);
    }

    private void AddVFX()
    {
        GameObject instance = Instantiate(vfxPrefab);
        instance.gameObject.SetActive(false);
        vfxList.Add(instance);
    }

    private GameObject AllocateVFX()
    {
        GameObject vfx = this.vfxList[this.vfxList.Count - 1];
        vfxList.RemoveAt(this.vfxList.Count - 1);
        vfx.gameObject.SetActive(true);
        return vfx;
    }
}
