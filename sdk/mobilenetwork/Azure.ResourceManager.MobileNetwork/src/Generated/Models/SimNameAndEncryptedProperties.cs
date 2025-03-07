// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> SIM name and encrypted properties. </summary>
    public partial class SimNameAndEncryptedProperties
    {
        /// <summary> Initializes a new instance of SimNameAndEncryptedProperties. </summary>
        /// <param name="name"> The name of the SIM. </param>
        /// <param name="internationalMobileSubscriberIdentity"> The international mobile subscriber identity (IMSI) for the SIM. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="internationalMobileSubscriberIdentity"/> is null. </exception>
        public SimNameAndEncryptedProperties(string name, string internationalMobileSubscriberIdentity)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(internationalMobileSubscriberIdentity, nameof(internationalMobileSubscriberIdentity));

            Name = name;
            SiteProvisioningState = new ChangeTrackingDictionary<string, SiteProvisioningState>();
            InternationalMobileSubscriberIdentity = internationalMobileSubscriberIdentity;
            StaticIPConfiguration = new ChangeTrackingList<SimStaticIPProperties>();
        }

        /// <summary> The name of the SIM. </summary>
        public string Name { get; }
        /// <summary> The provisioning state of the SIM resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> The state of the SIM resource. </summary>
        public SimState? SimState { get; }
        /// <summary> A dictionary of sites to the provisioning state of this SIM on that site. </summary>
        public IReadOnlyDictionary<string, SiteProvisioningState> SiteProvisioningState { get; }
        /// <summary> The international mobile subscriber identity (IMSI) for the SIM. </summary>
        public string InternationalMobileSubscriberIdentity { get; }
        /// <summary> The integrated circuit card ID (ICCID) for the SIM. </summary>
        public string IntegratedCircuitCardIdentifier { get; set; }
        /// <summary> An optional free-form text field that can be used to record the device type this SIM is associated with, for example 'Video camera'. The Azure portal allows SIMs to be grouped and filtered based on this value. </summary>
        public string DeviceType { get; set; }
        /// <summary> The SIM policy used by this SIM. The SIM policy must be in the same location as the SIM. </summary>
        internal WritableSubResource SimPolicy { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SimPolicyId
        {
            get => SimPolicy is null ? default : SimPolicy.Id;
            set
            {
                if (SimPolicy is null)
                    SimPolicy = new WritableSubResource();
                SimPolicy.Id = value;
            }
        }

        /// <summary> A list of static IP addresses assigned to this SIM. Each address is assigned at a defined network scope, made up of {attached data network, slice}. </summary>
        public IList<SimStaticIPProperties> StaticIPConfiguration { get; }
        /// <summary> The name of the SIM vendor who provided this SIM, if any. </summary>
        public string VendorName { get; }
        /// <summary> The public key fingerprint of the SIM vendor who provided this SIM, if any. </summary>
        public string VendorKeyFingerprint { get; }
        /// <summary> The encrypted SIM credentials. </summary>
        public string EncryptedCredentials { get; set; }
    }
}
