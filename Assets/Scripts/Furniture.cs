using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Furniture: MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    
    public Vector3 oP;
    private float overallDistanceTravelled;
    private Quaternion oR;
    
    public AudioSource ambience, chime;

    public int controllerNumber;
    
    public bool pitchController, effectController, synthController;

    public static Furniture S;

    void Awake() {
        
        oP = transform.localPosition;
        //oR = transform.rotation;
        S = this;
    }    
    
    void OnMouseDown(){
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
		
    void OnMouseDrag(){
        
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.localPosition = new Vector3(cursorPosition.x, cursorPosition.y, oP.z);
        
        // Get overall distance
        overallDistanceTravelled = Vector3.Distance(transform.localPosition, oP);
        
        ColorControl.S.IncreaseTilingTweak();

        if (pitchController) {
            ambience.pitch = 1 - (overallDistanceTravelled / 20f);
        }

        if (effectController) {
            ambience.GetComponent<AudioHighPassFilter>().cutoffFrequency = 3000 - (overallDistanceTravelled * 1000f);
        }

        if (synthController) {
            OSCsender.S.UpdateSynth(controllerNumber, overallDistanceTravelled);
            OSCsender.S.SendAudio(controllerNumber);
        }
    }

    public void Reset() {
        transform.localPosition = oP;
        transform.rotation = oR;
        if(pitchController) ambience.pitch = 1f;
        if (effectController) ambience.GetComponent<AudioHighPassFilter>().cutoffFrequency = 3000;
        
    }

}