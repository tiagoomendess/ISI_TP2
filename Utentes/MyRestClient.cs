using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Utentes
{
    public class MyRestClient
    {

        string servicoUrl;
        WebRequest request;

        public MyRestClient(string servicoUrl)
        {
            this.servicoUrl = servicoUrl;
            string consumerKey = "test";
            string consumerSecret = "segredo";
            var uri = new Uri(servicoUrl);
            string url, param;
            var oAuth = new OAuthBase();
            var nonce = oAuth.GenerateNonce();
            var timeStamp = oAuth.GenerateTimeStamp();
            var signature = oAuth.GenerateSignature(uri, consumerKey,
            consumerSecret, string.Empty, string.Empty, "GET", timeStamp, nonce, out url, out param);

            request = WebRequest.Create(string.Format("{0}?{1}&oauth_signature={2}", url, param, signature));

        }

        public WebResponse GetRequest()
        {
            return request.GetResponse();
        }

        /// <summary>
        /// Vai buscar o objeto Json coorespondente ao request
        /// </summary>
        /// <returns></returns>
        public JObject GetJsonObject()
        {

            JObject jsonObject;

            try
            {
                WebResponse response = GetRequest();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string objectString = reader.ReadToEnd();
                jsonObject = JObject.Parse(objectString);
            }
            catch (Exception e)
            {
                Log.Erro("Erro ao no metodo GetJsonObject em MyRestClient:\n" + e.Message);
                return null;
            }

            return jsonObject;

        }

        /// <summary>
        /// Faz um pedido DELETE
        /// </summary>
        /// <returns></returns>
        public WebResponse DeleteRequest()
        {
            request.Method = "DELETE";
            return request.GetResponse();
        }



    }
}