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
    private float per;

    void Start()
    {
        currentHpSurface = transform.FindChild("surface").gameObject;
        attackMark = transform.FindChild("AttackMark").gameObject;
        defendMark = transform.FindChild("DefendMark").gameObject;

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
            current_hp--;
            damage--;
            if (current_hp < 0) current_hp = 0;
            UpdateSurface();
        }
    }
}
