using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistance : MonoBehaviour
{
    private float forceAssistance;
    private Vector3 sizeAssistance;
    private int layerMask;
    private Transform thisTransform;

    private void Start()
    {
        forceAssistance = (0.5f * PlayerPrefs.GetInt("Aim Assistance"));
        sizeAssistance.x = forceAssistance;
        sizeAssistance.y = forceAssistance;
        sizeAssistance.z = forceAssistance;
        layerMask = (1 << LayerMask.NameToLayer("Asteroid"));
    }

    private void FixedUpdate()
    {
        thisTransform = this.transform;
        Collider[] colliders = Physics.OverlapBox(thisTransform.position, sizeAssistance, thisTransform.localRotation, layerMask);
        if (colliders != null)
        {
            foreach (var c in colliders)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, c.transform.position, 0.5f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(thisTransform.position, thisTransform.rotation, thisTransform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, (sizeAssistance * 2));
    }
}
