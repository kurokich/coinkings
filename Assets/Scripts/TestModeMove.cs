using UnityEngine;
using System.Collections;

public class TestModeMove : MonoBehaviour {

	 void MoveTestScene(){
		if(Application.loadedLevelName == "Main_arai"){
			Application.LoadLevel("Main_exp");
		}else{
			Application.LoadLevel("Main_arai");
		}
	}
}
