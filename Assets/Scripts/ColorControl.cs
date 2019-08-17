using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour {
    public Material         livingRoomMat;
    private float            tilingTweak;

    public static ColorControl S;


    void Awake() {
        ResetColor();
        S = this;
    }

    // Update is called once per frame
    void Update() {
        livingRoomMat.mainTextureScale = new Vector2(tilingTweak, .1f);
    }

    public void IncreaseTilingTweak() {
        tilingTweak += .001f;
    }

    public void ResetColor() {
        tilingTweak = 1;
    }
}
