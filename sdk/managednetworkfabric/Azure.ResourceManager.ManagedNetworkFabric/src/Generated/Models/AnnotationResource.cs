// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Switch configuration entries require a description to discern between configuration groups. </summary>
    public partial class AnnotationResource
    {
        /// <summary> Initializes a new instance of AnnotationResource. </summary>
        public AnnotationResource()
        {
        }

        /// <summary> Initializes a new instance of AnnotationResource. </summary>
        /// <param name="annotation"> Switch configuration description. </param>
        internal AnnotationResource(string annotation)
        {
            Annotation = annotation;
        }

        /// <summary> Switch configuration description. </summary>
        public string Annotation { get; set; }
    }
}
