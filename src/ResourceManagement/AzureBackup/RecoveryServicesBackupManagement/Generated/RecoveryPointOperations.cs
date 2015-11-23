// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    /// <summary>
    /// Definition of Backup operations for the Azure Backup extension.
    /// </summary>
    internal partial class RecoveryPointOperations : IServiceOperations<RecoveryServicesBackupManagementClient>, IRecoveryPointOperations
    {
        /// <summary>
        /// Initializes a new instance of the RecoveryPointOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RecoveryPointOperations(RecoveryServicesBackupManagementClient client)
        {
            this._client = client;
        }
        
        private RecoveryServicesBackupManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupManagementClient.
        /// </summary>
        public RecoveryServicesBackupManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get recovery point for a given recovery point id
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. ResourceGroupName for recoveryServices Vault.
        /// </param>
        /// <param name='resourceName'>
        /// Required. ResourceName for recoveryServices Vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='fabricName'>
        /// Optional. Backup Fabric name for the backup item
        /// </param>
        /// <param name='containerName'>
        /// Optional. Container Name for the backup item
        /// </param>
        /// <param name='protectedItemName'>
        /// Optional. Protected item name for the backup item
        /// </param>
        /// <param name='recoveryPointId'>
        /// Optional. Recovery point id for the backup item
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The definition of a RecoveryPointResponse object.
        /// </returns>
        public async Task<RecoveryPointResponse> GetAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string fabricName, string containerName, string protectedItemName, string recoveryPointId, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                tracingParameters.Add("fabricName", fabricName);
                tracingParameters.Add("containerName", containerName);
                tracingParameters.Add("protectedItemName", protectedItemName);
                tracingParameters.Add("recoveryPointId", recoveryPointId);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + null;
            url = url + "/";
            url = url + "recoveryServicesVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/backupFabrics/";
            if (fabricName != null)
            {
                url = url + Uri.EscapeDataString(fabricName);
            }
            url = url + "/protectionContainers/";
            if (containerName != null)
            {
                url = url + Uri.EscapeDataString(containerName);
            }
            url = url + "/protectedItems/";
            if (protectedItemName != null)
            {
                url = url + Uri.EscapeDataString(protectedItemName);
            }
            url = url + "/recoveryPoints/";
            if (recoveryPointId != null)
            {
                url = url + Uri.EscapeDataString(recoveryPointId);
            }
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-09-01");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", "en-us");
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RecoveryPointResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new RecoveryPointResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken recoveryPointValue = responseDoc["recoveryPoint"];
                            if (recoveryPointValue != null && recoveryPointValue.Type != JTokenType.Null)
                            {
                                RecoveryPointResource recoveryPointInstance = new RecoveryPointResource();
                                result.RecPoint = recoveryPointInstance;
                                
                                JToken propertiesValue = recoveryPointValue["properties"];
                                if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                {
                                    string typeName = ((string)propertiesValue["ObjectType"]);
                                    if (typeName == "RecoveryPoint")
                                    {
                                        RecoveryPoint recoveryPointInstance2 = new RecoveryPoint();
                                        
                                        JToken recoveryPointTypeValue = propertiesValue["recoveryPointType"];
                                        if (recoveryPointTypeValue != null && recoveryPointTypeValue.Type != JTokenType.Null)
                                        {
                                            string recoveryPointTypeInstance = ((string)recoveryPointTypeValue);
                                            recoveryPointInstance2.RecoveryPointType = recoveryPointTypeInstance;
                                        }
                                        
                                        JToken recoveryPointTimeValue = propertiesValue["recoveryPointTime"];
                                        if (recoveryPointTimeValue != null && recoveryPointTimeValue.Type != JTokenType.Null)
                                        {
                                            string recoveryPointTimeInstance = ((string)recoveryPointTimeValue);
                                            recoveryPointInstance2.RecoveryPointTime = recoveryPointTimeInstance;
                                        }
                                        
                                        JToken recoveryPointAdditionalInfoValue = propertiesValue["recoveryPointAdditionalInfo"];
                                        if (recoveryPointAdditionalInfoValue != null && recoveryPointAdditionalInfoValue.Type != JTokenType.Null)
                                        {
                                            string recoveryPointAdditionalInfoInstance = ((string)recoveryPointAdditionalInfoValue);
                                            recoveryPointInstance2.RecoveryPointAdditionalInfo = recoveryPointAdditionalInfoInstance;
                                        }
                                        recoveryPointInstance.Properties = recoveryPointInstance2;
                                    }
                                }
                                
                                JToken idValue = recoveryPointValue["id"];
                                if (idValue != null && idValue.Type != JTokenType.Null)
                                {
                                    string idInstance = ((string)idValue);
                                    recoveryPointInstance.Id = idInstance;
                                }
                                
                                JToken nameValue = recoveryPointValue["name"];
                                if (nameValue != null && nameValue.Type != JTokenType.Null)
                                {
                                    string nameInstance = ((string)nameValue);
                                    recoveryPointInstance.Name = nameInstance;
                                }
                                
                                JToken typeValue = recoveryPointValue["type"];
                                if (typeValue != null && typeValue.Type != JTokenType.Null)
                                {
                                    string typeInstance = ((string)typeValue);
                                    recoveryPointInstance.Type = typeInstance;
                                }
                                
                                JToken locationValue = recoveryPointValue["location"];
                                if (locationValue != null && locationValue.Type != JTokenType.Null)
                                {
                                    string locationInstance = ((string)locationValue);
                                    recoveryPointInstance.Location = locationInstance;
                                }
                                
                                JToken tagsSequenceElement = ((JToken)recoveryPointValue["tags"]);
                                if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                                {
                                    foreach (JProperty property in tagsSequenceElement)
                                    {
                                        string tagsKey = ((string)property.Name);
                                        string tagsValue = ((string)property.Value);
                                        recoveryPointInstance.Tags.Add(tagsKey, tagsValue);
                                    }
                                }
                                
                                JToken eTagValue = recoveryPointValue["eTag"];
                                if (eTagValue != null && eTagValue.Type != JTokenType.Null)
                                {
                                    string eTagInstance = ((string)eTagValue);
                                    recoveryPointInstance.ETag = eTagInstance;
                                }
                            }
                            
                            JToken locationValue2 = responseDoc["location"];
                            if (locationValue2 != null && locationValue2.Type != JTokenType.Null)
                            {
                                string locationInstance2 = ((string)locationValue2);
                                result.Location = locationInstance2;
                            }
                            
                            JToken azureAsyncOperationValue = responseDoc["azureAsyncOperation"];
                            if (azureAsyncOperationValue != null && azureAsyncOperationValue.Type != JTokenType.Null)
                            {
                                string azureAsyncOperationInstance = ((string)azureAsyncOperationValue);
                                result.AzureAsyncOperation = azureAsyncOperationInstance;
                            }
                            
                            JToken retryAfterValue = responseDoc["retryAfter"];
                            if (retryAfterValue != null && retryAfterValue.Type != JTokenType.Null)
                            {
                                string retryAfterInstance = ((string)retryAfterValue);
                                result.RetryAfter = retryAfterInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get recovery point list for a given protected item
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. ResourceGroupName for recoveryServices Vault.
        /// </param>
        /// <param name='resourceName'>
        /// Required. ResourceName for recoveryServices Vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='fabricName'>
        /// Optional. Backup Fabric name for the backup item
        /// </param>
        /// <param name='containerName'>
        /// Optional. Container Name for the backup item
        /// </param>
        /// <param name='protectedItemName'>
        /// Optional. Protected item name for the backup item
        /// </param>
        /// <param name='queryFilter'>
        /// Optional. Recovery point id for the backup item
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The definition of a RecoveryPointListResponse object.
        /// </returns>
        public async Task<RecoveryPointListResponse> ListAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string fabricName, string containerName, string protectedItemName, RecoveryPointQueryParameters queryFilter, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                tracingParameters.Add("fabricName", fabricName);
                tracingParameters.Add("containerName", containerName);
                tracingParameters.Add("protectedItemName", protectedItemName);
                tracingParameters.Add("queryFilter", queryFilter);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + null;
            url = url + "/";
            url = url + "recoveryServicesVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/backupFabrics/";
            if (fabricName != null)
            {
                url = url + Uri.EscapeDataString(fabricName);
            }
            url = url + "/protectionContainers/";
            if (containerName != null)
            {
                url = url + Uri.EscapeDataString(containerName);
            }
            url = url + "/protectedItems/";
            if (protectedItemName != null)
            {
                url = url + Uri.EscapeDataString(protectedItemName);
            }
            url = url + "/recoveryPoints";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-09-01");
            List<string> odataFilter = new List<string>();
            if (queryFilter != null && queryFilter.StartDate != null)
            {
                odataFilter.Add("startDate eq '" + Uri.EscapeDataString(queryFilter.StartDate) + "'");
            }
            if (queryFilter != null && queryFilter.EndDate != null)
            {
                odataFilter.Add("endDate eq '" + Uri.EscapeDataString(queryFilter.EndDate) + "'");
            }
            if (odataFilter.Count > 0)
            {
                queryParameters.Add("$filter=" + string.Join(" and ", odataFilter));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", "en-us");
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RecoveryPointListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new RecoveryPointListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken recoveryPointListValue = responseDoc["recoveryPointList"];
                            if (recoveryPointListValue != null && recoveryPointListValue.Type != JTokenType.Null)
                            {
                                RecoveryPointResourceList recoveryPointListInstance = new RecoveryPointResourceList();
                                result.RecoveryPointList = recoveryPointListInstance;
                                
                                JToken valueArray = recoveryPointListValue["value"];
                                if (valueArray != null && valueArray.Type != JTokenType.Null)
                                {
                                    foreach (JToken valueValue in ((JArray)valueArray))
                                    {
                                        RecoveryPointResource recoveryPointResourceInstance = new RecoveryPointResource();
                                        recoveryPointListInstance.RecoveryPoints.Add(recoveryPointResourceInstance);
                                        
                                        JToken propertiesValue = valueValue["properties"];
                                        if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                        {
                                            string typeName = ((string)propertiesValue["ObjectType"]);
                                            if (typeName == "RecoveryPoint")
                                            {
                                                RecoveryPoint recoveryPointInstance = new RecoveryPoint();
                                                
                                                JToken recoveryPointTypeValue = propertiesValue["recoveryPointType"];
                                                if (recoveryPointTypeValue != null && recoveryPointTypeValue.Type != JTokenType.Null)
                                                {
                                                    string recoveryPointTypeInstance = ((string)recoveryPointTypeValue);
                                                    recoveryPointInstance.RecoveryPointType = recoveryPointTypeInstance;
                                                }
                                                
                                                JToken recoveryPointTimeValue = propertiesValue["recoveryPointTime"];
                                                if (recoveryPointTimeValue != null && recoveryPointTimeValue.Type != JTokenType.Null)
                                                {
                                                    string recoveryPointTimeInstance = ((string)recoveryPointTimeValue);
                                                    recoveryPointInstance.RecoveryPointTime = recoveryPointTimeInstance;
                                                }
                                                
                                                JToken recoveryPointAdditionalInfoValue = propertiesValue["recoveryPointAdditionalInfo"];
                                                if (recoveryPointAdditionalInfoValue != null && recoveryPointAdditionalInfoValue.Type != JTokenType.Null)
                                                {
                                                    string recoveryPointAdditionalInfoInstance = ((string)recoveryPointAdditionalInfoValue);
                                                    recoveryPointInstance.RecoveryPointAdditionalInfo = recoveryPointAdditionalInfoInstance;
                                                }
                                                recoveryPointResourceInstance.Properties = recoveryPointInstance;
                                            }
                                        }
                                        
                                        JToken idValue = valueValue["id"];
                                        if (idValue != null && idValue.Type != JTokenType.Null)
                                        {
                                            string idInstance = ((string)idValue);
                                            recoveryPointResourceInstance.Id = idInstance;
                                        }
                                        
                                        JToken nameValue = valueValue["name"];
                                        if (nameValue != null && nameValue.Type != JTokenType.Null)
                                        {
                                            string nameInstance = ((string)nameValue);
                                            recoveryPointResourceInstance.Name = nameInstance;
                                        }
                                        
                                        JToken typeValue = valueValue["type"];
                                        if (typeValue != null && typeValue.Type != JTokenType.Null)
                                        {
                                            string typeInstance = ((string)typeValue);
                                            recoveryPointResourceInstance.Type = typeInstance;
                                        }
                                        
                                        JToken locationValue = valueValue["location"];
                                        if (locationValue != null && locationValue.Type != JTokenType.Null)
                                        {
                                            string locationInstance = ((string)locationValue);
                                            recoveryPointResourceInstance.Location = locationInstance;
                                        }
                                        
                                        JToken tagsSequenceElement = ((JToken)valueValue["tags"]);
                                        if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                                        {
                                            foreach (JProperty property in tagsSequenceElement)
                                            {
                                                string tagsKey = ((string)property.Name);
                                                string tagsValue = ((string)property.Value);
                                                recoveryPointResourceInstance.Tags.Add(tagsKey, tagsValue);
                                            }
                                        }
                                        
                                        JToken eTagValue = valueValue["eTag"];
                                        if (eTagValue != null && eTagValue.Type != JTokenType.Null)
                                        {
                                            string eTagInstance = ((string)eTagValue);
                                            recoveryPointResourceInstance.ETag = eTagInstance;
                                        }
                                    }
                                }
                                
                                JToken nextLinkValue = recoveryPointListValue["nextLink"];
                                if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                                {
                                    string nextLinkInstance = ((string)nextLinkValue);
                                    recoveryPointListInstance.NextLink = nextLinkInstance;
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
