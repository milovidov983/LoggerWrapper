namespace LoggerWrapper {
	using System;
	using System.Collections.Generic;

	public interface ILogger {
		/// <summary>
		/// Writes trace log.
		/// Attention! Since the rollbar does not support the trace log level, 
		/// therefore we write to the info level and insert the prefix [tarce] before the your message.
		/// </summary>
		void Trace(string message);

		void Info(string message);
		void Info(Exception exeption, string message);
		void Info(Exception exeption, IDictionary<string, object> custom = null);

		void Debug(string message);
		void Debug(Exception exeption, string message);
		void Debug(Exception exeption, IDictionary<string, object> custom = null);

		void Error(string message);
		void Error(Exception exeption, string message);
		void Error(Exception exeption, IDictionary<string, object> custom = null);

		void Warn(string message);
		void Warn(Exception exeption, string message);
		void Warn(Exception exeption, IDictionary<string, object> custom = null);

		void Fatal(string message);
		void Fatal(Exception exeption, string message);
		void Fatal(Exception exeption, IDictionary<string, object> custom = null);
	}
}


