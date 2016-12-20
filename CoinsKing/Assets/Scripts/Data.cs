using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Data
{
    public DataDetail data;
    public int success;
    public string session;
    public bool isShopWindow;
}

[System.Serializable]
public class DataDetail
{
    public string MEMBERNAME;
    public string SCODE;
    public string CODE;
    public string MOVE_CODE;
    public string STATUS;
    public string UPDATEDATE;
    public string ENTRYDATE;
    public int success;
    public int speed;
    public int luck;
    public int fame;
    public int dom;
    public int btp;

    public string debugStr()
    {
        string str = "MEMBER NAME:" + MEMBERNAME + "\n" +
                     "SCODE:" + "\n" + SCODE + "\n" +
                     "CODE:" + CODE + "\n" +
                     "MOVE_CODE:" + MOVE_CODE + "\n" +
                     "STATUS:" + STATUS + "\n" +
                     "UPDATEDATE:" + UPDATEDATE + "\n" +
                     "ENTRYDATE:" + ENTRYDATE + "\n" +
                     "success:" + success.ToString() + "\n" +
                     "luck:" + luck.ToString() + "\n" +
                     "fame:" + fame.ToString() + "\n" +
                     "dom:" + dom.ToString() + "\n" +
                     "btp:" + btp.ToString() + "\n";
        return str;
    }
}

[System.Serializable]
public class DataCoin
{
    public string MEMBERNAME;
    public string SCODE;
    public string CODE;
    public string MOVE_CODE;
    public string STATUS;
    public string UPDATEDATE;
    public string ENTRYDATE;
    public int success;
    public int speed;
    public int luck;
    public int fame;
    public int dom;
    public int btp;

    public string debugStr()
    {
        string str = "MEMBER NAME:" + MEMBERNAME + "\n" +
                     "SCODE:" + "\n" + SCODE + "\n" +
                     "CODE:" + CODE + "\n" +
                     "MOVE_CODE:" + MOVE_CODE + "\n" +
                     "STATUS:" + STATUS + "\n" +
                     "UPDATEDATE:" + UPDATEDATE + "\n" +
                     "ENTRYDATE:" + ENTRYDATE + "\n" +
                     "success:" + success.ToString() + "\n" +
                     "luck:" + luck.ToString() + "\n" +
                     "fame:" + fame.ToString() + "\n" +
                     "dom:" + dom.ToString() + "\n" +
                     "btp:" + btp.ToString() + "\n";
        return str;
    }
}