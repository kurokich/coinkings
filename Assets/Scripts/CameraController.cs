using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    #region(inspector settings)
    public int fixWidth = 1280;
    public int fixHeight = 720;
    public bool portrait = false;
	public static float fixScale = 1.0f;
    public Camera[] fixedCamera;
    #endregion
 
    public static float resolutionScale = -1.0f;
 
    void Awake() {
        int fw = portrait ? this.fixHeight : this.fixWidth;
        int fh = portrait ? this.fixWidth : this.fixHeight;
 
        if( this.fixedCamera != null ){
            Rect set_rect = this.calc_aspect(fw, fh, out resolutionScale);
            foreach( Camera cam in this.fixedCamera ){
                cam.rect = set_rect;
            }
        }
 

		//this.Destroy(this);
    }
 
    Rect calc_aspect(float width, float height, out float res_scale) {
        float target_aspect = width / height;
        float window_aspect = (float)Screen.width / (float)Screen.height;
        fixScale = window_aspect / target_aspect;
		Debug.Log(fixScale);
 
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        if( 1.0f > fixScale ){
            rect.x = 0;
            rect.width = 1.0f;
            rect.y = (1.0f - fixScale) / 2.0f;
            rect.height = fixScale;
            res_scale = (float)Screen.width / width;
        } else {
            fixScale = 1.0f / fixScale;
            rect.x = (1.0f - fixScale) / 2.0f;
            rect.width = fixScale;
            rect.y = 0.0f;
            rect.height = 1.0f;
            res_scale = (float)Screen.height / height;
        }
 
        return rect;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}