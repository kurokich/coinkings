using UnityEngine;
using System.Collections;

public class SceneReseter : MonoBehaviour {

	void resetScene() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
