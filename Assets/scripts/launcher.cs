using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    private Camera cam;
    public LayerMask targetmask;
    public float focustime;
    private GameObject focusobject;
    public Transform exitpoint;
    public GameObject rocketprefab;

    private void Awake()
    {
        cam=Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        focustimer();
        if (Input.GetMouseButtonDown(0))
        {
            if (focustime>=2)
            {
                GameObject temp = Instantiate(rocketprefab, exitpoint.position, Quaternion.identity);
                temp.transform.forward = transform.forward;
                if (temp.TryGetComponent(out rocket rocket))
                {
                    rocket.target = focusobject.transform;
                }

                focusobject = null;
            }
        }
    }

    void focustimer()
    {
        if (focusobject)
        {
            focustime += Time.deltaTime;
        }
        else
        {
            focustime = 0;
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
