using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public GameObject shopWindow;
    public GameObject display;
    private ConnectAPI connectAPI;
    private GameObject shopPrefab;
    private GameObject window;
    public Vector3 winPos = new Vector3(0,0,0);

    private bool canEdit;
	// Use this for initialization
	void Start () {
        connectAPI = GetComponent<ConnectAPI>();
        shopPrefab = (GameObject)Resources.Load("Prefabs/shopWindow");
    }

    public void StartButton()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Main");
    }
    public void StartShopWindow()
    {
        if (!connectAPI.data.isShopWindow)
        {
            window = Instantiate(shopPrefab) as GameObject;
            window.transform.parent = display.transform;
            window.transform.localPosition = new Vector3(0, 0, 30);
            window.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
