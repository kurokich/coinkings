using UnityEngine;
using System.Collections;

public class CommonFoodController : MonoBehaviour {
    public int type; 
	// Update is called once per frame
    void Awake()
    {
        //���e
        if (type == 3)
        {
            StartCoroutine(Skill_Explode());
        }
    }
	void Update () {

		//�������ꍇ
		if(this.transform.position.y < -20.0f){
            GameObject.Find("HitPlane").GetComponent<hitPlane>().OnSideCollision();
            Destroy(this.gameObject);
        }
	}
    //�����X�L��
    IEnumerator Skill_Explode()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<Detonator>().Explode();
        Debug.Log("explode");
        yield break;
    }
    //�q�b�g�v���[���ɏ�����ꍇ
    void OnTriggerEnter(Collider collisionInfo){
       if (collisionInfo.name == "HitPlane")
            {
            //�U�����ւ�
            if (type == 1)
            {
                Debug.Log("mode");
                collisionInfo.gameObject.GetComponent<hitPlane>().player.GetComponent<GameManager>().ModeChange();
                collisionInfo.gameObject.GetComponent<hitPlane>().enemy.GetComponent<GameManager>().ModeChange();
                Destroy(this.gameObject);
            }
            else if (type == 2)
            {
                GameObject.Find("Spawner").GetComponent<Spawner>().Add_Explode();
                Destroy(this.gameObject);
            }
            else if(type == 0)
            {
                Debug.Log(collisionInfo.name);
                collisionInfo.gameObject.GetComponent<hitPlane>().OnCollision();
                Destroy(this.gameObject);
            }
        }
    }
}
