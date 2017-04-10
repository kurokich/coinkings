using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class UserRegistWindow : MonoBehaviour {
    public ConnectAPI Connecter;

    private void Start()
    {
        Connecter = GameObject.Find("UI Root").GetComponent<ConnectAPI>();
    }
    public void RegistBotton(){
        string name = GameObject.Find("UseNameInput").GetComponent<UIInput>().value;
        string udid = GameObject.Find("PassInput").GetComponent<UIInput>().value;

        if (name != null && udid != null)
        {
            Connecter.membername = name;
            Connecter.udid = udid;
            Connecter.GetRegist();
            gameObject.SetActive(false);
        }
    }
    public void CancelBotton()
    {
        gameObject.SetActive(false);
    }
}
