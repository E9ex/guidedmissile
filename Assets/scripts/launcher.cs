using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    private Camera cam;
    public LayerMask targetmask;
    public Transform target;
    private GameObject focusobject;
    public Transform exitpoint;
    public GameObject rocketprefab;

    private void Awake()
    {
        cam=Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                GameObject temp = Instantiate(rocketprefab, exitpoint.position, Quaternion.identity);
                temp.transform.forward = transform.forward;
                if (temp.TryGetComponent(out rocket rocket))
                {
                    //rocket.target = focusobject.transform;
                    rocket.target = target;
                }
                else
                {
                    focusobject = null;
                }
        }
    }
    private void FixedUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity,targetmask))
        {
            focusobject = hit.collider.gameObject;
        }
        else
        {
            focusobject = null;
        }
    }
}
