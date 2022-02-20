using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject countScoreUI;
    public GameObject countHealthUI;
    public GameObject mainCamera;

    public void Continue()
    {
        //Stop game over script
        this.gameObject.GetComponent<GameOverUI>().buttonClick = true;
        //Delete all asteroid
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach(var g in gameObjects)
        {
            Destroy(g);
        }
        //Close UI
        this.gameObject.SetActive(false);
        //Continue spore
        Score score = countScoreUI.GetComponent<Score>();
        score.GameIsActive = true;
        score.StartScore();
        //Add health
        Health health = countHealthUI.GetComponent<Health>();
        health.countHealth++;
        health.UpdateHealth();
        //Spawn starship
        mainCamera.GetComponent<SpaceshipSpawn>().Spawn();
    }
}
