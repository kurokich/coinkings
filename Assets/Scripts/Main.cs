using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public class Parameter
    {
        public bool DebugMode;
    }
    public Parameter Param;

    void Start()
    {
<<<<<<< HEAD
=======
#if UNITY_EDITOR
>>>>>>> parent of ce2eba3... Detonatorを指定
        if (this.Param == null)
        {
            this.Param = new Parameter { DebugMode = false };
        }
<<<<<<< HEAD
=======
#endif
>>>>>>> parent of ce2eba3... Detonatorを指定
        Debug.Log(this.Param.DebugMode);
    }
}
