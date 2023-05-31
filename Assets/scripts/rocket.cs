using System;
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
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        var sound = SoundManager.instance.GetSound(SoundType.MissileFire);
        _audioSource.volume = sound.volume;
        _audioSource.PlayOneShot(sound.audioClip);
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
