using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Principal;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Buffers.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace MyAuth
{
    enum ResponseError
    {
        success=1,
        expired=2,
        invalid_details=3,
        restart_app = 4,
        internal_error=5,
        invalid_hwid=6
    }

    class Response
    {
        public ResponseError status;
        public string app_name;
        public string id;
        public string expiry;
        public string duration;
        public string creation_date;

        public Response(string[] args)
        {
            if (args[0] == "true")
            {
                this.status = ResponseError.success;
                this.app_name = args[2];
                this.expiry = args[3];
                this.duration = args[4];
                this.creation_date = args[5];
            }
            if(args[0] == "false")
            {
                switch (args[1])
                {
                    case "error":
                        this.status = ResponseError.internal_error;
                        break;
                    case "restart":
                        this.status = ResponseError.restart_app;
                        break;
                    case "expired":
                        this.status = ResponseError.expired;
                        break;
                    case "hwid":
                        this.status = ResponseError.invalid_hwid;
                        break;
                    case "no_exist":
                        this.status = ResponseError.invalid_details;
                        break;
                }
            }
        }
    }

    class App
    {
        public static string PublicKey;
        public App(string publickey)
        {
            PublicKey = publickey;
        }

        public Response Authenticate(string license)
        {
            using (WebClient client = new WebClient())
            {
                return new Response(client.DownloadString($"https://myauth.me/api/v2/?token={license}&hash={WindowsIdentity.GetCurrent().User.Value}&secret={App.PublicKey}").Split("|"));
            }
        }
    }
}
