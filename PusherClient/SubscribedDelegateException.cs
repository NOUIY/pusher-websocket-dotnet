﻿using System;

namespace PusherClient
{
    /// <summary>
    /// An instance of this class gets passed to the Pusher Error delegate when the Subscribed delegate raises an unexpected exception.
    /// </summary>
    public class SubscribedDelegateException : PusherException
    {
        /// <summary>
        /// Creates a new instance of a <see cref="SubscribedDelegateException"/> class.
        /// </summary>
        /// <param name="channelName">The name of the channel for which the exception occured.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        /// <param name="data">The channel's message data.</param>
        public SubscribedDelegateException(string channelName, Exception innerException, string data)
            : base($"Error invoking the Pusher Subscribed delegate:{Environment.NewLine}{innerException.Message}", ErrorCodes.Unkown, innerException)
        {
            this.ChannelName = channelName;
            this.MessageData = data;
        }

        /// <summary>
        /// Gets the name of the channel for which the exception occured.
        /// </summary>
        public string ChannelName { get; private set; }

        /// <summary>
        /// Gets the channel's message data.
        /// </summary>
        public string MessageData { get; private set; }
    }
}
