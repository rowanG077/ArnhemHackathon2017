using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets;


public class SliderBehaviourScript : MonoBehaviour {
	private GameManager gmMain;
	private Slider sldrSpeed;

	void Start () {
		this.sldrSpeed = this.gameObject.GetComponent<Slider> ();
		this.gmMain = GameObject.Find ("Main Camera").GetComponent<GameManager> ();
		this.sldrSpeed.value = this.gmMain.TimeMultiplicationFactor;
	}

	// Update is called once per frame
	void Update () {
		this.gmMain.TimeMultiplicationFactor = this.sldrSpeed.value;
	}
}
