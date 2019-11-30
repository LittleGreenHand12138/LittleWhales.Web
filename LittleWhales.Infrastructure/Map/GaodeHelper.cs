/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：GaodeHelper.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 14:29:07
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace LittleWhales.Infrastructure.Map
{

    /// <summary>
    /// 高德地图调用帮助类
    /// 更多详情请参考 高德api
    /// </summary>
    public class GaodeHelper
    {
        //高德平台申请的秘钥
        public static string SecretKey = "a31688a10b076c61d4c8e7ba08ed8e23";

        /// <summary>
        /// 获取经纬度
        /// </summary>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public static string GetGeocode(string address, string city = "")
        {
            string geocodeUrl = $"http://restapi.amap.com/v3/geocode/geo?address={address}&output=json&key={SecretKey}";
            if (!city.IsNullOrEmpty())
            {
                geocodeUrl += $"&city={city}";
            }



            string geocode = WebClientDownloadInfoToString(geocodeUrl);
            geocode = GetLatitudeAndLongitude(geocode);
            return geocode;
        }

        /// <summary>
        /// 获取城市之间的距离
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="beginCity"></param>
        /// <param name="end"></param>
        /// <param name="endCity"></param>
        /// <returns></returns>
        public static string GetDistance(string begin, string end, string beginCity = "", string endCity = "")
        {
            try
            {
                string origin = GetGeocode(begin, beginCity);
                string destination = GetGeocode(end, endCity);
                string driveUri = $"http://restapi.amap.com/v3/direction/driving?key={SecretKey}&origin={origin}&destination={destination}";

                string result = WebClientDownloadInfo(driveUri);
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private static string WebClientDownloadInfo(string uri)
        {
            string result = string.Empty;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/xml;charset=UTF-8";
                result = wc.DownloadString(uri);
            }
            return result;
        }

        /// <summary>
        /// 模拟请求
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static string WebClientDownloadInfoToString(string uri)
        {
            string result = string.Empty;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/xml;charset=UTF-8";
                result = wc.DownloadString(uri);
            }
            return result;
        }

        /// <summary>
        /// 解析返回的经纬度信息
        /// </summary>
        /// <param name="GeocodeJsonFormat"></param>
        /// <returns></returns>
        private static string GetLatitudeAndLongitude(string GeocodeJsonFormat)
        {
            JObject o = JObject.Parse(GeocodeJsonFormat);
            string geocodes = (string)o["geocodes"][0]["location"];
            return geocodes;
        }
    }
}
