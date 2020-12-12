using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    Collider2D col;
    //public float rotationSpeed;
    public float rotZ;
    public bool rotate;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        Debug.Log("RotatePlatformTest: collider " + col);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Collider2D touchedCollider = Physics2D.OverlapPoint(wp);
            if (col == touchedCollider)
            {
                rotate = true;
                Debug.Log("RotatePlatformTest: Touch Detected");
            }
        }
        if (rotate)
        {
            rotZ += -5f;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            Debug.Log("RotatePlatformTest: rotZ value is " + rotZ);

            if (rotZ % 90 == 0)
            {
                rotate = false;
                Debug.Log("RotatePlatformTest: rotate is " + rotate);
            }
            if (rotZ % 360 == 0) {
                rotZ = 0;
            }
        }
    }
}