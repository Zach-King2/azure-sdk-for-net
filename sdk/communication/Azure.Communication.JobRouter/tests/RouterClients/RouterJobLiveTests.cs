﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterJobLiveTests : RouterLiveTestBase
    {
        public RouterJobLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Job Tests

        [Test]
        public async Task UpdateJobWithNotesWorksCorrectly()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(UpdateJobWithNotesWorksCorrectly)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(UpdateJobWithNotesWorksCorrectly));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(UpdateJobWithNotesWorksCorrectly)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            RouterJob? updatedJob1Response = null;
            // update job with notes
            DateTimeOffset updateNoteTimeStamp = new DateTimeOffset(2022, 9, 01, 3, 0, 0, new TimeSpan(0, 0, 0));

            try
            {
                updatedJob1Response = await routerClient.UpdateJobAsync(new UpdateJobOptions(jobId1)
                {
                    Notes =
                    {
                        new RouterJobNote { AddedAt = updateNoteTimeStamp, Message = "Fake notes attached to job with update" }
                    }
                });
            }
            catch (Exception)
            {
                updatedJob1Response = await routerClient.UpdateJobAsync(new UpdateJobOptions(jobId1)
                {
                    Notes =
                    {
                        new RouterJobNote { AddedAt = updateNoteTimeStamp, Message = "Fake notes attached to job with update" }
                    }
                });
            }

            Assert.IsNotEmpty(updatedJob1Response.Notes);
            Assert.IsTrue(updatedJob1Response.Notes.Count == 1);
        }

        [Test]
        public async Task GetJobsTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            var channelId = GenerateUniqueId($"{nameof(GetJobsTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                });

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId1))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId1)));
            var createJob1 = createJob1Response.Value;

            // wait for job1 to be in queued state
            var job1Result = await Poll(async () => await routerClient.GetJobAsync(createJob1.Id),
                job => job.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job1Result.Value.Status);

            // cancel job 1
            var cancelJob1Response = await routerClient.CancelJobAsync(new CancelJobOptions(createJob1.Id));

            // Create job 2
            var jobId2 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsTest)}2");
            var createJob2Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId2, channelId, createQueue.Id)
                {
                    Priority = 1
                });
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId2))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId2)));
            var createJob2 = createJob2Response.Value;

            var job2Result = await Poll(async () => await routerClient.GetJobAsync(createJob2.Id),
                job => job.Value.Status == RouterJobStatus.Queued,
                TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, job2Result.Value.Status);

            // test get jobs
            var getJobsResponse = routerClient.GetJobsAsync(new GetJobsOptions()
            {
                ChannelId = channelId,
                QueueId = createQueue.Id,
            });
            var allJobs = new List<string>();

            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 1))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));
            Assert.IsTrue(allJobs.Contains(createJob2.Id));
        }

        [Test]
        public async Task GetJobsWithSchedulingFiltersTest()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();

            var channelId = GenerateUniqueId($"{nameof(GetJobsWithSchedulingFiltersTest)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(GetJobsWithSchedulingFiltersTest));
            var createQueue = createQueueResponse.Value;

            // Create 2 jobs - Both should be in Queued state
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(GetJobsWithSchedulingFiltersTest)}1");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(DateTimeOffset.UtcNow.AddMinutes(1));
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    MatchingMode = new JobMatchingMode(new ScheduleAndSuspendMode(timeToEnqueueJob)),
                });

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId1))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId1)));
            var createJob1 = createJob1Response.Value;
            // test get jobs
            var getJobsResponse = routerClient.GetJobsAsync(new GetJobsOptions()
            {
                ChannelId = channelId,
                QueueId = createQueue.Id,
                ScheduledAfter = timeToEnqueueJob,
            });
            var allJobs = new List<string>();

            await foreach (var jobPage in getJobsResponse.AsPages(pageSizeHint: 1))
            {
                foreach (var job in jobPage.Values)
                {
                    allJobs.Add(job.Job.Id);
                }
            }

            Assert.IsTrue(allJobs.Contains(createJob1.Id));
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_StaticPriority()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();

            // Setup channel
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Channel");

            // Setup queue - to specify on job
            var createQueueResponse = await CreateQueueAsync($"{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-Q1_CP_StaticPriority");
            var createQueue = createQueueResponse.Value;

            // Setup Classification Policies
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}-CP_StaticPriority");
            var classificationPolicyName = $"StaticPriority-ClassificationPolicy";
            var priorityRule = new StaticRouterRule(new LabelValue(10));
            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    PrioritizationRule = priorityRule,
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job
            var jobId = GenerateUniqueId(
                $"{IdPrefix}{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");

            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: channelId,
                    classificationPolicyId: classificationPolicyId)
                {
                    ChannelReference = "123",
                    QueueId = createQueue.Id
                });
            var createJob = createJobResponse.Value;

            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(10, queuedJob.Value.Priority); // from classification policy
            Assert.AreEqual(createQueue.Id, queuedJob.Value.QueueId); // from direct queue assignment
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_StaticQueueSelector()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();
            // Setup channel
            var channelId = GenerateUniqueId($"Channel-{nameof(CreateJobWithClassificationPolicy_w_StaticQueueSelector)}");

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_StaticQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_StaticQueue");
            var classificationPolicyName = $"StaticQueueSelector-ClassificationPolicy";
            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    QueueSelectors = { new StaticQueueSelectorAttachment(new RouterQueueSelector(key: "Id", LabelOperator.Equal, value: new LabelValue(createQueue2.Id))) }
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));
            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-Job-{nameof(CreateJobWithClassificationPolicy_w_StaticPriority)}");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: channelId,
                    classificationPolicyId: createClassificationPolicy.Id)
                {
                    ChannelReference = "123"
                });
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            // Assert.AreEqual(1, queuedJob.Value.Priority); // default value TODO: Should be 0 or 1?
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from queue selector in classification policy

            // in-test cleanup
            await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id)); // other wise queue deletion will throw error
            await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId); // other wise default queue deletion will throw error
        }

        [Test]
        public async Task CreateJobWithClassificationPolicy_w_FallbackQueue()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();

            // Setup queue - to specify on classification default queue id
            var createQueue2Response = await CreateQueueAsync($"Q2_CP_FallbackQueue");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - created with fallback queue id and no queue selector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-CP_FallbackQueue");
            var classificationPolicyName = $"FallbackQueue-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id
                });
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            var createClassificationPolicy = createClassificationPolicyResponse.Value;

            // Create job - queue is not specified
            var jobId = GenerateUniqueId($"{IdPrefix}-JobWCp");
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: jobId,
                    channelId: $"CP_FallbackQueue",
                    classificationPolicyId: classificationPolicyId)
                {
                    ChannelReference = "123",
                    QueueId = null
                });
            AddForCleanup(new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(jobId))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(jobId)));
            var createJob = createJobResponse.Value;

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default priority value
            Assert.AreEqual(createQueue2.Id, queuedJob.Value.QueueId); // from fallback queue of classification policy
        }

        [Test]
        public async Task CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            JobRouterAdministrationClient routerAdministrationClient = CreateRouterAdministrationClientWithConnectionString();
            // Setup queue - to specify on classification default queue id
            var createQueue1Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q1_CP_JobQVsFallbackQ");
            var createQueue1 = createQueue1Response.Value;
            var createQueue2Response = await CreateQueueAsync($"{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-Q2_CP_JobQVsFallbackQ");
            var createQueue2 = createQueue2Response.Value;

            // Setup Classification Policy - no default queue id is specified while creating classification policy - queueId should be evaluated from queueSelector
            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}-{nameof(CreateJobWithQueue_And_ClassificationPolicy_w_FallbackQueue)}-CP_JobQVsFallbackQ");
            var classificationPolicyName = $"JobQVsFallbackQ-ClassificationPolicy";

            var createClassificationPolicyResponse = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueue2.Id,
                });
            var createClassificationPolicy = createClassificationPolicyResponse.Value;
            AddForCleanup(new Task(async () => await routerAdministrationClient.DeleteClassificationPolicyAsync(classificationPolicyId)));

            // Create job - queue1 specified - should override default queue of classification policy
            var createJobResponse = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(jobId: "JobWCpAndQ",
                    channelId: "ChatChannel",
                    classificationPolicyId: createClassificationPolicy.Id)
                {
                    ChannelReference = "123",
                    QueueId = createQueue1.Id,
                });
            var createJob = createJobResponse.Value;
            AddForCleanup( new Task(async () => await routerClient.CancelJobAsync(new CancelJobOptions(createJob.Id))));
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob.Id)));

            var queuedJob = await Poll(async () => await routerClient.GetJobAsync(createJob.Id),
                job => job.Value.Status == RouterJobStatus.Queued, TimeSpan.FromSeconds(10));

            Assert.AreEqual(RouterJobStatus.Queued, queuedJob.Value.Status);
            Assert.AreEqual(createJob.Id, queuedJob.Value.Id);
            Assert.AreEqual(1, queuedJob.Value.Priority); // default value
            Assert.AreEqual(createQueue1.Id, queuedJob.Value.QueueId); // from queue selector in classification policy
        }

        [Test]
        public async Task CreateJobAndRemoveProperty()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobAndRemoveProperty)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobAndRemoveProperty));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobAndRemoveProperty)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            var updatedJob1Response = await routerClient.UpdateJobAsync(createJob1.Id, RequestContent.Create(new { ChannelReference = (string?)null }));

            var retrievedJob = await routerClient.GetJobAsync(jobId1);

            Assert.True(string.IsNullOrWhiteSpace(retrievedJob.Value.ChannelReference));
        }

        [Test]
        public async Task CreateJobWithQueueAndMatchMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithQueueAndMatchMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithQueueAndMatchMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithQueueAndMatchMode)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new JobMatchingMode(new QueueAndMatchMode()),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.ModeType == JobMatchModeType.QueueAndMatchMode);
            Assert.IsNull(createJob1.MatchingMode.ScheduleAndSuspendMode);
            Assert.IsNull(createJob1.MatchingMode.SuspendMode);
            Assert.IsNotNull(createJob1.MatchingMode.QueueAndMatchMode);
        }

        [Test]
        public async Task CreateJobWithSuspendMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithSuspendMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithSuspendMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithSuspendMode)}1");
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new JobMatchingMode(new SuspendMode()),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.ModeType == JobMatchModeType.SuspendMode);
            Assert.IsNull(createJob1.MatchingMode.ScheduleAndSuspendMode);
            Assert.IsNotNull(createJob1.MatchingMode.SuspendMode);
            Assert.IsNull(createJob1.MatchingMode.QueueAndMatchMode);
        }

        [Test]
        public async Task CreateJobWithScheduleAndSuspendMode()
        {
            JobRouterClient routerClient = CreateRouterClientWithConnectionString();
            var channelId = GenerateUniqueId($"{nameof(CreateJobWithScheduleAndSuspendMode)}-Channel");

            // Setup queue
            var createQueueResponse = await CreateQueueAsync(nameof(CreateJobWithScheduleAndSuspendMode));
            var createQueue = createQueueResponse.Value;

            // Create 1 job
            var jobId1 = GenerateUniqueId($"{IdPrefix}{nameof(CreateJobWithScheduleAndSuspendMode)}1");
            var timeToEnqueueJob = GetOrSetScheduledTimeUtc(DateTimeOffset.UtcNow.AddSeconds(7));
            var createJob1Response = await routerClient.CreateJobAsync(
                new CreateJobOptions(jobId1, channelId, createQueue.Id)
                {
                    Priority = 1,
                    ChannelReference = "IncorrectValue",
                    MatchingMode = new JobMatchingMode(new ScheduleAndSuspendMode(timeToEnqueueJob)),
                });
            var createJob1 = createJob1Response.Value;
            AddForCleanup(new Task(async () => await routerClient.DeleteJobAsync(createJob1.Id)));

            Assert.IsTrue(createJob1.MatchingMode.ModeType == JobMatchModeType.ScheduleAndSuspendMode);
            Assert.IsNotNull(createJob1.MatchingMode.ScheduleAndSuspendMode);
            Assert.IsNull(createJob1.MatchingMode.SuspendMode);
            Assert.IsNull(createJob1.MatchingMode.QueueAndMatchMode);
        }

        #endregion Job Tests

    }
}
