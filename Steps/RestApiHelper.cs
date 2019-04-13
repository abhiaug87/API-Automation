using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using TechTalk.SpecFlow;
using System.IO;

namespace WebpayAPI.Steps
{
    public static class RestApiHelper
    {
        public static RestClient rc;
        public static RestRequest rq;
        public static string baseurl = "https://oc-cert.debitsuccess.com/";

        public static RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseurl, endpoint);
            return rc = new RestClient(url);
        }
        public static RestClient SetWPUrl(string endpoint)
        {
            var url = Path.Combine(baseurl, endpoint);
            return rc = new RestClient(url);
        }

        public static RestClient BusinessUrl(string endpoint)
        {
            var url = Path.Combine(baseurl, endpoint);
            return rc = new RestClient(url);
        }

        public static RestClient CasualUrl(string endpoint)
        {
            var url = Path.Combine(baseurl, endpoint);
            return rc = new RestClient(url);
        }

        public static RestRequest CreateRequest(string clientid, string clientsecret, string granttype)
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("identity/connect/token", Method.POST);
            rq.AddParameter(new Parameter("client_id", clientid, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("client_secret", clientsecret, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("grant_type", granttype, ParameterType.GetOrPost));
            return rq;
        }
        public static RestRequest CreateUnauthVisaRequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber, string externalpaymentIdentifier)
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/webpay", Method.POST);
            rq.AddParameter(new Parameter("cardHolderName", cardHolderName, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardHolderName", cardHolderName, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardNumber", cardNumber, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cvc", cvc, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardType", cardType, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardNumber", cardNumber, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("expiryDate", expiryDate, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("amount", amount, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("businessId", businessId, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("externalpaymentIdentifier", externalpaymentIdentifier, ParameterType.GetOrPost));
            return rq;
        }
        public static RestRequest CreateAuthVisaRequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            Random rnd = new Random();
            int externalIdentifier = rnd.Next(111111111, 999999999);
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\output.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            json.Property("expires_in").Remove();
            json.Property("token_type").Remove();
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/webpay", Method.POST);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddJsonBody(new { CardHolderName = cardHolderName, CardNumber = cardNumber, Cvc = cvc,
                CardType = cardType, ExpiryDate = expiryDate, Amount = amount,
                BusinessId = businessId, BpayReferenceNumber = bpayReferenceNumber, ExternalPaymentIdentifier = externalIdentifier });
            return rq;
        }

        public static RestRequest CreateISERequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            Random rnd = new Random();
            int externalIdentifier = rnd.Next(111111111, 999999999);
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\output.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            json.Property("expires_in").Remove();
            json.Property("token_type").Remove();
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/webpay", Method.POST);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddParameter(new Parameter("cardHolderName", cardHolderName, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardHolderName", cardHolderName, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardNumber", cardNumber, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cvc", cvc, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardType", cardType, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("cardNumber", cardNumber, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("expiryDate", expiryDate, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("amount", amount, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("businessId", businessId, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("externalpaymentIdentifier", externalIdentifier, ParameterType.GetOrPost));
            return rq;
        }

        public static RestRequest CreateUnprocessableRequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            Random rnd = new Random();
            int externalIdentifier = rnd.Next(111111111, 999999999);
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\outfile.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            json.Property("expires_in").Remove();
            json.Property("token_type").Remove();
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/webpay", Method.POST);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddJsonBody(new
            {
                CardHolderName = cardHolderName,
                CardNumber = cardNumber,
                Cvc = cvc,
                CardType = cardType,
                ExpiryDate = expiryDate,
                Amount = amount,
                BusinessId = businessId,
                BpayReferenceNumber = bpayReferenceNumber,
                ExternalPaymentIdentifier = externalIdentifier
            });
            return rq;
        }

        public static RestRequest ReqFacName()
        {
        StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\outfile.txt");
        string authTOken = reader.ReadToEnd();
        JObject json = JObject.Parse(authTOken);
        json.Property("expires_in").Remove();
        json.Property("token_type").Remove();
        rc = new RestClient(baseurl);
        rc.AddDefaultHeader("Content-Type", "application/json");
        rc.AddDefaultHeader("Authorization", "Bearer " + json.GetValue("access_token"));
        rq = new RestRequest("business/v1/businessaccounts?BillerCode=374397&Crn=18890571956", Method.GET);
        return rq;
        }

        public static IRestResponse GetResponse(string clientid, string clientsecret, string granttype)
        {
            StreamWriter outfile = new StreamWriter("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\outfile.txt");
            var response = rc.Execute(rq);
            outfile.Write(response.Content.ToString());
            outfile.Close();
            return response;
        }

        public static IRestResponse GetWebPayResponse(string clientid, string clientsecret, string granttype)
        {
            StreamWriter output = new StreamWriter("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\output.txt");
            var response = rc.Execute(rq);
            output.Write(response.Content.ToString());
            output.Close();
            return response;
        }

        public static IRestResponse GetUnprocessableResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetForbiddenResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetBadResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetUnauthVisaResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber, string externalpaymentIdentifier)
        {
            var response = rc.Execute(rq);
            return response;
        }
        public static IRestResponse GetAuthVisaResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetAuthCasualResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetConflictResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetISEResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }

        public static IRestResponse GetFacName()
        {
            StreamWriter output = new StreamWriter("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\facname.txt");
            var response = rc.Execute(rq);
            output.Write(response.Content.ToString());
            output.Close();
            return response;
        }

        public static RestRequest CreateAuthCasualRequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            Random rnd = new Random();
            int externalIdentifier = rnd.Next(111111111, 999999999);
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\outfile.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            json.Property("expires_in").Remove();
            json.Property("token_type").Remove();
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/creditcard", Method.POST);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddJsonBody(new
            {
                CardHolderName = cardHolderName,
                CardNumber = cardNumber,
                Cvc = cvc,
                CardType = cardType,
                ExpiryDate = expiryDate,
                Amount = amount,
                BusinessId = businessId,
                BpayReferenceNumber = bpayReferenceNumber,
                ExternalPaymentIdentifier = externalIdentifier
            });
            return rq;
        }

        public static RestRequest CreateConflictCasualRequest(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            Random rnd = new Random();
            int externalIdentifier = rnd.Next(111111111, 999999999);
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\WebpayAPI\\Output\\outfile.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            json.Property("expires_in").Remove();
            json.Property("token_type").Remove();
            rc = new RestClient(baseurl);
            rq = new RestRequest("Payments/v1.0/casual/creditcard", Method.POST);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddJsonBody(new
            {
                CardHolderName = cardHolderName,
                CardNumber = cardNumber,
                Cvc = cvc,
                CardType = cardType,
                ExpiryDate = expiryDate,
                Amount = amount,
                BusinessId = businessId,
                BpayReferenceNumber = bpayReferenceNumber,
                ExternalPaymentIdentifier = "296695375"
            });
            return rq;
        }
    }

    
}

