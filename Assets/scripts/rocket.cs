using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class rocket : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotatespeed;
    private Rigidbody rb;
    public GameObject explosion;
    private bool missileishit = false;
 
    
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        DoRotate();
    }
    void DoRotate()
    {
        Vector3 targetdir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(targetdir);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation,rot,rotatespeed*Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(other.gameObject);
        Destroy(explosionObj, 2f);
        if (!missileishit)
        {
            SoundManager.instance.MissileHit();
            missileishit = true;
        }
        
       
    }
}
