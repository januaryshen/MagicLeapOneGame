﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseLineRenderer : MonoBehaviour {

	public int segments;
	public float xRadius;
	public float yRadius;
	LineRenderer line;
	// Use this for initialization
	void Awake () {
		line = gameObject.GetComponent<LineRenderer>();
		line.positionCount = (segments + 1);
		line.useWorldSpace = false;
		line.loop = false;
		CreatePoints();
		CreateMesh();
	}

	void CreateMesh(){
		LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
		MeshCollider meshCollider = line.GetComponent<MeshCollider>();
		if (meshCollider!=null){
			Mesh mesh = new Mesh();
			lineRenderer.BakeMesh(mesh, true);
			meshCollider.sharedMesh = mesh;

			Debug.Log("Mesh");
		}
	}

	void CreatePoints()
	{
		float x = 0f;
		float y = 0f;
		float z = 0f;

		float angle = 20f;

		for(int i = 0; i < segments + 1; i++)
		{
			x = Mathf.Sin(Mathf.Deg2Rad * angle * xRadius);
			y = Mathf.Cos(Mathf.Deg2Rad * angle * yRadius);
			line.SetPosition(i, new Vector3(x,y,z));

			angle += 360f/segments;
		}		
	}

#if UNITYEDITOR
	private void OnDrawGizmos()
	{
		float x = 0f;
		float y = 0f;
		float z = 0f;

		float angle = 20f;

		for(int i = 0; i < segments + 1; i++)
		{
			x = Mathf.Sin(Mathf.Deg2Rad * angle * xRadius);
			y = Mathf.Cos(Mathf.Deg2Rad * angle * yRadius);
			//line.SetPosition(i, new Vector3(x,y,z));

			angle += 360f/segments;
		}	
	}
	#endif
	
}
