using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int current_hp;
    public int max_hp;
    public int damage;
    public int mode;
    private GameObject currentHpSurface;
    private GameObject attackMark;
    private GameObject defendMark;
    private GameObject windowRoot;
    private UILabel hpObject;
    private float per;

    void Start()
    {
        windowRoot = GameObject.Find("UI Root_Window");
        currentHpSurface = transform.FindChild("surface").gameObject;
        attackMark = transform.FindChild("AttackMark").gameObject;
        defendMark = transform.FindChild("DefendMark").gameObject;
        hpObject = transform.FindChild("HP").gameObject.GetComponent<UILabel>();

        initiMode();
        UpdateSurface();
    }
    void initiMode()
    {
        if (mode == 0) {
            attackMark.SetActive(true);
            defendMark.SetActive(false);
        }
        else if (mode == 1)
        {
            attackMark.SetActive(false);
            defendMark.SetActive(true);
        }
    }
    public void ModeChange()
    {
        if(mode == 1)
        {
            mode = 0;
        }
        else
        {
            mode = 1;
        }
        initiMode();
    }
    private void UpdateSurface()
    {
        per = (float)current_hp / max_hp;
        currentHpSurface.transform.localScale = new Vector3(per,1,1);
    }
    void Update()
    {
        if(damage > 0)
        {
            if ((current_hp - damage) <= 0)
            {
                damage = 0;
                current_hp = 0;
                UpdateSurface();
                GameObject prefab = (GameObject)Resources.Load("Prefabs/ClearWindow");
                Vector2 pos = new Vector3(-10.0f, 189.0f, -613.0f);
                if (transform.name == "Player")
                {
                    GameObject obj = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
                    obj.transform.parent = windowRoot.transform;
                    obj.transform.localPosition = pos;
                    obj.GetComponent<GameClearWindow>().InitializeWindow("Game Over");
                }
                else if (transform.name == "Enemy")
                {
                    GameObject obj = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
                    obj.transform.parent = windowRoot.transform;
                    obj.transform.localPosition = pos;
                    obj.GetComponent<GameClearWindow>().InitializeWindow("Game Clear");
                }
            }
            else
            {
                current_hp--;
                damage--;
                if (current_hp < 0) current_hp = 0;
                UpdateSurface();
                hpObject.text = current_hp.ToString();
            }
        }
    }
}
