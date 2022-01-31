using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void Continue()
    {
        //Stop game over script
        this.gameObject.GetComponent<GameOver>().buttonClick = true;
        //Delete all asteroid
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach(var g in gameObjects)
        {
            Destroy(g);
        }
        //Close UI
        Destroy(this.gameObject);
        //Continue spore
        GameObject score = GameObject.Find("CountScore");
        score.GetComponent<Score>().GameIsActive = true;
        score.GetComponent<Score>().StartScore();
        //Spawn starship
        GameObject.Find("Main Camera").GetComponent<SpaceshipSpawn>().Spawn();
    }
}
