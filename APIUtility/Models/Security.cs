﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUtility.Models
{
    public class Security
    {
        //public static string getIPAddress(System.Web.UI.Page page)
        //{
        //    string szRemoteAddr = page.Request.ServerVariables["REMOTE_ADDR"];
        //    string szXForwardedFor = page.Request.ServerVariables["X_FORWARDED_FOR"];
        //    string szIP = "";

        //    if (szXForwardedFor == null)
        //    {
        //        szIP = szRemoteAddr;
        //    }
        //    else
        //    {
        //        szIP = szXForwardedFor;

        //        if (szIP.IndexOf(",") > 0)
        //        {
        //            string[] arIPs = szIP.Split(',');

        //            foreach (string item in arIPs)
        //            {
        //                if (!isPrivateIP(item))
        //                {
        //                    return item;
        //                }
        //            }
        //        }
        //    }
        //    return szIP;
        //}
    }
}