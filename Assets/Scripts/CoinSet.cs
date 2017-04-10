using UnityEngine;
using System.Collections;

public class CoinSet : MonoBehaviour {

    public GameObject Effect;
    public int touched;
    private Camera c;
    void Awake()
    {
        c = GameObject.Find("UICamera").GetComponent<Camera>();
        Effect.SetActive(false);
        touched = 0;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            
            Ray ray = c.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.gameObject.name == "coin_1")
                {
                    touchAction(1);
                }else if (hit.collider.gameObject.name == "coin_2")
                {
                    touchAction(2);
                }
                else if(hit.collider.gameObject.name == "coin_3")
                {
                    touchAction(3);
                }
                else if (hit.collider.gameObject.name == "coin_4")
                {
                    touchAction(4);
                }
                else if (hit.collider.gameObject.name == "coin_5")
                {
                    touchAction(5);
                }
                else if (hit.collider.gameObject.name == "coin_6")
                {
                    touchAction(6);
                }
            }
        }
    }
    public void touchAction(int c)
    {
        if(touched != c)
        {
            touched = c;
            Effect.SetActive(true);
            if (c < 5)
            {
                Effect.transform.localPosition = new Vector3(80, -100 * c, -153);
            }
            else
            {
                Effect.transform.localPosition = new Vector3(180, -100 * (c-4), -153);
            }
        }
        else if(touched == c)
        {
            touched = 0;
            Effect.SetActive(false);
        }
    }
}
