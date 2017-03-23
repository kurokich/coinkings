using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class UserRegistWindow : MonoBehaviour {
    public ConnectAPI Connecter;
    public string name;
    public string udid;
    private const string PASSWORD_CHARS = "0123456789abcdefghijklmnopqrstuvwxyz";

    private void Start()
    {
        GameObject.Find("PassInput").GetComponent<UIInput>().value = GenerateUID(12);
        Connecter = GameObject.Find("UI Root").GetComponent<ConnectAPI>();
    }
    public void RegistBotton(){
        udid = GameObject.Find("PassInput").GetComponent<UIInput>().value;
        name = GameObject.Find("UseNameInput").GetComponent<UIInput>().value;
        if (name != null && udid != null)
        {
            Connecter.membername = name;
            Connecter.udid = udid;
            Connecter.GetRegist(name,udid);
            gameObject.SetActive(false);
            if (Connecter.data.success == 1)
            {
                Debug.Log("☆ユーザー登録完了");
                Connecter.LoadInfomation();
            }
        }
    }
    public void CancelBotton()
    {
        gameObject.SetActive(false);
    }

    public static string GenerateUID(int length)
    {
        var sb = new System.Text.StringBuilder(length);
        var r = new System.Random();

        for (int i = 0; i < length; i++)
        {
            int pos = r.Next(PASSWORD_CHARS.Length);
            char c = PASSWORD_CHARS[pos];
            sb.Append(c);
        }

        return sb.ToString();
    }
}

