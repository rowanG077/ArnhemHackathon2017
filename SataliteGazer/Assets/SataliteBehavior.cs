using Assets;
using One_Sgp4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SataliteBehavior : MonoBehaviour {
	public CoordinateCalculator Calculator;
	public LineRenderer LineRenderer;
	public Tle TLeData;

	private void UpdateCoordinates()
	{
		var point = this.Calculator.GetCurrentCoordinatePair(this.TLeData);

		Vector3 sataliteLocation = new Vector3((float)point.SatalitePoint.getPositonData().x, (float)point.SatalitePoint.getPositonData().y, (float)point.SatalitePoint.getPositonData().z);
		this.gameObject.transform.localPosition = sataliteLocation;
	}

	private void DrawFlightLine(DateTime from, DateTime to)
	{
		var points = this.Calculator.GetCoordinatePairs(this.TLeData, from, to, 60)
			.Select(p => p.SatalitePoint)
			.Select(p => new Vector3((float)p.getX(), (float)p.getY(), (float)p.getZ()))
			.Select(v => this.gameObject.transform.parent.TransformPoint(v))
			.ToArray();

		this.LineRenderer.positionCount = points.Length;
		this.LineRenderer.SetPositions(points);
	}


	// Use this for initialization
	void Start () {
		this.Calculator = GameObject.Find("Main Camera").GetComponent<GameManager>().Calculator;
		this.LineRenderer = this.gameObject.GetComponent<LineRenderer>();
		this.LineRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateCoordinates();
		if (this.LineRenderer.enabled == true) {
			var halfOrbitalTimeDays = TimeSpan.FromDays(0.5 / this.TLeData.getMeanMotion());
			this.DrawFlightLine(this.Calculator.ReferenceTime - halfOrbitalTimeDays, this.Calculator.ReferenceTime + halfOrbitalTimeDays);
		}
	}
}
