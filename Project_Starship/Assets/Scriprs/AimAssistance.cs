using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistance : MonoBehaviour
{
    private float radiusAssistance;

    private void Start()
    {
        radiusAssistance = (0.3f * PlayerPrefs.GetInt("Aim Assistance"));
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radiusAssistance, 1 << 12);
        if (colliders != null)
        {
            foreach (var c in colliders)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, c.transform.position, 0.05f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radiusAssistance);
    }
}
