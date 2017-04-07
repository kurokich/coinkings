using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBomb : MonoBehaviour {
    public int type = 0;
    public bool Exploded = false;
	// Use this for initialization
	void Start () {
        if (type == 0)
        {
            //プッシャーの上に飛ぶ
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 3.0f, 2.5f), ForceMode.Impulse);
        }else if (type == 1)
        {
            //プッシャーの上に飛ぶ
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2.9f, 2.0f), ForceMode.Impulse);
        }else if (type == 2)
        {
            //ランダムな位置

            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 3.0f, 2.0f), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!Exploded)
        {
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Detonator>().Explode();
            Exploded = true;
        }
    }

    void Update ()
    {        
        //落ちた場合
        if (transform.position.y < -20.0f)
        {
            Debug.Log("#");
            Destroy(this,0);            
        }
    }
}