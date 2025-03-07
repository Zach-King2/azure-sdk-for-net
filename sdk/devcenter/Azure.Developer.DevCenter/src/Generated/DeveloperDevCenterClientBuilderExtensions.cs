// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Azure.Developer.DevCenter;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DevCenterClient"/>, <see cref="DevBoxesClient"/>, <see cref="EnvironmentsClient"/> to client builder. </summary>
    public static partial class DeveloperDevCenterClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DevCenterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        public static IAzureClientBuilder<DevCenterClient, DevCenterClientOptions> AddDevCenterClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DevCenterClient, DevCenterClientOptions>((options, cred) => new DevCenterClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="DevBoxesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        /// <param name="projectName"> The DevCenter Project upon which to execute operations. </param>
        public static IAzureClientBuilder<DevBoxesClient, DevCenterClientOptions> AddDevBoxesClient<TBuilder>(this TBuilder builder, Uri endpoint, string projectName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DevBoxesClient, DevCenterClientOptions>((options, cred) => new DevBoxesClient(endpoint, projectName, cred, options));
        }

        /// <summary> Registers a <see cref="EnvironmentsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        /// <param name="projectName"> The DevCenter Project upon which to execute operations. </param>
        public static IAzureClientBuilder<EnvironmentsClient, DevCenterClientOptions> AddEnvironmentsClient<TBuilder>(this TBuilder builder, Uri endpoint, string projectName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EnvironmentsClient, DevCenterClientOptions>((options, cred) => new EnvironmentsClient(endpoint, projectName, cred, options));
        }

        /// <summary> Registers a <see cref="DevCenterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DevCenterClient, DevCenterClientOptions> AddDevCenterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DevCenterClient, DevCenterClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="DevBoxesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DevBoxesClient, DevCenterClientOptions> AddDevBoxesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DevBoxesClient, DevCenterClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="EnvironmentsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<EnvironmentsClient, DevCenterClientOptions> AddEnvironmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EnvironmentsClient, DevCenterClientOptions>(configuration);
        }
    }
}
