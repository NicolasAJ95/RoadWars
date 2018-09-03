using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxDestroyer : MonoBehaviour {

    [SerializeField]
    private float destroyTime;

    // Use this for initialization
    private void OnEnable()
    {
        StartCoroutine("DestroyVFX");
    }

    private IEnumerator DestroyVFX()
    {
        yield return new WaitForSeconds(destroyTime);
        VfxPool.Instance.ReleaseVFX(this.gameObject);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
