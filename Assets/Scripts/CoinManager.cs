using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public int CoinMount;
    private UILabel uiLabel;
    void Awake()
    {
        uiLabel = gameObject.GetComponent<UILabel>();
        setCoin();
    }
    public void CoinChange(int m)
    {
        CoinMount += m;
        setCoin();
    }
    public void setCoin()
    {
        uiLabel.text = "x" + CoinMount.ToString();
    }
}
