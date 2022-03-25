using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRemove : MonoBehaviour
{
    public GameObject explosionParticlePrefab;
    private bool checkOneTry = false;

    private void OnCollisionEnter(Collision other)
    {
        if (checkOneTry == false)
        {
            GameObject thisGO = this.gameObject;
            string colliderTag = other.collider.tag;
            List<string> listTags = new List<string> { "Bullet", "Starship", "AsteroidTrigger" };
            if (listTags.Contains(colliderTag))
            {
                checkOneTry = true;
                switch (colliderTag)
                {
                    case "Bullet":
                        if (thisGO.tag == "Crystal")
                        {
                            Money money = GameObject.Find("CountMoney").GetComponent<Money>();
                            money.countMoney++;
                            money.UpdateMoney();
                        }
                        AsteroidDestroy(thisGO);
                        break;
                    case "Starship":
                        if (GameObject.Find("CountHealth").GetComponent<Health>().countHealth > 1)
                        {
                            AsteroidDestroy(thisGO);
                        }
                        break;
                    case "AsteroidTrigger":
                        Destroy(thisGO);
                        break;
                }
            }
        }
    }

    private void AsteroidDestroy(GameObject thisGO)
    {
        ParticleSystem explosionParticle = explosionParticlePrefab.GetComponentInChildren<ParticleSystem>();
        ParticleSystem ps = ParticleSystem.Instantiate(explosionParticle, thisGO.transform.position, Quaternion.identity);
        ps.Play();
        ps.GetComponent<AudioSource>().Play();
        Destroy(thisGO);
    }
}
