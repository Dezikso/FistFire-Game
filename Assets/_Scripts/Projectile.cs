using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float timeToDespawn = 2f;


    private void OnEnable()
    {
        //StartCoroutine(nameof(DespawnOverTime));
    }

    private IEnumerator DespawnOverTime()
    {
        yield return new WaitForSeconds(timeToDespawn);
        ReturnToPoool();
        
    }

    private void ReturnToPoool()
    {
        this.gameObject.SetActive(false);
    }


    //TEMPORARY DEBUG SYSTEM
    //DELETE LATER

    public bool isPunched = false;
    public Vector3 rayDir;

    
    private void Update()
    {     
        if (isPunched)
        {
            gameObject.transform.Translate(rayDir, Space.World);
        }
        
    }
    //UP TO THIS POINT

}
