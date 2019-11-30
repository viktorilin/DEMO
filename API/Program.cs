using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:8083");
            client.Authenticator = new HttpBasicAuthenticator("viktor", "vi140798il");

            var request = new RestRequest("/rest/raven/1.0/import/execution/nunit?projectKey=XRAYDEMO", Method.POST);

            string PATH = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string ACTUAL_PATH = PATH.Substring(0, PATH.LastIndexOf("bin"));
            string PROJECT_PATH = new Uri(ACTUAL_PATH).LocalPath;

            string path = $@"{PROJECT_PATH}..\TestResult.xml";


            // add files to upload (works with compatible verbs)
            request.AddFile("file", path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
        }
    }
}
