using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthPoleBehavior : MonoBehaviour {
	public CoordinateCalculator Calculator;

	private void UpdateSelf() {
		var point = this.Calculator.GetNorthPolePosition(this.Calculator.ReferenceTime);

		Vector3 selfLocation = new Vector3((float)point.x, (float)point.y, (float)point.z);
		this.gameObject.transform.localPosition = selfLocation;
	}

	// Use this for initialization
	void Start () {
		this.Calculator = GameObject.Find("Main Camera").GetComponent<GameManager>().Calculator;
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateSelf();
	}
}
