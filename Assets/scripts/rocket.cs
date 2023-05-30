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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        DoRotate();
      //  Debug.Log("fixedupdaterocket");
    }
    void DoRotate()
    {
        //Debug.Log("dorotate");
        Vector3 targetdir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(targetdir);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation,rot,rotatespeed*Time.deltaTime));
    }
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
