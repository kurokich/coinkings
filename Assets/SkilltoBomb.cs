using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilltoBomb : MonoBehaviour {

    public GameObject BomTemp;
    public GameObject SmallBomTemp;
    public GameObject Bom;
    public GameObject Bom2;
    public GameObject Bom3;
    public GameObject ParentGameObject;

    void Awake()
    {
        if(ParentGameObject == null)
        {
            ParentGameObject = GameObject.Find("Main Camera").gameObject;
        }
    }
    public void EndCutIn()
    {
        Vector3 vec = new Vector3(-15,-691,65);
        Bom = Instantiate(BomTemp,ParentGameObject.transform);
        Bom.transform.localRotation = Quaternion.identity;
        Bom.transform.localScale = new Vector3(40, 40, 40);
        Bom.transform.localPosition = vec;
    }

    public void SmallThreeBom()
    {
        int rand = Random.Range(-20, -10);
        Vector3 vec = new Vector3(rand, -691, 65);
        Bom = Instantiate(SmallBomTemp, ParentGameObject.transform);
        Bom.transform.localRotation = Quaternion.identity;
        Bom.transform.localScale = new Vector3(40, 40, 40);
        Bom.transform.localPosition = vec;
        rand = Random.Range(-20, -10);
        vec = new Vector3(rand, -691, 65);
        Bom2 = Instantiate(SmallBomTemp, ParentGameObject.transform);
        Bom2.transform.localRotation = Quaternion.identity;
        Bom2.transform.localScale = new Vector3(40, 40, 40);
        Bom2.transform.localPosition = vec;
        rand = Random.Range(-20, -10);
        vec = new Vector3(rand, -691, 65);
        Bom3 = Instantiate(SmallBomTemp, ParentGameObject.transform);
        Bom3.transform.localRotation = Quaternion.identity;
        Bom3.transform.localScale = new Vector3(40, 40, 40);
        Bom3.transform.localPosition = vec;
    }
}
