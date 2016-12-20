using UnityEngine;
using System;
using System.Collections;

public class DebugScript : MonoBehaviour {

    public UILabel txtBox;        
    public ConnectAPI gobj;
    // Use this for initialization
    void Start () {        
        gobj = GetComponent<ConnectAPI>();
    }
	
	// Update is called once per frame
	void Update () {
        txtBox.text = gobj.data.data.debugStr();
	
	}
}
