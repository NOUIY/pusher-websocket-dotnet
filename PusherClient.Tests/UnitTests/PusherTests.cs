﻿using System;
using NUnit.Framework;

namespace PusherClient.Tests.UnitTests
{
    [TestFixture]
    public class PusherTests
    {
        [Test]
        public void PusherShouldThrowAnExceptionWhenInitialisedWithANullApplicationKey()
        {
            // Arrange
            var stubOptions = new PusherOptions();

            ArgumentException caughtException = null;

            // Act
            try
            {
                new Pusher(null, stubOptions);
            }
            catch (ArgumentException ex)
            {
                caughtException = ex;
            }

            // Assert
            Assert.IsNotNull(caughtException);
            StringAssert.Contains("The application key cannot be null or whitespace", caughtException.Message);
        }

        [Test]
        public void PusherShouldThrowAnExceptionWhenInitialisedWithAnEmptyApplicationKey()
        {
            // Arrange
            var stubOptions = new PusherOptions();

            ArgumentException caughtException = null;

            // Act
            try
            {
                new Pusher(string.Empty, stubOptions);
            }
            catch (ArgumentException ex)
            {
                caughtException = ex;
            }

            // Assert
            Assert.IsNotNull(caughtException);
            StringAssert.Contains("The application key cannot be null or whitespace", caughtException.Message);
        }

        [Test]
        public void PusherShouldThrowAnExceptionWhenInitialisedWithAWhitespaceApplicationKey()
        {
            // Arrange
            var stubOptions = new PusherOptions();

            ArgumentException caughtException = null;

            // Act
            try
            {
                new Pusher("  ", stubOptions);
            }
            catch (ArgumentException ex)
            {
                caughtException = ex;
            }

            // Assert
            Assert.IsNotNull(caughtException);
            StringAssert.Contains("The application key cannot be null or whitespace", caughtException.Message);
        }

        [Test]
        public void PusherShouldUseAPassedInPusherOptionsWhenSupplied()
        {
            // Arrange
            var mockOptions = new PusherOptions()
            {
                Cluster = "MyCluster"
            };

            // Act
            var pusher = new Pusher("FakeKey", mockOptions);

            //Assert
            Assert.AreEqual(mockOptions, pusher.Options);
        }

        [Test]
        public void PusherShouldCreateANewPusherOptionsWhenNoPusherOptionsAreSupplied()
        {
            // Arrange

            // Act
            var pusher = new Pusher("FakeKey");

            //Assert
            Assert.IsNotNull(pusher.Options);
        }
    }
}
