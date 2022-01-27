using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipMove : MonoBehaviour
{   
    public Vector3 lastPos;
    bool screenStatusGame = false;
    bool screenStatusHangar = false;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "DevScene")
        {
            screenStatusGame = true;
            lastPos = this.transform.position;
        }
        else if(scene.name == "Hangar")
        {
            screenStatusHangar = true;
        }
    }

    void Update()
    {
        if(screenStatusGame == true)
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 touchPos2D = Input.mousePosition;
                    touchPos2D.z = -Camera.main.transform.position.z;
                    Vector3 touchPos3D = Camera.main.ScreenToWorldPoint(touchPos2D);

                    Vector3 spaceshipPos = this.transform.position;
                    spaceshipPos.x = touchPos3D.x;
                    this.transform.position = spaceshipPos;

                    if(lastPos.x > this.transform.position.x)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 30f), 3f);
                    }
                    else if(lastPos.x < this.transform.position.x)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -30f), 3f);
                    }

                    lastPos = this.transform.position;
                }
            }

            if(lastPos.x == this.transform.position.x)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f), 0.3f);
            }
        }
        else if(screenStatusHangar == true)
        {
            if(Input.touchCount == 1)
            {
                float rotateSpeed = 0.05f;
                Touch touchZero = Input.GetTouch(0);
    
                Vector3 localAngle = this.transform.localEulerAngles;
                localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
                localAngle.x -= rotateSpeed * touchZero.deltaPosition.y;
                this.transform.localEulerAngles = localAngle;
            }
        }
    }
}
