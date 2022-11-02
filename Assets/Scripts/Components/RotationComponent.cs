using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    [SerializeField] private Quaternion newRotation;

    public void NewRotation()
    {
        this.transform.rotation = newRotation;
    }
    public void NewRotationOn180()
    {
        this.transform.rotation = Quaternion.Euler(0,0, this.transform.rotation.eulerAngles.z + 180);
    }
}
