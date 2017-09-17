using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets;

public class TimeBehaviourScript : MonoBehaviour {
	private CoordinateCalculator mainCalculator;
	private Text txtDate;

	// Use this for initialization
	void Start () {
		this.mainCalculator = GameObject.Find ("Main Camera").GetComponent<GameManager> ().Calculator;
		this.txtDate = this.gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		var sDate = this.mainCalculator.ReferenceTime.ToString ("HH:MM:ss");
		this.txtDate.text = sDate;
	}
}