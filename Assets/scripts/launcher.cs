using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class launcher : MonoBehaviour
{
    private Camera cam;
    public LayerMask targetmask;
    public Transform target;
    private GameObject focusobject;
    public Transform exitpoint;
    public GameObject rocketprefab;
    private float range = 250;
    public static  launcher instance;
    private turretspin _turretspin;


    private void Awake()
    {
        _turretspin = GetComponent<turretspin>();
        instance = this;
        cam=Camera.main;
        InvokeRepeating("updatetarget",0f,0.5f);
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

        if (target==null)
        {
            return;
        }
        
    }
    private void FixedUpdate()
    {
        // Collider[] colliders = Physics.OverlapSphere(transform.position, range, targetmask);
        // if (colliders.Length > 0)
        // {
        //     focusobject = colliders[0].gameObject;
        // }
        // else
        // {
        //     focusobject = null;
        // }
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

    public void updatetarget()
    {
        GameObject [] fighters = GameObject.FindGameObjectsWithTag("enemy");
        float shortestdistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject fighter in fighters)
        {
            float distancetoenemy = Vector3.Distance(transform.position,  fighter.transform.position);
            if (distancetoenemy<shortestdistance)
            {
                shortestdistance = distancetoenemy;
                nearestEnemy = fighter;
            }
        }
        if (nearestEnemy!=null&& shortestdistance<=range)
        {
            target = nearestEnemy.transform;
            _turretspin.transform.DOKill();
            transform.LookAt(target);
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    // void SpinTurret()
    // {
    //     
    //         Launcher.transform.DOLocalRotate(new Vector3(0f, 0, 90), 1f)
    //             .SetLoops(-1, LoopType.Incremental)
    //             .SetEase(Ease.Linear).SetOptions(islooking);
    //     
    // }
}
