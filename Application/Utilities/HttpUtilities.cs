using Application.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Application.Utilities
{
    public class HttpUtilities : IHttpUtilities
    {

        public string ExecuteHttpRequest(string endpoint, string requestBody = null, Dictionary<string, string> headers = null)
        {
            DateTime startDate = DateTime.Now;
            string response = "";
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            try
            {
                RestRequest request = new RestRequest("", Method.Get);
                request.RequestFormat = DataFormat.Json;
                RestClient client = new RestClient(endpoint);
                if(requestBody != null)
                {
                    request.AddBody(requestBody, "application/json");

                }
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }
                RestResponse restResponse = client.ExecuteGetAsync(request).GetAwaiter().GetResult();
                if (restResponse != null)
                {
                    response = restResponse.Content;
                    httpStatusCode = restResponse.StatusCode;
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
                throw;
            }
            finally
            {
                //LogDetail logDetail = new LogDetail();
                //logDetail.StartDate = startDate;
                //logDetail.Endpoint = endpoint;
                //logDetail.Request = requestBody;
                //logDetail.EndDate = DateTime.Now;
                //logDetail.HttpStatusCode = httpStatusCode;
                //logDetail.Response = response;
                //logger.Log(logDetail);
            }
            return response;
        }
    }
}
