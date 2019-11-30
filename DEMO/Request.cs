using RestSharp;
using RestSharp.Authenticators;
using System.IO;
using System.Net;

namespace DEMO
{
    public static class Request
    {
        public static void req()
        {
            var client = new RestClient("http://localhost:8083");
            client.Authenticator = new HttpBasicAuthenticator("viktor", "vi140798il");

            var request = new RestRequest("/rest/raven/1.0/import/execution/nunit?projectKey=XRAYDEMO", Method.POST);
           
            var path = @"E:\DEMO\DEMO\TestResult.xml";

            // add files to upload (works with compatible verbs)
            request.AddFile("file", path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
        }
    }
}
