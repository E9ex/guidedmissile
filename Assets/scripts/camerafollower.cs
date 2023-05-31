using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public Transform target;
    public bool ischasing;
    private launcher _launcher;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            target = GameObject.FindObjectOfType<rocket>().gameObject.transform;
            transform.parent = null;
            ischasing = true;
           launcher.instance.enabled = false;
        }
    }
    private void LateUpdate()
    {
        if (ischasing && target != null)
        {
            transform.forward = target.forward;
            transform.position=Vector3.Lerp(transform.position,target.position,Time.deltaTime);
        }
    }
}
