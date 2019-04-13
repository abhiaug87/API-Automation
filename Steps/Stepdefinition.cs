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
    [Binding]
   public class Stepdefinition 
    {

        [Given(@"I have an (.*)")]
        public void GivenIHaveAn(string endpoint)
        {
            RestApiHelper.SetUrl(endpoint);
        }

        [Given(@"I have some (.*) for webpay")]
        public void GivenIHaveSomeForWebpay(string endpoint)
        {
            RestApiHelper.SetWPUrl(endpoint);
        }

        [Given(@"I have some (.*) for business API")]
        public void GivenIHaveSomeForBusinessAPI(string endpoint)
        {
            RestApiHelper.BusinessUrl(endpoint);
        }

        [Given(@"I have some (.*) for casual pay")]
        public void GivenIHaveSomeForCasualPay(string endpoint)
        {
            RestApiHelper.CasualUrl(endpoint);
        }


        [When(@"I call the post method for (.*), (.*) and (.*)")]
        public void WhenICallThePostMethodForAnd(string clientid, string clientsecret, string granttype)
        {
            RestApiHelper.CreateRequest(clientid, clientsecret, granttype);
        }

        [When(@"I call the method to generate internal server error for webpay with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICallTheMethodToGenerateInternalServerErrorForWebpayWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            RestApiHelper.CreateISERequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
        }

        [Then(@"I am able to generate internal server error for parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateInternalServerErrorForParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetISEResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError), "The response has failed");
        }

        [Then(@"I am able to generate the access token (.*), (.*) and (.*)")]
        public void ThenIAmAbleToGenerateTheAccessToken(string clientid, string clientsecret, string granttype)
        {
            var response = RestApiHelper.GetResponse(clientid, clientsecret, granttype);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");            
        }

        [Then(@"I am able to generate the access token with parameters (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateTheAccessTokenWithParameters(string clientid, string clientsecret, string granttype)
        {
            var response = RestApiHelper.GetWebPayResponse(clientid, clientsecret, granttype);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
        }


        [When(@"I call the post method for (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICallThePostMethodFor(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber, string externalpaymentIdentifier)
        {
            RestApiHelper.CreateUnauthVisaRequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber, externalpaymentIdentifier);
        }

        [When(@"I call the method for casual payment with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICallTheMethodForCasualPaymentWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            RestApiHelper.CreateAuthCasualRequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
        }

        [When(@"I call the method for conflict with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICallTheMethodForConflictWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            RestApiHelper.CreateConflictCasualRequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
        }

        [Then(@"I am able to generate the response for conflict with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateTheResponseForConflictWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetConflictResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict), "The response has failed");
        }



        [Then(@"I am able to generate a response for (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateAResponseFor(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber, string externalpaymentIdentifier)
        {
            var response = RestApiHelper.GetUnauthVisaResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber, externalpaymentIdentifier);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "The response has failed");
        }

        [When(@"I am authorised to call the post method (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmAuthorisedToCallThePostMethod(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            RestApiHelper.CreateAuthVisaRequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
        }

        [When(@"I call the method for unprocessable entity with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICallTheMethodForUnprocessableEntityWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            RestApiHelper.CreateUnprocessableRequest(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
        }

        [Then(@"I am able to get a response for unprocessable entity with parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGetAResponseForUnprocessableEntityWithParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetUnprocessableResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusDescription, Is.EqualTo("Unprocessable Entity"), "The response has failed");
        }

        [Then(@"I am able to generate forbidden response for parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateForbiddenResponseForParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
                var response = RestApiHelper.GetForbiddenResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden), "The response has failed");
        }

        [Then(@"I am able to generate bad response for parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateBadResponseForParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetBadResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "The response has failed");
        }


        [Then(@"I am able to generate a successful response (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateASuccessfulResponse(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetAuthVisaResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The response has failed");
        }

        [Then(@"I am able to generate the response for parameters (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIAmAbleToGenerateTheResponseForParameters(string cardHolderName, string cardNumber, string cvc, string cardType, string expiryDate, string amount, string businessId, string bpayReferenceNumber)
        {
            var response = RestApiHelper.GetAuthCasualResponse(cardHolderName, cardNumber, cvc, cardType, expiryDate, amount, businessId, bpayReferenceNumber);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The response has failed");

        }


        [When(@"I call the get method for business API")]
        public void WhenICallTheGetMethodForBusinessAPI()
        {
            RestApiHelper.ReqFacName();
        }

        [Then(@"I am able to generate response with facility name and contract prefix")]
        public void ThenIAmAbleToGenerateResponseWithFacilityNameAndContractPrefix()
        {
            var response = RestApiHelper.GetFacName();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
        }



    }
}
