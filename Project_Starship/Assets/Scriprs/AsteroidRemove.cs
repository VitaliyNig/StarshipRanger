using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRemove : MonoBehaviour
{
    public ParticleSystem explosionParticlePrefab;
    
    private void OnCollisionEnter(Collision other) {
        if(other.collider.name == "AsteroidRemove")
        {
            Destroy(this.gameObject);
        }
        else if(other.collider.name == "Bullet(Clone)")
        {
            ParticleSystem.Instantiate(explosionParticlePrefab, this.gameObject.transform.position, Quaternion.identity).Play();
            Destroy(this.gameObject);
        }
    }
}
