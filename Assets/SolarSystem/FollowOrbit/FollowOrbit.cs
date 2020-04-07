﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowOrbit : MonoBehaviour {

	public GameObject orbitToFollow;
	public float orbitSpeed;
	
	private int numberOfpositions;
	private LineRenderer lineRenderer;

	public int earthOffset = 1;

	private Vector3[] localOrbitPositions;
	private bool collided = false;
	private bool startedFollowingOrbit = false;

	private int startEarthOffset;
	// Use this for initialization
	void Start () {
		startEarthOffset = earthOffset;
		lineRenderer = orbitToFollow.GetComponent<LineRenderer>();
		numberOfpositions = lineRenderer.positionCount;
		transform.localPosition = orbitToFollow.transform.TransformPoint(lineRenderer.GetPosition(numberOfpositions - earthOffset));

		// save obrbit local positions for reference, so we do not have to calculate global position on coroutine
		localOrbitPositions = new Vector3[lineRenderer.positionCount];
		for(int i = 0; i < lineRenderer.positionCount; i++)
		{
			localOrbitPositions[i] = orbitToFollow.transform.TransformPoint(lineRenderer.GetPosition(i));
		}

		StartCoroutine(ConstantValues.FollowOrbitCoroutine);
	}

	void OnCollisionEnter(Collision collision)
    {
		Debug.Log("OnCollisionEnter");
		Debug.Log(this.gameObject + "entered" + collision.gameObject);
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null) {rb.isKinematic = true;}
		collided = true;
	}

	void OnCollisionExit(Collision collision) {
		Debug.Log("OnCollisionExit");
		if (!startedFollowingOrbit){
			collided = false;
			Rigidbody rb = GetComponent<Rigidbody>();
			if (rb != null) {rb.isKinematic = false;}
		}
	}

	public bool Collided(){
		return collided;
	}

	public void StartFollowOrbit(){
		startedFollowingOrbit = true;
		Debug.Log("StartFollowOrbit");
		GetComponent<Rigidbody>().isKinematic = true;
		orbitSpeed = 10;
		Start();
	}



	 private IEnumerator MoveOnOrbit()
	 {

		 // move on orbit if orbit speed for planet has been set up
		 while(Mathf.Abs(orbitSpeed) > 0)
		 {
			if(transform.position == localOrbitPositions[numberOfpositions - earthOffset] ){
				earthOffset+=4;
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, localOrbitPositions[numberOfpositions - earthOffset], Time.deltaTime * orbitSpeed * ConfigManager.instance.orbitSpeedInDaysPerSecond);
			}

			if(earthOffset >= numberOfpositions){
				earthOffset= 1;
			}
			yield return null;
		 }
	}
}
