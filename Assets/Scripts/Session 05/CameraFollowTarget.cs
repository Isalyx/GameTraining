using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public GameObject Target;

    private void LateUpdate()
    {
        transform.LookAt(Target.transform);
    }
}
