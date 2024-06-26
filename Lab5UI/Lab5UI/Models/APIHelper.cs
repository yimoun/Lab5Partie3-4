﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    internal class APIHelper
    {
        public static HttpClient APIClient { get; set; }

        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.BaseAddress = new Uri("https://localhost:7100/") ;
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
