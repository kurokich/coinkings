using UnityEngine;
using System.Collections;

public class SlotController : MonoBehaviour
{

    public UILabel resultLabel;          // 結果表示のラベル
    public UIScrollView[] reel;           // スロットの３つのScrollView
    public GameObject SpawnerGameObject;
    public GameObject CutIn;
    private Spawner Spawner;
    private bool isGamePlay;         // スロットプレイ中かのフラグ
    private bool[] isReelPlay;            // 各リールが回っているかのフラグ
    private bool[] resenterFlg;           // 各リールが止まって中心がセンターに移動したかのフラグ
    public string[] resultNo;            // 各リールの数字
    private Main main;

    private int currentReel = 0;
    private const int reelCount = 3;  // リールの数

    void Awake()
    {
        // リールが止まったときの真ん中の数値をとるようのイベントをセット
        reel[0].transform.FindChild("UIWrap Content").GetComponent<UICenterOnChild>().onCenter = Reel1CenterObj;
        reel[1].transform.FindChild("UIWrap Content").GetComponent<UICenterOnChild>().onCenter = Reel2CenterObj;
        reel[2].transform.FindChild("UIWrap Content").GetComponent<UICenterOnChild>().onCenter = Reel3CenterObj;
        SpawnerGameObject = GameObject.Find("Spawner");
        Spawner = SpawnerGameObject.GetComponent<Spawner>();
        main = FindObjectOfType<Main>() as Main;
    }

    void Start()
    {
        isGamePlay = false;
        isReelPlay = new bool[reelCount];
        resenterFlg = new bool[reelCount];
        resultNo = new string[reelCount];
        for (int i = 0; i < isReelPlay.Length; i++)
        {
            isReelPlay[i] = false;
            resenterFlg[i] = false;
        }
        PlayStart();
    }

    void Update()
    {
        if (isGamePlay)
        {
            for (int i = 0; i < reel.Length; i++)
            {
                if (isReelPlay[i])
                {
                    // リールをまわす
                    reel[i].Scroll(5f * Time.deltaTime);
                }
                else
                {
                    // 一つのマスのサイズを100にしているのでy座標が100にちかくなるところまで動かす
                    float posy = reel[i].transform.localPosition.y;
                    string no = resultNo[0];
                    float y;
                    if (no.Length < 2)
                    {
                        no = "0" + no;
                    }
                    if (i > 0 && main.Param.DebugMode)
                    {
                        
                        y = reel[i].transform.FindChild("UIWrap Content").transform.FindChild(no).transform.localPosition.y + posy;
                        Debug.Log(no+":"+y);
                        if(y < 0 || y > 100)
                        {
                            y = 100;
                        }
                    }
                    else
                    {
                        y = 100 - Mathf.Abs(posy % 100);
                    }

                    if (y > 2f && !resenterFlg[i])
                    {

                        reel[i].Scroll((float)y / 50f * Time.deltaTime);
                    }
                    else
                    {
                        if (!resenterFlg[i])
                        {
                            // 近くまで動いたら真ん中に合わせる  これを呼ぶとonCenterで登録された関数が呼ばれる
                            reel[i].transform.FindChild("UIWrap Content").GetComponent<UICenterOnChild>().Recenter();
                            resenterFlg[i] = true;
                        }
                    }
                }
            }
        }
    }

    // スロット開始
    public void PlayStart()
    {
        isGamePlay = true;
        for (int i = 0; i < isReelPlay.Length; i++)
        {
            isReelPlay[i] = true;
            resenterFlg[i] = false;
            resultNo[i] = "";
        }
        currentReel = 0;
        ShowText();
    }

    // スロット停止
    public void ReelStop()
    {
        if (currentReel > 2)
        {
            PlayStart();
        }
        else {
            if (currentReel > 0)
            {
                if (!isReelPlay[currentReel - 1] && resenterFlg[currentReel - 1])
                {
                    isReelPlay[currentReel] = false;
                    currentReel++;
                }
            }else
            {
                isReelPlay[currentReel] = false;
                currentReel++;
            }
        }
    }

    public void Reel2Stop()
    {
        isReelPlay[1] = false;
    }

    public void Reel3Stop()
    {
        isReelPlay[2] = false;
    }

    // スロット停止時の中心オブジェクト取得
    public void Reel1CenterObj(GameObject go)
    {

        string str = go.transform.FindChild("Label").GetComponent<UILabel>().text;
        resultNo[0] = str;
        ShowText();
    }

    public void Reel2CenterObj(GameObject go)
    {

        string str = go.transform.FindChild("Label").GetComponent<UILabel>().text;
        resultNo[1] = str;
        ShowText();
    }

    public void Reel3CenterObj(GameObject go)
    {
        string str = go.transform.FindChild("Label").GetComponent<UILabel>().text;
        resultNo[2] = str;
        ShowText();

        //揃ったら効果発動
        if (resultNo[0] == resultNo[1] && resultNo[1] == resultNo[2])
        {
            //大当たり
            if (resultNo[0] == "7")
            {
                for (int x = 1; x <= 100; ++x) // xを1～9まで、1ずつ増やして繰り返し
                {
                    Vector3 vec3 = new Vector3(Random.Range(-0.2f, 0.2f), 0.3f, Random.Range(0.5f, 0.7f));
                    Spawner.AddCoin(vec3, 0);
                }
            }
            else if (resultNo[1] == "10")
            {
                //攻守入れ替え
                Vector3 vec3 = new Vector3(Random.Range(-0.2f, 0.2f), 0.3f, Random.Range(0.5f, 0.7f));
                Spawner.AddCoin(vec3, 1);
            }
            //異界の力
            else if (resultNo[1] == "0")
            {
                GameObject go2 = (GameObject)Instantiate(CutIn, new Vector3(0.0f, 1.0f, 5.0f), Quaternion.identity);
                go2.transform.parent = GameObject.Find("UI Root_Window").transform;
                go2.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
                go2.transform.rotation = Quaternion.Euler(0, 0, 0);
                go2.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
            }
            else
            {
                for (int x = 1; x <= int.Parse(resultNo[0]) * 2; ++x) // xを1～9まで、1ずつ増やして繰り返し
                {
                    Vector3 vec3 = new Vector3(Random.Range(-0.2f, 0.2f), 0.3f, Random.Range(0.5f, 0.7f));
                    Spawner.AddCoin(vec3, 0);
                }
            }
        }        
    }

    public void ShowText()
    {
        resultLabel.text = resultNo[0] + " " + resultNo[1] + " " + resultNo[2];
    }
}