// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Communication;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Contract model of an ACS call participant. </summary>
    internal partial class CallParticipantInternal
    {
        /// <summary> Initializes a new instance of CallParticipantInternal. </summary>
        internal CallParticipantInternal()
        {
        }

        /// <summary> Initializes a new instance of CallParticipantInternal. </summary>
        /// <param name="identifier"> Communication identifier of the participant. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        internal CallParticipantInternal(CommunicationIdentifierModel identifier, bool? isMuted)
        {
            Identifier = identifier;
            IsMuted = isMuted;
        }

        /// <summary> Communication identifier of the participant. </summary>
        public CommunicationIdentifierModel Identifier { get; }
        /// <summary> Is participant muted. </summary>
        public bool? IsMuted { get; }
    }
}
