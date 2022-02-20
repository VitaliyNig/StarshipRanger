using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangar : MonoBehaviour
{
    public Text buttonSelect;
    public void Check()
    {
        if(this.gameObject.GetComponent<MenuSpaceship>().spaceshipId == PlayerPrefs.GetInt("SpaceshipId"))
        {
            buttonSelect.text = "Selected";
        }
        else
        {
            buttonSelect.text = "Select";
        }
    }
}
