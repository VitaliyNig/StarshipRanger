using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemove : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        Destroy(this.gameObject);
    }
}
