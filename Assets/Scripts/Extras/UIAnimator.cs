using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject FullElement;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        Star1.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, _rotationSpeed)*Time.deltaTime);
        Star2.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -_rotationSpeed) * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, MaxRotation * Mathf.Sin(Time.time * SwingSpeed));
        float scale = Mathf.Abs(Mathf.Sin(Time.time * _scaleSpeed));
        FullElement.transform.localScale = new Vector3(0.75f, 0.75f, 0) + new Vector3(scale/4, scale/4, 0);
    }
}
