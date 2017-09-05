using System;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Device.Location;

using ETOS.WSL.Abstract;

namespace ETOS.WSL
{
	public class MileageCalculatingService : IMileageCalculatingService
	{
		/// <summary>
		/// Получает координаты адреса через HTTP запрос к Yandex API 
		/// </summary>		
		private bool GetCoordinates(string address, out double coordinate1, out double coordinate2)
		{
			coordinate1 = 0;
			coordinate2 = 0;

			WebClient client = new WebClient();

			if (address == null || address == "") return false;
			XDocument doc = XDocument.Load(string.Format("https://geocode-maps.yandex.ru/1.x/?geocode={0}", address));

			try
			{
				var el0 = doc.Root.Elements().ToList();
				var el1 = el0.Elements().ToList();
				var el2 = el1[1].Elements().ToList();
				var el3 = el2.Elements().ToList();
				var coordinatesString = el3[4].Elements().ToList()[0].Value;

				var coordinatesMas = coordinatesString.Split();

				coordinatesMas[0] = coordinatesMas[0].Replace('.', ',');
				coordinatesMas[1] = coordinatesMas[1].Replace('.', ',');

				double.TryParse(coordinatesMas[0], out coordinate1);
				double.TryParse(coordinatesMas[1], out coordinate2);
			}
			catch (Exception e)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Возвращает расстояние между пунктами в км
		/// </summary>
		/// <returns></returns>
		public int GetMileage(string addressFrom, string addressTo)
		{
			var latitude = new double[2];
			var longitude = new double[2];

			var departurePointFlag = GetCoordinates(addressFrom, out longitude[0], out latitude[0]);
			var destinationPointFlag = GetCoordinates(addressTo, out longitude[1], out latitude[1]);

			if (!departurePointFlag || !destinationPointFlag) return 0;

			//Широта долгота
			var sCoord = new GeoCoordinate(latitude[0], longitude[0]);
			var eCoord = new GeoCoordinate(latitude[1], longitude[1]);

			var distance = (int)(sCoord.GetDistanceTo(eCoord) / 1000);

			return distance;
		}
	}
}
