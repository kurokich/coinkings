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
#if UNITY_EDITOR
        if (this.Param == null)
        {
            this.Param = new Parameter { DebugMode = false };
        }
#endif
        Debug.Log(this.Param.DebugMode);
    }
}
