namespace TrAPI.Transfer.Sample
{
	using System;

	using TrAPI.Logging;
    using TrAPI.Logging.Factory;
    using TrAPI.Transfer;

	/// <summary>
	/// Represents a thread-safe class object to write debug, information, warning, and error logs using TrAPI Logging.
	/// </summary>
	/// <remarks>
	/// This is an alternative implementation of TrAPI Logging <see cref="ITransferLog"/> and can be used in client-side scenarios.
	/// </remarks>
	internal sealed class TrAPITransferLog : ITransferLog
	{
		/// <summary>
		/// The TrAPI log backing.
		/// </summary>
		private readonly ILog logger;

		/// <summary>
		/// The flag that dictates whether the logger should be disposed.
		/// </summary>
		private readonly bool disposeLogger;

		/// <summary>
		/// The disposed backing.
		/// </summary>
		private bool disposed;

		/// <summary>
		/// Initializes a new instance of the <see cref="TrAPITransferLog"/> class.
		/// </summary>
		public TrAPITransferLog()
		{
			if (Log.Logger == null)
			{
				this.logger = LogFactory.GetLogger(
					new LoggerOptions
					{
						System = "TrAPI",
						SubSystem = string.Empty,
						Application = GlobalSettings.Instance.ApplicationName,
						ConnectionString = string.Empty,
					});
				this.disposeLogger = true;
				this.IsEnabled = true;
			}
			else
			{
				this.logger = Log.Logger;
				this.disposeLogger = false;
				this.IsEnabled = this.logger.IsEnabled;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrAPITransferLog"/> class.
		/// </summary>
		/// <param name="log">
		/// The TrAPI log.
		/// </param>
		/// <param name="disposeLogger">
		/// Specify whether this instance should dispose the logger when the <see cref="Dispose()"/> method is called.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when <paramref name="log"/> is <see langword="null"/>.
		/// </exception>
		public TrAPITransferLog(ILog log, bool disposeLogger)
		{
			if (log == null)
			{
				throw new ArgumentNullException(nameof(log));
			}

			this.logger = log;
			this.disposeLogger = disposeLogger;
			this.IsEnabled = log.IsEnabled;
		}

		/// <inheritdoc />
		public bool IsEnabled
		{
			get;
			set;
		}

		/// <inheritdoc />
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc />
		public void LogInformation(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogInformation(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogInformation(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogInformation(exception, messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogDebug(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogDebug(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogDebug(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogDebug(exception, messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogWarning(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogWarning(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogWarning(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogWarning(exception, messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogError(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogError(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogError(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogError(exception, messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogVerbose(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogVerbose(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogVerbose(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogVerbose(exception, messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogFatal(string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogFatal(messageTemplate, propertyValues);
		}

		/// <inheritdoc />
		public void LogFatal(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			if (!this.IsEnabled)
			{
				return;
			}

			this.logger.LogFatal(exception, messageTemplate, propertyValues);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">
		/// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
		/// </param>
		private void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}

			if (disposing && this.disposeLogger)
			{
				var disposableLogger = this.logger as IDisposable;
				disposableLogger?.Dispose();
			}

			this.disposed = true;
		}
	}
}
