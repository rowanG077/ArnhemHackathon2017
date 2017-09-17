﻿using Assets.Models;
using One_Sgp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
	public class CoordinateCalculator
	{
		private Coordinate Me;

		public DateTime ReferenceTime { get; set; }

		public CoordinateCalculator(double latitude, double longitude, double height, DateTime referenceTime) {
			this.ReferenceTime = referenceTime;
			this.SetNewPosition(latitude, longitude, height);
		}

		public void SetNewPosition(double latitude, double longitude, double height) {
			this.Me = new Coordinate(latitude, longitude, height);
		}

		public List<SurfaceSgp4Pair> GetCoordinates(Tle satalite, DateTime from, DateTime to, int resolution) {
			Sgp4 sgp4Propagator = new Sgp4(satalite, 1);

			var epochFrom = new EpochTime(from);
			var epochTo = new EpochTime(to);

			var stepSize = (to - from).TotalMinutes / resolution;

			sgp4Propagator.runSgp4Cal(epochFrom, epochTo, stepSize);

			var results = sgp4Propagator.getRestults()
				.Select((sgp, i) => {
					var time = from.AddMinutes(i * stepSize);
					return new SurfaceSgp4Pair
					{
						TimePointUtc = time,
						SatalitePoint = sgp,
						SurfacePoint = this.Me.toECI(new EpochTime(time).getLocalSiderealTime(this.Me.getLongitude()))
					};
				})
				.ToList();

			return results;
		}

		public SurfaceSgp4Pair GetCurrentCoordinates(Tle satalite) {
			return this.GetCoordinates(satalite, this.ReferenceTime, this.ReferenceTime.AddSeconds(1), 1).First();
		}

		

	}
}
