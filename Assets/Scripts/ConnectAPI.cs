using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ConnectAPI : MonoBehaviour {

    public string membername = "test";
    public string udid = "wbti2urffzkh";
    public string result;
    public Data data;
    private Action postRegistFunction;
    private Action postSessionFunction;
    private Action postLoadInfomation;
    private Action postCoinChange;
    private Action postCoinGet;
    private ConnectAPI connectAPI;

    void Start()
    {
        connectAPI = GetComponent<ConnectAPI>();

        postRegistFunction = delegate
        {
            data = JsonUtility.FromJson<Data>(result);
        };
        postSessionFunction = delegate
        {
            data.session = JsonUtility.FromJson<Data>(result).session;
            data.success = JsonUtility.FromJson<Data>(result).success;

        };
        postLoadInfomation = delegate
        {
            data.data = JsonUtility.FromJson<Data>(result).data;
            data.success = JsonUtility.FromJson<Data>(result).success;

        };
        postCoinChange = delegate
        {
        };
        postCoinGet = delegate
        {
            //data = JsonUtility.FromJson<Data>(result).data;
        };

    }
    //会員登録
    public void GetRegist()
    {
        StartCoroutine(GetRequestURL("http://api.axions.jp/coin/api/mmember.do?param=entry&membername="+membername+"&code="+udid,postRegistFunction));        
    }
    //セッションスタート
    public void SessionStart()
    {
        //SCODEが取得できていない場合はスルー
        if (connectAPI.data.data.SCODE != null)
        {
            StartCoroutine(GetRequestURL("http://api.axions.jp/coin/api/mmember.do?param=session&scode=" + connectAPI.data.data.SCODE, postSessionFunction));
        }
    }
    //会員情報取得
    public void LoadInfomation()
    {
        //SCODEが取得できていない場合はスルー
        if (connectAPI.data.data.SCODE != null)
        {
            StartCoroutine(GetRequestURL("http://api.axions.jp/coin/api/mmember.do?param=get&scode=" + connectAPI.data.data.SCODE, postSessionFunction));
        }
    }
    //特殊コインリスト変更
    public void ChangeCoin(int count,int id)
    {
        if(count == 0)count = 1;
        if (id == 0) id = 1;
        //SCODEが取得できていない場合はスルー
        if (connectAPI.data.session != null)
        {
            StartCoroutine(GetRequestURL("http://api.axions.jp/coin/api/mholding.do?param=entry&session=" + connectAPI.data.session + "&limited=" + count + "&ownership_number=" + id, postCoinChange));
        }
    }
    //特殊コインリスト取得
    public void GetCoin()
    {
        //SCODEが取得できていない場合はスルー
        if (connectAPI.data.session != null)
        {
            StartCoroutine(GetRequestURL("http://api.axions.jp/coin/api/mholding.do?param=list&session=" + connectAPI.data.session, postCoinGet));
        }
    }
    //GET通信
    IEnumerator GetRequestURL(string url,Action act)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accepted", "application/json");
        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                result = request.downloadHandler.text;
                Debug.Log(result);
                act();
            }
        }
    }

}
