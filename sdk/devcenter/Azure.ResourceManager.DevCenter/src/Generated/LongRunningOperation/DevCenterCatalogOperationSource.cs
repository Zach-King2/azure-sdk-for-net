// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DevCenter
{
    internal class DevCenterCatalogOperationSource : IOperationSource<DevCenterCatalogResource>
    {
        private readonly ArmClient _client;

        internal DevCenterCatalogOperationSource(ArmClient client)
        {
            _client = client;
        }

        DevCenterCatalogResource IOperationSource<DevCenterCatalogResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = DevCenterCatalogData.DeserializeDevCenterCatalogData(document.RootElement);
            return new DevCenterCatalogResource(_client, data);
        }

        async ValueTask<DevCenterCatalogResource> IOperationSource<DevCenterCatalogResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = DevCenterCatalogData.DeserializeDevCenterCatalogData(document.RootElement);
            return new DevCenterCatalogResource(_client, data);
        }
    }
}
