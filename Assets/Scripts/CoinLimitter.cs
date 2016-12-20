using UnityEngine;
using System.Collections;

public class CoinLimitter : MonoBehaviour {

    public GameObject[] coins;
    public int m;
	// Use this for initialization
	void Start () {
        coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        m = 4;
        StartCoroutine(FuncCoroutine());
    }

    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            if(m < 4)
            {
                m++;
                setCoin(m);
            }
            yield return new WaitForSeconds(1);
        }
    }
    private void setCoin(int t)
    {
        if(t >= 4)
        {
            coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        if (t >= 3)
        {
            coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        if (t >= 2)
        {
            coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        if (t >= 1)
        {
            coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        if (t >= 0)
        {
            coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
    }
}

