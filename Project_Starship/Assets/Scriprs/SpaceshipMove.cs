using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipMove : MonoBehaviour
{
    private Vector3 lastPos;
    private bool screenStatusGame = false;
    private bool screenStatusHangar = false;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                screenStatusGame = true;
                lastPos = this.transform.position;
                break;
            case "Hangar":
                screenStatusHangar = true;
                break;
        }
    }

    private void Update()
    {
        if (screenStatusGame == true)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 touchPos2D = Input.mousePosition;
                    touchPos2D.z = -Camera.main.transform.position.z;
                    Vector3 touchPos3D = Camera.main.ScreenToWorldPoint(touchPos2D);

                    Vector3 spaceshipPos = this.transform.position;
                    spaceshipPos.x = touchPos3D.x;
                    this.transform.position = Vector3.Lerp(this.transform.position, spaceshipPos, 0.5f);

                    if (lastPos.x > this.transform.position.x)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 30f), 3f);
                    }
                    else if (lastPos.x < this.transform.position.x)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -30f), 3f);
                    }

                    lastPos = this.transform.position;
                }
            }

            if (lastPos.x == this.transform.position.x)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f), 0.3f);
            }
        }
        else if (screenStatusHangar == true)
        {
            if (Input.touchCount > 0)
            {
                float rotateSpeed = 0.1f;
                Touch touchZero = Input.GetTouch(0);

                if (touchZero.phase == TouchPhase.Moved)
                {
                    this.transform.Rotate(-(rotateSpeed * touchZero.deltaPosition.y), -(rotateSpeed * touchZero.deltaPosition.x), 0f);
                }
            }
        }
    }
}
