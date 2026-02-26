using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScale : MonoBehaviour {

    public float scaleSpeedX = 1f;
    public float scaleSpeedY = 1f;

    void Start () {

    }
	
	void Update (){
        
        transform.localScale += new Vector3(scaleSpeedX, scaleSpeedY, 0) * Time.deltaTime;
    }
}
