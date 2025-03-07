// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Samples
{
    public partial class Sample_GovernanceAssignmentCollection
    {
        // List governance assignments
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_ListGovernanceAssignments()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/examples/GovernanceAssignments/ListGovernanceAssignments_example.json
            // this example is just showing the usage of "GovernanceAssignments_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityAssessmentResource created on azure
            // for more information of creating SecurityAssessmentResource, please refer to the document of SecurityAssessmentResource
            string scope = "subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd";
            string assessmentName = "6b9421dd-5555-2251-9b3d-2be58e2f82cd";
            ResourceIdentifier securityAssessmentResourceId = SecurityAssessmentResource.CreateResourceIdentifier(scope, assessmentName);
            SecurityAssessmentResource securityAssessment = client.GetSecurityAssessmentResource(securityAssessmentResourceId);

            // get the collection of this GovernanceAssignmentResource
            GovernanceAssignmentCollection collection = securityAssessment.GetGovernanceAssignments();

            // invoke the operation and iterate over the result
            await foreach (GovernanceAssignmentResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GovernanceAssignmentData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get governanceAssignment by specific governanceAssignmentKey
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetGovernanceAssignmentBySpecificGovernanceAssignmentKey()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/examples/GovernanceAssignments/GetGovernanceAssignment_example.json
            // this example is just showing the usage of "GovernanceAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityAssessmentResource created on azure
            // for more information of creating SecurityAssessmentResource, please refer to the document of SecurityAssessmentResource
            string scope = "subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/resourceGroups/compute_servers/providers/Microsoft.Compute/virtualMachines/win2012";
            string assessmentName = "6b9421dd-5555-2251-9b3d-2be58e2f82cd";
            ResourceIdentifier securityAssessmentResourceId = SecurityAssessmentResource.CreateResourceIdentifier(scope, assessmentName);
            SecurityAssessmentResource securityAssessment = client.GetSecurityAssessmentResource(securityAssessmentResourceId);

            // get the collection of this GovernanceAssignmentResource
            GovernanceAssignmentCollection collection = securityAssessment.GetGovernanceAssignments();

            // invoke the operation
            string assignmentKey = "6634ff9f-127b-4bf2-8e6e-b1737f5e789c";
            GovernanceAssignmentResource result = await collection.GetAsync(assignmentKey);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GovernanceAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Get governanceAssignment by specific governanceAssignmentKey
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_GetGovernanceAssignmentBySpecificGovernanceAssignmentKey()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/examples/GovernanceAssignments/GetGovernanceAssignment_example.json
            // this example is just showing the usage of "GovernanceAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityAssessmentResource created on azure
            // for more information of creating SecurityAssessmentResource, please refer to the document of SecurityAssessmentResource
            string scope = "subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/resourceGroups/compute_servers/providers/Microsoft.Compute/virtualMachines/win2012";
            string assessmentName = "6b9421dd-5555-2251-9b3d-2be58e2f82cd";
            ResourceIdentifier securityAssessmentResourceId = SecurityAssessmentResource.CreateResourceIdentifier(scope, assessmentName);
            SecurityAssessmentResource securityAssessment = client.GetSecurityAssessmentResource(securityAssessmentResourceId);

            // get the collection of this GovernanceAssignmentResource
            GovernanceAssignmentCollection collection = securityAssessment.GetGovernanceAssignments();

            // invoke the operation
            string assignmentKey = "6634ff9f-127b-4bf2-8e6e-b1737f5e789c";
            bool result = await collection.ExistsAsync(assignmentKey);

            Console.WriteLine($"Succeeded: {result}");
        }

        // Create Governance assignment
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate_CreateGovernanceAssignment()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2022-01-01-preview/examples/GovernanceAssignments/PutGovernanceAssignment_example.json
            // this example is just showing the usage of "GovernanceAssignments_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityAssessmentResource created on azure
            // for more information of creating SecurityAssessmentResource, please refer to the document of SecurityAssessmentResource
            string scope = "subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/resourceGroups/compute_servers/providers/Microsoft.Compute/virtualMachines/win2012";
            string assessmentName = "6b9421dd-5555-2251-9b3d-2be58e2f82cd";
            ResourceIdentifier securityAssessmentResourceId = SecurityAssessmentResource.CreateResourceIdentifier(scope, assessmentName);
            SecurityAssessmentResource securityAssessment = client.GetSecurityAssessmentResource(securityAssessmentResourceId);

            // get the collection of this GovernanceAssignmentResource
            GovernanceAssignmentCollection collection = securityAssessment.GetGovernanceAssignments();

            // invoke the operation
            string assignmentKey = "6634ff9f-127b-4bf2-8e6e-b1737f5e789c";
            GovernanceAssignmentData data = new GovernanceAssignmentData()
            {
                Owner = "user@contoso.com",
                RemediationDueOn = DateTimeOffset.Parse("2022-01-07T13:00:00.0000000Z"),
                RemediationEta = new RemediationEta(DateTimeOffset.Parse("2022-01-08T13:00:00.0000000Z"), "Justification of ETA"),
                IsGracePeriod = true,
                GovernanceEmailNotification = new GovernanceEmailNotification()
                {
                    IsManagerEmailNotificationDisabled = false,
                    IsOwnerEmailNotificationDisabled = false,
                },
                AdditionalData = new GovernanceAssignmentAdditionalInfo()
                {
                    TicketNumber = 123123,
                    TicketLink = "https://snow.com",
                    TicketStatus = "Active",
                },
            };
            ArmOperation<GovernanceAssignmentResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, assignmentKey, data);
            GovernanceAssignmentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GovernanceAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
