using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class turretspin : MonoBehaviour
{
    public Transform _turretspin;
    
    void Start()
    {
        // if (launcher.instance.updatetarget())
        // {
        //     
        // }
        SpinTurret();
    }
    void SpinTurret()
    {
        _turretspin.transform.DOLocalRotate(new Vector3(0f, 0, 90), 1f)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
    }

    
}
