using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipMove : MonoBehaviour
{   
    public Vector3 lastPos;

    void Start()
    {
        lastPos = this.transform.position;
    }

    void Update()
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
}
