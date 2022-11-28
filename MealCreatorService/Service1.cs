using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MealCreatorService
{
    public partial class Service1 : ServiceBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = "https://localhost:7027";
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        private async Task Start()
        {
            var uri = _baseUri + "/api/WeeklyMenus/Create";

            HttpResponseMessage response = await _httpClient.PostAsync(uri, null);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string msg = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(msg))
                {
                    //sendEmailToAdmin
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
