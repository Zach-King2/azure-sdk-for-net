// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Advisor
{
    /// <summary>
    /// A class representing a collection of <see cref="ResourceRecommendationBaseResource" /> and their operations.
    /// Each <see cref="ResourceRecommendationBaseResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="ResourceRecommendationBaseCollection" /> instance call the GetResourceRecommendationBases method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class ResourceRecommendationBaseCollection : ArmCollection, IEnumerable<ResourceRecommendationBaseResource>, IAsyncEnumerable<ResourceRecommendationBaseResource>
    {
        private readonly ClientDiagnostics _resourceRecommendationBaseRecommendationsClientDiagnostics;
        private readonly RecommendationsRestOperations _resourceRecommendationBaseRecommendationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceRecommendationBaseCollection"/> class for mocking. </summary>
        protected ResourceRecommendationBaseCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceRecommendationBaseCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResourceRecommendationBaseCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resourceRecommendationBaseRecommendationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Advisor", ResourceRecommendationBaseResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceRecommendationBaseResource.ResourceType, out string resourceRecommendationBaseRecommendationsApiVersion);
            _resourceRecommendationBaseRecommendationsRestClient = new RecommendationsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resourceRecommendationBaseRecommendationsApiVersion);
        }

        /// <summary>
        /// Obtains details of a cached recommendation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recommendationId"> The recommendation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recommendationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recommendationId"/> is null. </exception>
        public virtual async Task<Response<ResourceRecommendationBaseResource>> GetAsync(string recommendationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recommendationId, nameof(recommendationId));

            using var scope = _resourceRecommendationBaseRecommendationsClientDiagnostics.CreateScope("ResourceRecommendationBaseCollection.Get");
            scope.Start();
            try
            {
                var response = await _resourceRecommendationBaseRecommendationsRestClient.GetAsync(Id, recommendationId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceRecommendationBaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Obtains details of a cached recommendation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recommendationId"> The recommendation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recommendationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recommendationId"/> is null. </exception>
        public virtual Response<ResourceRecommendationBaseResource> Get(string recommendationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recommendationId, nameof(recommendationId));

            using var scope = _resourceRecommendationBaseRecommendationsClientDiagnostics.CreateScope("ResourceRecommendationBaseCollection.Get");
            scope.Start();
            try
            {
                var response = _resourceRecommendationBaseRecommendationsRestClient.Get(Id, recommendationId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceRecommendationBaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Obtains cached recommendations for a subscription. The recommendations are generated or computed by invoking generateRecommendations.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply to the recommendations.&lt;br&gt;Filter can be applied to properties ['ResourceId', 'ResourceGroup', 'RecommendationTypeGuid', '[Category](#category)'] with operators ['eq', 'and', 'or'].&lt;br&gt;Example:&lt;br&gt;- $filter=Category eq 'Cost' and ResourceGroup eq 'MyResourceGroup'. </param>
        /// <param name="top"> The number of recommendations per page if a paged version of this API is being used. </param>
        /// <param name="skipToken"> The page-continuation token to use with a paged version of this API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceRecommendationBaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceRecommendationBaseResource> GetAllAsync(string filter = null, int? top = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resourceRecommendationBaseRecommendationsRestClient.CreateListRequest(Id.SubscriptionId, filter, top, skipToken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resourceRecommendationBaseRecommendationsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter, top, skipToken);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResourceRecommendationBaseResource(Client, ResourceRecommendationBaseData.DeserializeResourceRecommendationBaseData(e)), _resourceRecommendationBaseRecommendationsClientDiagnostics, Pipeline, "ResourceRecommendationBaseCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Obtains cached recommendations for a subscription. The recommendations are generated or computed by invoking generateRecommendations.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply to the recommendations.&lt;br&gt;Filter can be applied to properties ['ResourceId', 'ResourceGroup', 'RecommendationTypeGuid', '[Category](#category)'] with operators ['eq', 'and', 'or'].&lt;br&gt;Example:&lt;br&gt;- $filter=Category eq 'Cost' and ResourceGroup eq 'MyResourceGroup'. </param>
        /// <param name="top"> The number of recommendations per page if a paged version of this API is being used. </param>
        /// <param name="skipToken"> The page-continuation token to use with a paged version of this API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceRecommendationBaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceRecommendationBaseResource> GetAll(string filter = null, int? top = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resourceRecommendationBaseRecommendationsRestClient.CreateListRequest(Id.SubscriptionId, filter, top, skipToken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resourceRecommendationBaseRecommendationsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, filter, top, skipToken);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResourceRecommendationBaseResource(Client, ResourceRecommendationBaseData.DeserializeResourceRecommendationBaseData(e)), _resourceRecommendationBaseRecommendationsClientDiagnostics, Pipeline, "ResourceRecommendationBaseCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recommendationId"> The recommendation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recommendationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recommendationId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string recommendationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recommendationId, nameof(recommendationId));

            using var scope = _resourceRecommendationBaseRecommendationsClientDiagnostics.CreateScope("ResourceRecommendationBaseCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resourceRecommendationBaseRecommendationsRestClient.GetAsync(Id, recommendationId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Recommendations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recommendationId"> The recommendation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recommendationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recommendationId"/> is null. </exception>
        public virtual Response<bool> Exists(string recommendationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recommendationId, nameof(recommendationId));

            using var scope = _resourceRecommendationBaseRecommendationsClientDiagnostics.CreateScope("ResourceRecommendationBaseCollection.Exists");
            scope.Start();
            try
            {
                var response = _resourceRecommendationBaseRecommendationsRestClient.Get(Id, recommendationId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResourceRecommendationBaseResource> IEnumerable<ResourceRecommendationBaseResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResourceRecommendationBaseResource> IAsyncEnumerable<ResourceRecommendationBaseResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
