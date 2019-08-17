using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Furniture[] furniture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset() {
        ColorControl.S.ResetColor();

        for(int i=0; i < furniture.Length; i++) {
            furniture[i].Reset();

        }
    }
}
