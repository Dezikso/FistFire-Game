using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTarget : MonoBehaviour
{
    [SerializeField] private Material material1;
    [SerializeField] private Material material2;

    private bool materialBool;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            materialBool = !materialBool;

            if (materialBool)
            {
                gameObject.GetComponent<MeshRenderer>().material = material1;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material = material2;
            }
        }
    }
}
