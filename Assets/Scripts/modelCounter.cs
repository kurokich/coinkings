using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class modelCounter : MonoBehaviour {

	private Mesh mesh;
	// Use this for initialization
	void  OnBecameVisible () {
		MeshFilter filter = GetComponent(typeof (MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			
			mesh = filter.mesh;
			GlobalVariables.vertsCount += mesh.vertexCount;
		}
	}
	
	void OnBecameInvisible () {
		GlobalVariables.vertsCount -= mesh.vertexCount;
	}
}
