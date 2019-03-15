namespace LoggerWrapper {
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;

	public class LoggerImpl : ILogger {
		private readonly NLog.Logger nlog;
		private readonly Rollbar.IRollbar rollbar;

		public LoggerImpl(NLog.Logger logger, Rollbar.IRollbar rollbar) {
			this.nlog = logger ?? throw new ArgumentNullException("The NLog cannot be null.");
			this.rollbar = rollbar ?? throw new ArgumentNullException("The Rollbar cannot be null.");
		}
		public LoggerImpl(Rollbar.IRollbar rollbar) {
			this.nlog = NLog.LogManager.GetCurrentClassLogger();
			this.rollbar = rollbar ?? throw new ArgumentNullException("The Rollbar cannot be null.");
		}
		public LoggerImpl(NLog.Logger logger) {
			this.nlog = logger ?? throw new ArgumentNullException("The NLog cannot be null.");
			this.rollbar = Rollbar.RollbarLocator.RollbarInstance;
		}

		public LoggerImpl() {
			this.nlog = NLog.LogManager.GetCurrentClassLogger();
			this.rollbar = Rollbar.RollbarLocator.RollbarInstance;
		}

		/// Debug level

		/// <summary>
		/// Writes the diagnostic message at the Debug level.
		/// </summary>
		public void Debug(string message) {
			nlog.Debug(message);
#pragma warning disable 4014
			rollbar.Debug(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Debug level.
		/// </summary>
		public void Debug(Exception exeption, string message) {
			nlog.Debug(exeption, message);
#pragma warning disable 4014
			rollbar.Debug(exeption, new Dictionary<string, object> { { "message", message } });
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic custom objects and exception at the Debug level.
		/// </summary>
		public void Debug(Exception exeption, IDictionary<string, object> custom = null) {
			if (custom != null && custom.Count != 0) {
				var message = new System.Text.StringBuilder();

				foreach (var item in custom) {
					message.Append($"custom.{item.Key}:{JsonConvert.SerializeObject(item.Value)}{Environment.NewLine}");
				}

				nlog.Debug(exeption, message.ToString());
			}
			else {
				nlog.Debug(exeption);
			}
#pragma warning disable 4014
			rollbar.Debug(exeption, custom);
#pragma warning restore 4014
		}


		/// Info level

		/// <summary>
		/// Writes the diagnostic message at the Info level.
		/// </summary>
		public void Info(string message) {
			nlog.Info(message);
#pragma warning disable 4014
			rollbar.Info(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Info level.
		/// </summary>
		public void Info(Exception exeption, string message) {
			nlog.Info(exeption, message);
#pragma warning disable 4014
			rollbar.Info(exeption, new Dictionary<string, object> { { "message", message } });
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic custom objects and exception at the Info level.
		/// </summary>
		public void Info(Exception exeption, IDictionary<string, object> custom = null) {
			if (custom != null && custom.Count != 0) {
				var message = new System.Text.StringBuilder();

				foreach (var item in custom) {
					message.Append($"custom.{item.Key}:{JsonConvert.SerializeObject(item.Value)}{Environment.NewLine}");
				}

				nlog.Info(exeption, message.ToString());
			}
			else {
				nlog.Info(exeption);
			}
#pragma warning disable 4014
			rollbar.Info(exeption, custom);
#pragma warning restore 4014
		}


		/// Error level

		/// <summary>
		/// Writes the diagnostic message at the Error level.
		/// </summary>
		public void Error(string message) {
			nlog.Error(message);
#pragma warning disable 4014
			rollbar.Error(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Error level.
		/// </summary>
		public void Error(Exception exeption, string message) {
			nlog.Error(exeption, message);
#pragma warning disable 4014
			rollbar.Error(exeption, new Dictionary<string, object> { { "message", message } });
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic custom objects and exception at the Error level.
		/// </summary>
		public void Error(Exception exeption, IDictionary<string, object> custom = null) {
			if (custom != null && custom.Count != 0) {
				var message = new System.Text.StringBuilder();

				foreach (var item in custom) {
					message.Append($"custom.{item.Key}:{JsonConvert.SerializeObject(item.Value)}{Environment.NewLine}");
				}

				nlog.Error(exeption, message.ToString());
			}
			else {
				nlog.Error(exeption);
			}
#pragma warning disable 4014
			rollbar.Error(exeption, custom);
#pragma warning restore 4014
		}


		/// Warn level

		/// <summary>
		/// Writes the diagnostic message at the Warn level.
		/// </summary>
		public void Warn(string message) {
			nlog.Warn(message);
#pragma warning disable 4014
			rollbar.Warning(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Warn level.
		/// </summary>
		public void Warn(Exception exeption, string message) {
			nlog.Warn(exeption, message);
#pragma warning disable 4014
			rollbar.Warning(exeption, new Dictionary<string, object> { { "message", message } });
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic custom objects and exception at the Warn level.
		/// </summary>
		public void Warn(Exception exeption, IDictionary<string, object> custom = null) {
			if (custom != null && custom.Count != 0) {
				var message = new System.Text.StringBuilder();

				foreach (var item in custom) {
					message.Append($"custom.{item.Key}:{JsonConvert.SerializeObject(item.Value)}{Environment.NewLine}");
				}

				nlog.Warn(exeption, message.ToString());
			}
			else {
				nlog.Warn(exeption);
			}
#pragma warning disable 4014
			rollbar.Warning(exeption, custom);
#pragma warning restore 4014
		}


		/// Fatal level

		/// <summary>
		/// Writes the diagnostic message at the Fatal level.
		/// </summary>
		public void Fatal(string message) {
			nlog.Fatal(message);
#pragma warning disable 4014
			rollbar.Critical(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Fatal level.
		/// </summary>
		public void Fatal(Exception exeption, string message) {
			nlog.Fatal(exeption, message);
#pragma warning disable 4014
			rollbar.Critical(exeption, new Dictionary<string, object> { { "message", message } });
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic custom objects and exception at the Fatal level.
		/// </summary>
		public void Fatal(Exception exeption, IDictionary<string, object> custom = null) {
			if (custom != null && custom.Count != 0) {
				var message = new System.Text.StringBuilder();

				foreach (var item in custom) {
					message.Append($"custom.{item.Key}:{JsonConvert.SerializeObject(item.Value)}{Environment.NewLine}");
				}

				nlog.Fatal(exeption, message.ToString());
			}
			else {
				nlog.Fatal(exeption);
			}
#pragma warning disable 4014
			rollbar.Critical(exeption, custom);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes trace log.
		/// Attention! Since the rollbar does not support the trace log level, 
		/// therefore we write to the info level and insert the prefix [tarce] before the your message.
		/// </summary>
		public void Trace(string message) {
			nlog.Trace(message);
			var sb = new System.Text.StringBuilder();
			sb.Append("[trace] ").Append(message);
#pragma warning disable 4014
			rollbar.Info(sb.ToString());
#pragma warning restore 4014
		}
	}
}
