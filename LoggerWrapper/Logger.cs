using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoggerWrapper {
	public class Logger : ILogger {
		private readonly NLog.Logger logger;
		private readonly Rollbar.IRollbar rollbar;

		public Logger(NLog.Logger logger, Rollbar.IRollbar rollbar) {
			this.logger = logger;
			this.rollbar = rollbar;
		}
		public Logger(Rollbar.IRollbar rollbar) {
			this.logger = NLog.LogManager.GetCurrentClassLogger();
			this.rollbar = rollbar;
		}
		public Logger(NLog.Logger logger) {
			this.logger = logger;
			this.rollbar = Rollbar.RollbarLocator.RollbarInstance;
		}

		public Logger() {
			this.logger = NLog.LogManager.GetCurrentClassLogger();
			this.rollbar = Rollbar.RollbarLocator.RollbarInstance;
		}

		/// Debug level

		/// <summary>
		/// Writes the diagnostic message at the Debug level.
		/// </summary>
		public void Debug(string message) {
			logger.Debug(message);
#pragma warning disable 4014
			rollbar.Debug(message);
#pragma warning restore 4014
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Debug level.
		/// </summary>
		public void Debug(Exception exeption, string message) {
			logger.Debug(exeption, message);
			rollbar.Debug(exeption, new Dictionary<string, object> { { "message", message } });
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

				logger.Debug(exeption, message.ToString());
			}
			else {
				logger.Debug(exeption);
			}
			rollbar.Debug(exeption, custom);
		}


		/// Info level

		/// <summary>
		/// Writes the diagnostic message at the Info level.
		/// </summary>
		public void Info(string message) {
			logger.Info(message);
			rollbar.Info(message);
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Info level.
		/// </summary>
		public void Info(Exception exeption, string message) {
			logger.Info(exeption, message);
			rollbar.Info(exeption, new Dictionary<string, object> { { "message", message } });
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

				logger.Info(exeption, message.ToString());
			}
			else {
				logger.Info(exeption);
			}
			rollbar.Info(exeption, custom);
		}


		/// Error level

		/// <summary>
		/// Writes the diagnostic message at the Error level.
		/// </summary>
		public void Error(string message) {
			logger.Error(message);
			rollbar.Error(message);
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Error level.
		/// </summary>
		public void Error(Exception exeption, string message) {
			logger.Error(exeption, message);
			rollbar.Error(exeption, new Dictionary<string, object> { { "message", message } });
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

				logger.Error(exeption, message.ToString());
			}
			else {
				logger.Error(exeption);
			}
			rollbar.Error(exeption, custom);
		}


		/// Warn level

		/// <summary>
		/// Writes the diagnostic message at the Warn level.
		/// </summary>
		public void Warn(string message) {
			logger.Warn(message);
			rollbar.Warning(message);
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Warn level.
		/// </summary>
		public void Warn(Exception exeption, string message) {
			logger.Warn(exeption, message);
			rollbar.Warning(exeption, new Dictionary<string, object> { { "message", message } });
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

				logger.Warn(exeption, message.ToString());
			}
			else {
				logger.Warn(exeption);
			}
			rollbar.Warning(exeption, custom);
		}


		/// Fatal level

		/// <summary>
		/// Writes the diagnostic message at the Fatal level.
		/// </summary>
		public void Fatal(string message) {
			logger.Fatal(message);
			rollbar.Critical(message);
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the Fatal level.
		/// </summary>
		public void Fatal(Exception exeption, string message) {
			logger.Fatal(exeption, message);
			rollbar.Critical(exeption, new Dictionary<string, object> { { "message", message } });
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

				logger.Fatal(exeption, message.ToString());
			}
			else {
				logger.Fatal(exeption);
			}
			rollbar.Critical(exeption, custom);
		}

	}
}
