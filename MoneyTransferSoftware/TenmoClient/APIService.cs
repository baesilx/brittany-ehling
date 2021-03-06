﻿using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient
{
    public class APIService
    {
        private readonly string API_URL = "https://localhost:44315/";
        private readonly IRestClient client = new RestClient(); //thing that can talk to the server

        public void SetToken(string token)
        {
            client.Authenticator = new JwtAuthenticator(token);
        }
        public Account GetAccount()
        {
            IRestRequest request = new RestRequest(API_URL + "account/");
            IRestResponse<Account> response = client.Get<Account>(request); //get request from the IRestClient
            //<Account> is an Account object we're asking for
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data; //the Account object we asked for (.Data is the data of what we asked for)
            }
            return null;
        }

        public TransferWithDetails GetTransferById(int transferId)
        {
            IRestRequest request = new RestRequest(API_URL + "transfer/" + transferId);
            IRestResponse<TransferWithDetails> response = client.Get<TransferWithDetails>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }

            return null;
        }

        public List<TransferWithDetails> GetTransferHistory()
        {
            IRestRequest request = new RestRequest(API_URL + "transfer/history");
            IRestResponse<List<TransferWithDetails>> response = client.Get<List<TransferWithDetails>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public List<API_User> ListUsers()
        {
            var allUsers = new List<API_User>();
            RestRequest request = new RestRequest(API_URL + "transfer");
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
            allUsers = response.Data;

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return allUsers;
            }
            return null;
        }
        public TransferWithDetails SendMoney(int receiverId, decimal amount)
        {
            NewTransfer nt = new NewTransfer(receiverId, amount);
            RestRequest request = new RestRequest(API_URL + $"transfer");
            request.AddJsonBody(nt);
            IRestResponse<TransferWithDetails> response = client.Post<TransferWithDetails>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }
        private void ProcessErrorResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
        }
    }
}
