using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public Transform target;
    public bool ischasing;
    private launcher _launcher;

    private void Awake()
    {
        _launcher = GetComponent<launcher>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            target = GameObject.FindObjectOfType<rocket>().gameObject.transform;
            transform.parent = null;
            ischasing = true;
            _launcher.enabled = false;
        }

        
    }

    private void LateUpdate()
    {
        if (ischasing)
        {
            transform.forward = target.forward;
            transform.position=Vector3.Lerp(transform.position,target.position,Time.deltaTime);
        }
    }
}
