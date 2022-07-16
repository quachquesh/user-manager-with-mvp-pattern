using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Configs
{
    internal class Env
    {
        public string mode { get; set; }
        public string apiUrl { get; set; }

        public Env()
        {
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                string[] param = arg.Split('=');
                if (param.Length == 2 && param[0] == "mode")
                {
                    this.mode = param[1];
                }
            }
            if (string.IsNullOrEmpty(this.mode))
            {
                this.mode = "development";
            }

            // ENV settings
            if (this.mode == "development")
            {
                this.apiUrl = "http://localhost:3000";
            }
            else // Production
            {
                this.apiUrl = "http://localhost:3000";
            }
        }
    }
}
