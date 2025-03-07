// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> VirtualMachinePlacementHint represents a single scheduling hint of the virtual machine. </summary>
    public partial class VirtualMachinePlacementHint
    {
        /// <summary> Initializes a new instance of VirtualMachinePlacementHint. </summary>
        /// <param name="hintType"> The specification of whether this hint supports affinity or anti-affinity with the referenced resources. </param>
        /// <param name="resourceId"> The resource ID of the target object that the placement hints will be checked against, e.g., the bare metal node to host the virtual machine. </param>
        /// <param name="schedulingExecution"> The indicator of whether the hint is a hard or soft requirement during scheduling. </param>
        /// <param name="scope"> The scope for the virtual machine affinity or anti-affinity placement hint. It should always be "Machine" in the case of node affinity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public VirtualMachinePlacementHint(VirtualMachinePlacementHintType hintType, string resourceId, VirtualMachineSchedulingExecution schedulingExecution, VirtualMachinePlacementHintPodAffinityScope scope)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            HintType = hintType;
            ResourceId = resourceId;
            SchedulingExecution = schedulingExecution;
            Scope = scope;
        }

        /// <summary> The specification of whether this hint supports affinity or anti-affinity with the referenced resources. </summary>
        public VirtualMachinePlacementHintType HintType { get; set; }
        /// <summary> The resource ID of the target object that the placement hints will be checked against, e.g., the bare metal node to host the virtual machine. </summary>
        public string ResourceId { get; set; }
        /// <summary> The indicator of whether the hint is a hard or soft requirement during scheduling. </summary>
        public VirtualMachineSchedulingExecution SchedulingExecution { get; set; }
        /// <summary> The scope for the virtual machine affinity or anti-affinity placement hint. It should always be "Machine" in the case of node affinity. </summary>
        public VirtualMachinePlacementHintPodAffinityScope Scope { get; set; }
    }
}
