using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFront : MonoBehaviour
{
    [Tooltip("実行するかどうか")][SerializeField] bool isRun = true;
    [Tooltip("対象の物理挙動")][SerializeField]Rigidbody rb;

    void Update()
    {
        if (isRun && rb)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.DrawRay(this.transform.position, rb.velocity / 2, Color.blue);
        }
    }
}