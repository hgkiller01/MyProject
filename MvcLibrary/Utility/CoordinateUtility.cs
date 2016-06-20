using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLibrary.Utility
{
    public class CoordinateUtility
    {
        ///<summary>個人使用</summary>
        ///<param name="Longtiude">來源座標經度X</param>
        ///<param name="Latitude">來源座標緯度Y</param>
        ///<param name="Longtiude2">目標座標經度X</param>
        ///<param name="Latitude2">目標座標緯度</param>
        ///<returns>回傳距離公尺</returns>
        public double distance(double Longtiude, double Latitude, double Longtiude2, double Latitude2)
        {

            var lat1 = Latitude;
            var lon1 = Longtiude;
            var lat2 = Latitude2;
            var lon2 = Longtiude2;
            var earthRadius = 6371; //appxoximate radius in miles


            var factor = Math.PI / 180;
            var dLat = (lat2 - lat1) * factor;
            var dLon = (lon2 - lon1) * factor;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1 * factor)
              * Math.Cos(lat2 * factor) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double d = earthRadius * c * 1000;

            return d;

        }





        /// <summary>
        /// 回傳的數據和個人使用接近，但回傳單位是"公里"
        /// <para>出處：http://windperson.wordpress.com/2011/11/01/由兩點經緯度數值計算實際距離的方法/ </para>
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns>回傳距離公里</returns>
        public double DistanceOfTwoPoints(double lat1, double lng1, double lat2, double lng2)
        {
            double radLng1 = lng1 * Math.PI / 180.0;
            double radLng2 = lng2 * Math.PI / 180.0;
            double a = radLng1 - radLng2;
            double b = (lat1 - lat2) * Math.PI / 180.0;
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                Math.Cos(radLng1) * Math.Cos(radLng2) * Math.Pow(Math.Sin(b / 2), 2))
                ) * 6378.137;
            s = Math.Round(s * 10000) / 10000;

            return s;
        }






        private const double EARTH_RADIUS = 6378.137;
        private double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        /// <summary>
        /// from Google Map 腳本
        /// <para>出處：http://windperson.wordpress.com/2011/11/01/由兩點經緯度數值計算實際距離的方法/ </para>
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns>回傳單位 公尺</returns>
        public double GetDistance_Google(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }











        private double ConvertDegreeToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
        /// <summary>
        /// MSDN Magazine的範例程式碼
        /// <para>出處：http://www.dotblogs.com.tw/jeff-yeh/archive/2009/02/04/7034.aspx</para>
        /// </summary>
        /// <param name="Lat1"></param>
        /// <param name="Long1"></param>
        /// <param name="Lat2"></param>
        /// <param name="Long2"></param>
        /// <returns>回傳單位公尺</returns>
        public double GetDistance_MSDN(double Lat1, double Long1, double Lat2, double Long2)
        {
            double Lat1r = ConvertDegreeToRadians(Lat1);
            double Lat2r = ConvertDegreeToRadians(Lat2);
            double Long1r = ConvertDegreeToRadians(Long1);
            double Long2r = ConvertDegreeToRadians(Long2);

            double R = 6371; // Earth's radius (km)
            double d = Math.Acos(Math.Sin(Lat1r) *
              Math.Sin(Lat2r) + Math.Cos(Lat1r) *
               Math.Cos(Lat2r) *
               Math.Cos(Long2r - Long1r)) * R;
            return d;
        }
    }
}
