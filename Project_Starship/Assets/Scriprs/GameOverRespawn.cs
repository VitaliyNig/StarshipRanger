using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverRespawn : MonoBehaviour
{
    public GameObject respawnUI;
  
    private void OnCollisionEnter(Collision other) 
    {
        RespawnMenu();
        Destroy(this.gameObject);
    }

    void RespawnMenu()
    {
        GameObject.Find("CountScore").GetComponent<Score>().GameIsActive = false;
        GameObject respawnMenu = Instantiate<GameObject>(respawnUI, GameObject.Find("Canvas").transform);
    }
}