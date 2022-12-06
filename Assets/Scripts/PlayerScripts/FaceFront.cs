using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFront : MonoBehaviour
{
    [Tooltip("���s���邩�ǂ���")][SerializeField] bool isRun = true;
    [Tooltip("�Ώۂ̕�������")][SerializeField]Rigidbody rb;

    void Update()
    {
        if (isRun && rb)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.DrawRay(this.transform.position, rb.velocity / 2, Color.blue);
        }
    }
}