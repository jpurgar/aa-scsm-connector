﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using PurgarNET.AAConnector.Shared.AutomationClient.Models;
using System.Threading.Tasks;

namespace PurgarNET.AAConnector.Shared.AutomationClient
{
    public class AAUserClient : AAClientBase
    {
        public AAUserClient(Guid tenant, Guid subscriptionId, string resourceGroup, string automationAccountName, Guid clientId = default(Guid)) :
            base(tenant, subscriptionId, resourceGroup, automationAccountName,  AuthenticationType.Code, GetClientId(clientId), null)
        {

        }

        public static Guid GetClientId(Guid c)
        {
            if (c != default(Guid))
                return c;
            else
                return Parameters.CLIENT_ID;
        }
        
        public async Task<List<HybridRunbookWorkerGroup>> GetHybridRunbookWorkerGroupsAsync()
        {
            return await GetListAsync<HybridRunbookWorkerGroup>("hybridRunbookWorkerGroups");
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            return await GetListAsync<Job>("jobs");
        }
    }
}
