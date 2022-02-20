using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleRespawnUI : MonoBehaviour
{
    public GameObject respawnUI;

    public void VisibleRespawn()
    {
        respawnUI.SetActive(true);
        respawnUI.GetComponent<GameOverUI>().StartScript();
    }
}
