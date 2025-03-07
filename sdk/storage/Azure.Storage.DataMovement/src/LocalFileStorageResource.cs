﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    public class LocalFileStorageResource : StorageResourceSingle
    {
        private string _path;

        /// <summary>
        /// The identifier for the type of storage resource.
        /// </summary>
        protected internal override string ResourceId => "LocalFile";

        /// <summary>
        /// Returns URL
        /// </summary>
        public override Uri Uri => throw new NotSupportedException();

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public override string Path => _path;

        /// <summary>
        /// Defines whether the storage resource type can produce a web URL.
        /// </summary>
        protected internal override bool CanProduceUri => false;

        /// <summary>
        /// Defines the recommended Transfer Type of the resource
        /// </summary>
        protected internal override TransferType TransferType => TransferType.Sequential;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        /// TODO: consider changing this.
        protected internal override long MaxChunkSize => Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Length of the storage resource. This information is can obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        protected internal override long? Length => default;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            Argument.AssertNotNullOrWhiteSpace(path, nameof(path));
            _path = path;
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override Task<ReadStreamStorageResourceResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            stream.Position = position;
            return Task.FromResult(new ReadStreamStorageResourceResult(stream));
        }

        /// <summary>
        /// Creates the local file.
        /// </summary>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        internal Task CreateAsync(bool overwrite)
        {
            if (overwrite || !File.Exists(_path))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_path));
                File.Create(_path).Close();
                FileAttributes attributes = File.GetAttributes(_path);
                File.SetAttributes(_path, attributes | FileAttributes.Temporary);
                return Task.CompletedTask;
            }
            throw Errors.LocalFileAlreadyExists(_path);
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="streamLength">
        /// The length of the stream.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override async Task WriteFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long position = 0,
            long completeLength = 0,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (position == 0)
            {
                await CreateAsync(overwrite).ConfigureAwait(false);
            }
            if (completeLength > 0)
            {
                // Appends incoming stream to the local file resource
                using (FileStream fileStream = new FileStream(
                        _path,
                        FileMode.OpenOrCreate,
                        FileAccess.Write))
                {
                    if (position > 0)
                    {
                        fileStream.Seek(position, SeekOrigin.Begin);
                    }
                    await stream.CopyToAsync(
                        fileStream,
                        (int)streamLength,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override Task CopyFromUriAsync(
            StorageResourceSingle sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="range"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override Task CopyBlockFromUriAsync(
            StorageResourceSingle sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength = 0,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Local File Storage Resource. See <see cref="StorageResourceProperties"/></returns>
        protected internal override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            FileInfo fileInfo = new FileInfo(_path);
            if (fileInfo.Exists)
            {
                return Task.FromResult(fileInfo.ToStorageResourceProperties());
            }
            throw new FileNotFoundException();
        }

        /// <summary>
        /// Gets the Authorization Header for the storage resource if available.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Gets the HTTP Authorization header for the storage resource if available. If not available
        /// will return default.
        /// </returns>
        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Completes the transfer if the resource resides locally.
        ///
        /// If the transfer requires client-side encryption, necessary
        /// operations will occur here.
        /// </summary>
        protected internal override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            if (File.Exists(_path))
            {
                // Make file visible
                FileAttributes attributes = File.GetAttributes(_path);
                File.SetAttributes(_path, attributes | FileAttributes.Normal);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deletes the respective storage resource.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the storage resource exists and is deleted, true will be returned.
        /// Otherwise if the storage resource does not exist, false will be returned.
        /// </returns>
        protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static LocalFileStorageResource RehydrateResource(
            DataTransferProperties transferProperties,
            bool isSource)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            return new LocalFileStorageResource(storedPath);
        }
    }
}
