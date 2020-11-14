using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public float minZoom;
    public float maxZoom;
    private float currentZoom;
    public float zoomSpeed;
    public float waitTimeForZoomIn;
    float timer;
    bool zoomOut;
    bool startZoom;
    public Camera main_camera;

    // Start is called before the first frame update
    void Start()
    {
        currentZoom = minZoom;
        main_camera.orthographicSize = currentZoom;
        timer = 0;
        startZoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomOut == true || startZoom == true) {
            if (currentZoom < maxZoom) {
                currentZoom = currentZoom + zoomSpeed*Time.deltaTime;
            } else {
                currentZoom = maxZoom;
                startZoom = false;
            }
            main_camera.orthographicSize = currentZoom;
        } else {
            if (currentZoom > minZoom && timer == 0) {
            currentZoom = currentZoom - zoomSpeed*Time.deltaTime;
            main_camera.orthographicSize = currentZoom;
            } else if (timer == 0){
                currentZoom = minZoom;
                main_camera.orthographicSize = currentZoom;
            } else {
                timer = timer - Time.deltaTime;
                if (timer < 0) {
                    timer = 0;
                }
            }
        }
    }

    public void ZoomHold(){
        zoomOut = true;
        startZoom = true;
        timer = waitTimeForZoomIn;
    }
    public void ZoomRelease(){
        zoomOut = false;
    }
}
