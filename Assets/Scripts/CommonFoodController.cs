using UnityEngine;
using System.Collections;

public class CommonFoodController : MonoBehaviour {
    public int type;
    public GameObject SurfaceCamera;
    public GameObject CutIn;
	// Update is called once per frame
    void Awake()
    {
        SurfaceCamera = GameObject.Find("SurfaceCamera");
        //爆弾
        if (type == 3)
        {
            StartCoroutine(Skill_Explode());
        }
    }
	void Update () {

		//落ちた場合
		if(this.transform.position.y < -20.0f){
            GameObject.Find("HitPlane").GetComponent<hitPlane>().OnSideCollision();
            Destroy(this.gameObject);
        }
	}
    //爆発スキル
    IEnumerator Skill_Explode()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Detonator>().Explode();
        yield break;
    }
    //ヒットプレーンに乗った場合
    void OnTriggerEnter(Collider collisionInfo){
       if (collisionInfo.name == "HitPlane")
            {
            GameObject.Find("Slot").GetComponent<SlotController>().ReelStop();
            Destroy(this.gameObject);
            if (type == 1)
            {
                //爆発コイン投下
                GameObject.Find("Spawner").GetComponent<Spawner>().AddExplode();
                Destroy(this.gameObject);
            }
            else if (type == 2)
            {
                //攻守入れ替え
                collisionInfo.gameObject.GetComponent<hitPlane>().player.GetComponent<PlayerManager>().ModeChange();
                collisionInfo.gameObject.GetComponent<hitPlane>().enemy.GetComponent<PlayerManager>().ModeChange();
                Destroy(this.gameObject);
            }
            else if (type == 4)
            {
                GameObject go = (GameObject)Instantiate(CutIn, new Vector3(0.0f, 1.0f, 5.0f), Quaternion.identity);
                go.transform.parent = SurfaceCamera.transform;
                go.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
                go.transform.localScale = new Vector3(101, 101, 101);
                go.transform.rotation = Quaternion.Euler(0, 0, 0);
                //バズーカ
                Destroy(this.gameObject);

            }
            else
            {
                collisionInfo.gameObject.GetComponent<hitPlane>().OnCollision();
                Destroy(this.gameObject);            
            }
        }
    }
}
