using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{ 
    void Update()
    {
        transform.Translate(Vector3.forward*45*Time.deltaTime);
    }
}
