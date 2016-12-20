using UnityEngine;
using System.Collections;

public class MeatCollision : MonoBehaviour {
	private GameObject smoke;
	private bool timer_start;
	
	public Material[] Materials;
	public float timer;
	public int meatState;//0窶ｦ逕溯ｉ,999窶ｦ鮟堤┬縺?	
    // Use this for initialization
    void  Start () {
		meatState = 0;
		timer = 0;
		//meat color change
		int rand = Random.Range(0,3);
		GetComponent<Renderer>().material = Materials[rand];
		//smoke finder
		/*
		smoke = this.transform.FindChild("Smoke").gameObject;
		smoke.particleSystem.Pause();
		*/
		float rotZ = Random.value * 360.0f;
		this.transform.Rotate(0.0f,0.0F,rotZ);
		//Debug.Log(rotY) ;
    }
    
    // Update is called once per frame
    void Update () {
		if(timer_start)timer += Time.deltaTime;
		if(meatState == 0 && timer >= 30.0f){
			meatState = 1;
			GetComponent<Renderer>().material = Materials[3];
		}
    }
    
    void OnCollisionEnter(Collision col){
        //Debug.Log("col_enter:"+col.gameObject.tag);

		if(col.gameObject.tag == "stage" && meatState == 0){			
			timer_start = true;
			 //smoke.particleSystem.Play();
			Singleton<SoundPlayer>.instance.playSE( "se001" );
		}
    }
    
    //陦晉ｪ√′邨ゅｏ縺｣縺溘→縺阪↓?大ｺｦ縺?縺大他縺ｰ繧後ｋ髢｢謨ｰ
    void OnCollisionExit(Collision col){
		if(col.gameObject.tag == "stage"){
			timer_start = false;
			timer = 0;
		}
        //Debug.Log("col_end:"+col.gameObject.tag);
    }
	
    //陦晉ｪ√＠縺ｦ縺?ｋ髢灘他縺ｰ繧後ｋ髢｢謨ｰ?亥ｮ悟?縺ｫ髱呎ｭ｢縺励◆繧ｪ繝悶ず繧ｧ繧ｯ繝医〒縺ｯ蜻ｼ縺ｰ繧後↑縺?ｼ?
    void OnCollisionStay(Collision col){
         //Debug.Log("col_stay:"+col.gameObject.tag);
    }

 }
