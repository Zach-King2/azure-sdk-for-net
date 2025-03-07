// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Model factory for models. </summary>
    public static partial class CommunicationCallAutomationModelFactory
    {
        /// <summary> Initializes a new instance of TransferCallToParticipantResult. </summary>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.TransferCallToParticipantResult"/> instance for mocking. </returns>
        public static TransferCallToParticipantResult TransferCallToParticipantResult(string operationContext = null)
        {
            return new TransferCallToParticipantResult(operationContext);
        }

        /// <summary> Initializes a new instance of MuteParticipantsResponse. </summary>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.MuteParticipantsResponse"/> instance for mocking. </returns>
        public static MuteParticipantsResponse MuteParticipantsResponse(string operationContext = null)
        {
            return new MuteParticipantsResponse(operationContext);
        }

        /// <summary> Initializes a new instance of UnmuteParticipantsResponse. </summary>
        /// <param name="operationContext"> The operation context provided by client. </param>
        /// <returns> A new <see cref="CallAutomation.UnmuteParticipantsResponse"/> instance for mocking. </returns>
        public static UnmuteParticipantsResponse UnmuteParticipantsResponse(string operationContext = null)
        {
            return new UnmuteParticipantsResponse(operationContext);
        }

        /// <summary> Initializes a new instance of RecordingStateResult. </summary>
        /// <param name="recordingId"></param>
        /// <param name="recordingState"></param>
        /// <returns> A new <see cref="CallAutomation.RecordingStateResult"/> instance for mocking. </returns>
        public static RecordingStateResult RecordingStateResult(string recordingId = null, RecordingState? recordingState = null)
        {
            return new RecordingStateResult(recordingId, recordingState);
        }

        /// <summary> Initializes a new instance of ResultInformation. </summary>
        /// <param name="code"> Code of the current result. This can be helpful to Call Automation team to troubleshoot the issue if this result was unexpected. </param>
        /// <param name="subCode"> Subcode of the current result. This can be helpful to Call Automation team to troubleshoot the issue if this result was unexpected. </param>
        /// <param name="message"> Detail message that describes the current result. </param>
        /// <returns> A new <see cref="CallAutomation.ResultInformation"/> instance for mocking. </returns>
        public static ResultInformation ResultInformation(int? code = null, int? subCode = null, string message = null)
        {
            return new ResultInformation(code, subCode, message);
        }

        /// <summary> Initializes a new instance of CallConnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers to set the context for creating a new call. This property will be null for answering a call. </param>
        /// <returns> A new <see cref="CallAutomation.CallConnected"/> instance for mocking. </returns>
        public static CallConnected CallConnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new CallConnected(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of CallDisconnected. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers to set the context for creating a new call. This property will be null for answering a call. </param>
        /// <returns> A new <see cref="CallAutomation.CallDisconnected"/> instance for mocking. </returns>
        public static CallDisconnected CallDisconnected(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new CallDisconnected(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of CallTransferAccepted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferAccepted"/> instance for mocking. </returns>
        public static CallTransferAccepted CallTransferAccepted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallTransferAccepted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of CallTransferFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <returns> A new <see cref="CallAutomation.CallTransferFailed"/> instance for mocking. </returns>
        public static CallTransferFailed CallTransferFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new CallTransferFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of RecordingStateChanged. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="recordingId"> The call recording id. </param>
        /// <param name="state"></param>
        /// <param name="startDateTime"> The time of the recording started. </param>
        /// <returns> A new <see cref="CallAutomation.RecordingStateChanged"/> instance for mocking. </returns>
        public static RecordingStateChanged RecordingStateChanged(string callConnectionId = null, string serverCallId = null, string correlationId = null, string recordingId = null, RecordingState state = default, DateTimeOffset? startDateTime = null)
        {
            return new RecordingStateChanged(callConnectionId, serverCallId, correlationId, recordingId, state, startDateTime);
        }

        /// <summary> Initializes a new instance of PlayCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCompleted"/> instance for mocking. </returns>
        public static PlayCompleted PlayCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.PlayFailed"/> instance for mocking. </returns>
        public static PlayFailed PlayFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new PlayFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of PlayCanceled. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.PlayCanceled"/> instance for mocking. </returns>
        public static PlayCanceled PlayCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new PlayCanceled(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of CollectTonesResult. </summary>
        /// <param name="tones"></param>
        /// <returns> A new <see cref="CallAutomation.CollectTonesResult"/> instance for mocking. </returns>
        public static CollectTonesResult CollectTonesResult(IEnumerable<DtmfTone> tones = null)
        {
            tones ??= new List<DtmfTone>();

            return new CollectTonesResult(tones?.ToList());
        }

        /// <summary> Initializes a new instance of DtmfResult. </summary>
        /// <param name="tones"></param>
        /// <returns> A new <see cref="CallAutomation.DtmfResult"/> instance for mocking. </returns>
        public static DtmfResult DtmfResult(IEnumerable<DtmfTone> tones = null)
        {
            tones ??= new List<DtmfTone>();

            return new DtmfResult(tones?.ToList());
        }

        /// <summary> Initializes a new instance of ChoiceResult. </summary>
        /// <param name="label"> Label is the primary identifier for the choice detected. </param>
        /// <param name="recognizedPhrase">
        /// Phrases are set to the value if choice is selected via phrase detection.
        /// If Dtmf input is recognized, then Label will be the identifier for the choice detected and phrases will be set to null
        /// </param>
        /// <returns> A new <see cref="CallAutomation.ChoiceResult"/> instance for mocking. </returns>
        public static ChoiceResult ChoiceResult(string label = null, string recognizedPhrase = null)
        {
            return new ChoiceResult(label, recognizedPhrase);
        }

        /// <summary> Initializes a new instance of SpeechResult. </summary>
        /// <param name="speech"> The recognized speech in string. </param>
        /// <returns> A new <see cref="CallAutomation.SpeechResult"/> instance for mocking. </returns>
        public static SpeechResult SpeechResult(string speech = null)
        {
            return new SpeechResult(speech);
        }

        /// <summary> Initializes a new instance of RecognizeFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeFailed"/> instance for mocking. </returns>
        public static RecognizeFailed RecognizeFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new RecognizeFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of RecognizeCanceled. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.RecognizeCanceled"/> instance for mocking. </returns>
        public static RecognizeCanceled RecognizeCanceled(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null)
        {
            return new RecognizeCanceled(callConnectionId, serverCallId, correlationId, operationContext);
        }

        /// <summary> Initializes a new instance of UserConsent. </summary>
        /// <param name="recording"></param>
        /// <returns> A new <see cref="CallAutomation.UserConsent"/> instance for mocking. </returns>
        public static UserConsent UserConsent(int? recording = null)
        {
            return new UserConsent(recording);
        }

        /// <summary> Initializes a new instance of SensitiveFlag. </summary>
        /// <param name="recording"></param>
        /// <returns> A new <see cref="CallAutomation.SensitiveFlag"/> instance for mocking. </returns>
        public static SensitiveFlag SensitiveFlag(int? recording = null)
        {
            return new SensitiveFlag(recording);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionToneFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionToneFailed"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionToneFailed ContinuousDtmfRecognitionToneFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, ResultInformation resultInformation = null, string operationContext = null)
        {
            return new ContinuousDtmfRecognitionToneFailed(callConnectionId, serverCallId, correlationId, resultInformation, operationContext);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionToneReceived. </summary>
        /// <param name="toneInfo"> Information about Tone. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId or skype chain ID. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionToneReceived"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionToneReceived ContinuousDtmfRecognitionToneReceived(ToneInfo toneInfo = null, string callConnectionId = null, string serverCallId = null, string correlationId = null, ResultInformation resultInformation = null, string operationContext = null)
        {
            return new ContinuousDtmfRecognitionToneReceived(toneInfo, callConnectionId, serverCallId, correlationId, resultInformation, operationContext);
        }

        /// <summary> Initializes a new instance of ToneInfo. </summary>
        /// <param name="sequenceId"> The sequence id which can be used to determine if the same tone was played multiple times or if any tones were missed. </param>
        /// <param name="tone"></param>
        /// <returns> A new <see cref="CallAutomation.ToneInfo"/> instance for mocking. </returns>
        public static ToneInfo ToneInfo(int sequenceId = default, DtmfTone tone = default)
        {
            return new ToneInfo(sequenceId, tone);
        }

        /// <summary> Initializes a new instance of ContinuousDtmfRecognitionStopped. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.ContinuousDtmfRecognitionStopped"/> instance for mocking. </returns>
        public static ContinuousDtmfRecognitionStopped ContinuousDtmfRecognitionStopped(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new ContinuousDtmfRecognitionStopped(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of SendDtmfCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfCompleted"/> instance for mocking. </returns>
        public static SendDtmfCompleted SendDtmfCompleted(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new SendDtmfCompleted(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Initializes a new instance of SendDtmfFailed. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        /// <returns> A new <see cref="CallAutomation.SendDtmfFailed"/> instance for mocking. </returns>
        public static SendDtmfFailed SendDtmfFailed(string callConnectionId = null, string serverCallId = null, string correlationId = null, string operationContext = null, ResultInformation resultInformation = null)
        {
            return new SendDtmfFailed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }
    }
}
