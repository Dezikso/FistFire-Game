using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float timeToDespawn = 3f;


    private void OnEnable()
    {
        //StartCoroutine(nameof(StartDespawnCooldown));
    }

    private IEnumerator StartDespawnCooldown()
    {
        yield return new WaitForSeconds(timeToDespawn);
        ReturnToPoool();
        
    }

    private void ReturnToPoool()
    {
        this.gameObject.SetActive(false);
    }

}
