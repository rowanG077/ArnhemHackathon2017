using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
	public class SurfaceSgp4Pair
	{
		public DateTime TimePointUtc { get; set; }
		public One_Sgp4.Point3d SurfacePoint { get; set; }
		public One_Sgp4.Sgp4Data SatalitePoint { get; set; }
	}
}
