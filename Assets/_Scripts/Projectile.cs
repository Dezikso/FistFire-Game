using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float timeToDespawn = 2f;
    private Vector3 translateDirection;
    private bool isPunched = false;


    private void OnEnable()
    {
        isPunched = false;
        //StartCoroutine(nameof(DespawnOverTime));
    }

    private void Update()
    {
        if (isPunched)
        {
            gameObject.transform.Translate(translateDirection * Time.deltaTime, Space.World);
        }
    }

    
    private void InitializeProjectile()
    {

    }

    public void OnPunch()
    {
        isPunched = true;
        translateDirection = Camera.main.transform.forward;
    }

    #region Despawn functionality
    private IEnumerator DespawnOverTime()
    {
        yield return new WaitForSeconds(timeToDespawn);
        Despawn();
        
    }

    private void Despawn()
    {
        this.gameObject.SetActive(false);
    }
    #endregion

}
