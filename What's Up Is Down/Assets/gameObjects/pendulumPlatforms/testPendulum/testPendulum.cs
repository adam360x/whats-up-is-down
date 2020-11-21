using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPendulum : MonoBehaviour
{
    // used for detecting if object is touched
    Collider2D col;
    // radius and speed of pendulum rotation
    public float rotationRadius = 2f;
    public float angularSpeed = 2f;
    // x,y positions for when object rotates around center
    float posX, posY = 0;
    // angle of object
    public float angle;
    // determines if object can rotate
    public bool rotate;

    //Used to increment rotation around center by 90 degrees
    bool firstRotate = false;
    bool secondRotate = false;
    bool thirdRotate = false;
    bool fourthRotate = false;






    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        Debug.Log("PendulumPlatformTest: collider " + col);

        // Code checks location of the platform relative to the center object and assigns the current angle based on this
        Transform platform = transform.Find("Platform1");
        Debug.Log("PendulumPlatformTest: platform " + platform);
        if (transform.position.y > platform.position.y)
        {
            angle = -Mathf.PI / 2;
            secondRotate = true;
            Debug.Log("PendulumPlatformTest: Angle is " + angle + " secondRotate is " + secondRotate);
        }
        if (transform.position.y < platform.position.y)
        {
            angle = -Mathf.PI - Mathf.PI / 2;
            fourthRotate = true;
            Debug.Log("PendulumPlatformTest: Angle is " + angle + " fourthRotate is " + fourthRotate);

        }
        if (transform.position.x < platform.position.x)
        {
            angle = 0;
            firstRotate = true;
            Debug.Log("PendulumPlatformTest: Angle is " + angle + " firstRotate is " + firstRotate);
        }
        if (transform.position.x > platform.position.x)
        {
            angle = -Mathf.PI;
            thirdRotate = true;
            Debug.Log("PendulumPlatformTest: Angle is " + angle + " thirdRotate is " + thirdRotate);

        }

        //if (firstRotate)
        //{
        //    angle = 0;
        //}
        //if (secondRotate)
        //{
        //    angle = -Mathf.PI / 2;
        //}
        //if (thirdRotate)
        //{
        //    angle = -Mathf.PI;
        //}
        //if (fourthRotate)
        //{
        //    angle = -Mathf.PI - Mathf.PI / 2;
        //}

        // Finds the radius of the rotation.
        if (transform.position.x - platform.position.x > 0)
        {
            rotationRadius = transform.position.x - platform.position.x;
            Debug.Log("PendulumPlatformTest: rotationRadius is " + roationRadius);
        }
        else
        {
            rotationRadius = transform.position.y - platform.position.y;
            Debug.Log("PendulumPlatformTest: rotationRadius is " + roationRadius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Determines if center object is touched. If so, rotate
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Collider2D touchedCollider = Physics2D.OverlapPoint(wp);
            if (col == touchedCollider)
            {
                rotate = true;
                Debug.Log("PendulumPlatformTest: Touched Pendulum Platform");
            }
        }
        // Rotates as object around center object and rotates object to face center
        if (rotate)
        {
            // Gets child platform
            Transform platform = transform.Find("Platform1");
            // Determine x and y positions for rotation
            posX = transform.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = transform.position.y + Mathf.Sin(angle) * rotationRadius;

            Debug.Log("PendulumPlatformTest: posX is " + posX + " posY is " + posY);

            // Move platform to new rotation coordinates
            platform.position = new Vector2(posX, posY);
            //rotate platform so that it faces the center object
            platform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);
            // increment angle
            angle = angle - Time.deltaTime * angularSpeed;

            Debug.Log("PendulumPlatformTest: angle is " + angle);

            // Stops rotation if first rotation finishes
            if ((angle < -Mathf.PI / 2) && firstRotate)
            {
                rotate = false;
                firstRotate = false;
                secondRotate = true;
                angle = -Mathf.PI / 2;
                platform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);
                Debug.Log("PendulumPlatformTest: rotate is " + rotate + " and secondRotate is " + secondRotate);
            }
            // Stops rotation if second rotation finishes
            if (angle < -Mathf.PI && secondRotate)
            {
                rotate = false;
                secondRotate = false;
                thirdRotate = true;
                angle = -Mathf.PI;
                platform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);
                Debug.Log("PendulumPlatformTest: rotate is " + rotate + " and thirdRotate is " + thirdRotate);
            }
            // Stops rotation if third rotation finishes
            if (angle < -(Mathf.PI + Mathf.PI / 2) && thirdRotate)
            {
                rotate = false;
                thirdRotate = false;
                fourthRotate = true;
                angle = -Mathf.PI - Mathf.PI / 2;
                platform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);
                Debug.Log("PendulumPlatformTest: rotate is " + rotate + " and fourthRotate is " + fourthRotate);

            }
            // Stops rotation if fourth rotation finishes. Resets angle.
            if (angle < -(2 * Mathf.PI) && fourthRotate)
            {
                rotate = false;
                fourthRotate = false;
                angle = 0;
                firstRotate = true;
                platform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);
                Debug.Log("PendulumPlatformTest: rotate is " + rotate + " and fourthRotate is " + fourthRotate);
            }
        }
    }
}