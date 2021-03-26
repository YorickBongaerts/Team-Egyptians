using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField] private Transform _copyFrom = null;

    void Start()
    {
        transform.localScale = _copyFrom.localScale;
    }
}