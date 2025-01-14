// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Properties to configure keyVault Properties. </summary>
    public partial class CognitiveServicesKeyVaultProperties
    {
        /// <summary> Initializes a new instance of CognitiveServicesKeyVaultProperties. </summary>
        public CognitiveServicesKeyVaultProperties()
        {
        }

        /// <summary> Initializes a new instance of CognitiveServicesKeyVaultProperties. </summary>
        /// <param name="keyName"> Name of the Key from KeyVault. </param>
        /// <param name="keyVersion"> Version of the Key from KeyVault. </param>
        /// <param name="keyVaultUri"> Uri of KeyVault. </param>
        /// <param name="identityClientId"></param>
        internal CognitiveServicesKeyVaultProperties(string keyName, string keyVersion, Uri keyVaultUri, Guid? identityClientId)
        {
            KeyName = keyName;
            KeyVersion = keyVersion;
            KeyVaultUri = keyVaultUri;
            IdentityClientId = identityClientId;
        }

        /// <summary> Name of the Key from KeyVault. </summary>
        public string KeyName { get; set; }
        /// <summary> Version of the Key from KeyVault. </summary>
        public string KeyVersion { get; set; }
        /// <summary> Uri of KeyVault. </summary>
        public Uri KeyVaultUri { get; set; }
        /// <summary> Gets or sets the identity client id. </summary>
        public Guid? IdentityClientId { get; set; }
    }
}
