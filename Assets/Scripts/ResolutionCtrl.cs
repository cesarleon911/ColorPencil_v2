using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionCtrl : MonoBehaviour
{
    public float ascpect;
    public float rounded;

    
    CanvasScaler cv;


    // Start is called before the first frame update
    void Start()
    {
        cv = this.GetComponent<CanvasScaler>();
        updateResolution();
        
    }

    public void updateResolution() {
        //si resolucion 1920*1080
        ascpect = Camera.main.aspect;
        rounded = (int)(ascpect * 100.0f) / 100.0f;

        if (rounded == 1.65f || rounded == 1.66f || rounded == 1.57f) { //resoluciones * 720p
            uptadateRatios(0, 5.34f);
        }else if (rounded == 2.04f || rounded == 2.05f || rounded == 2.06f) {
            uptadateRatios(0.88f, 4.89f);
        } else if (rounded == 1.70f || rounded == 1.71f || rounded == 1.69f) {
            uptadateRatios(0, 5.21f);
        } else if (rounded == 1.33f || rounded == 1.32f || rounded == 1.34f) {
            uptadateRatios(0, 6.77f);
        } else if (rounded == 1.85f || rounded == 2 || rounded == 2.17f || rounded == 2.16f) {
            uptadateRatios(1,5);
        } else if (rounded == 2.11f) { // resoluciones 2280 * 1080
            uptadateRatios(1, 4.75f);
        } else {  // resoluciones 19:9 de tipo 1920*1080
            uptadateRatios(0, 5);
        }


    }

    public void uptadateRatios(float m, float sz) {
        if (cv != null) {
            cv.matchWidthOrHeight = m;
        }
        Camera.main.orthographicSize = sz;
    }
}
