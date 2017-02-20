using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearWindow : MonoBehaviour
{

    public UILabel text;

    void Awake()
    {
        text = transform.FindChild("Label").gameObject.GetComponent<UILabel>();
    }
    public void InitializeWindow(string mes)
    {
        text.text = mes;
    }
    public void pushButton()
    {
        SceneManager.LoadScene("Title");
    }
}
