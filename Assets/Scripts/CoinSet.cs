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
                if(hit.collider.gameObject.name == "coin_a")
                {
                    touchAction(1);
                }else if (hit.collider.gameObject.name == "coin_b")
                {
                    touchAction(2);
                }
                else if(hit.collider.gameObject.name == "coin_c")
                {
                    touchAction(3);
                }
            }
        }
    }
    public void touchAction(int c)
    {
        Debug.Log(c);
        if(touched != c)
        {
            touched = c;
            Effect.SetActive(true);
            Effect.transform.localPosition = new Vector3(80,- 100 * c,-153);
        }else if(touched == c)
        {
            touched = 0;
            Effect.SetActive(false);
        }
    }
}
