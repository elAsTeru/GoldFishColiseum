using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFront : MonoBehaviour
{
    [Tooltip("Às‚·‚é‚©‚Ç‚¤‚©")][SerializeField] bool isRun = true;
    [Tooltip("‘ÎÛ‚Ì•¨—‹““®")][SerializeField]Rigidbody rb;

    void Update()
    {
        if (isRun && rb)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.DrawRay(this.transform.position, rb.velocity / 2, Color.blue);
        }
    }
}