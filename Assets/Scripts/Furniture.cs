using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Furniture: MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 oP;
    private Quaternion oR;
    
    public AudioSource ambience, chime;
    public bool pitchController, effectController;

    void Awake() {
        oP = transform.localPosition;
        oR = transform.rotation;

    }    
    
    void OnMouseDown(){
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
		
    void OnMouseDrag(){
        
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.localPosition = new Vector3(cursorPosition.x, cursorPosition.y, oP.z);
        ColorControl.S.IncreaseTilingTweak();

        if (pitchController) {
            ambience.pitch = 1 + (cursorPosition.x - oP.x) / 10f;
        }

        if (effectController) {
            ambience.GetComponent<AudioHighPassFilter>().cutoffFrequency = 3000 - (cursorPosition.y - oP.y) * 500f;
        }
    }

    public void Reset() {
        transform.localPosition = oP;
        transform.rotation = oR;
        if(pitchController) ambience.pitch = 1f;
        if (effectController) ambience.GetComponent<AudioHighPassFilter>().cutoffFrequency = 3000;
        
    }

}