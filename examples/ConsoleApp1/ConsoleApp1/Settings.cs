using LoggerWrapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using RB = Rollbar;

namespace ConsoleApp1 {
	class Settings {
		public static Settings Instance { get; private set; }

		public static ILogger Logger { get; private set; }

		public RollbarSettings Rollbar { get; set; }
		public NlogSettings Nlog { get; set; }

		static Settings() {
			Instance = new Settings();

			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			var configuration = new ConfigurationBuilder()
				.AddJsonFile($"settings.{env}.json", true)
				.Build();

			configuration.Bind(Instance);

			InitLogger();
		}


		private static void InitLogger() {
			Logger = new LoggerImpl(InitNlog(), InitRollbar());
		}
	

		private static RB.IRollbar InitRollbar() {
			var cfg = Instance.Rollbar;
			var rollbarConfig = new RB.RollbarConfig(cfg.AccessToken) {
				AccessToken = cfg.AccessToken,
				Environment = cfg.Environment,
				Enabled = cfg.Enabled,
				MaxReportsPerMinute = cfg.MaxReportsPerMinute,
				ReportingQueueDepth = cfg.ReportingQueueDepth,
				ScrubFields = cfg.ScrubFields
			};
			RB.RollbarLocator.RollbarInstance.Configure(rollbarConfig);

			return RB.RollbarLocator.RollbarInstance;
		}

		private static NLog.Logger InitNlog() {
			var config = new NLog.Config.LoggingConfiguration();
			var consoleTarget = new NLog.Targets.ColoredConsoleTarget("consoleTarget") {
				Layout = @"${longdate} ${level} ${message} ${exception}"
			};
			config.AddTarget(consoleTarget);
			config.AddRule(NLog.LogLevel.FromString(Instance.Nlog.LogLevel), NLog.LogLevel.Fatal, consoleTarget);
			NLog.LogManager.Configuration = config;

			return NLog.LogManager.GetCurrentClassLogger();
		}

		public class NlogSettings {
			public string LogLevel { get; set; }
		}

		public class RollbarSettings {
			public string AccessToken { get; set; }
			public string Environment { get; set; }
			public bool? Enabled { get; set; }
			public string LogLevel { get; set; }
			public int MaxReportsPerMinute { get; set; }
			public int ReportingQueueDepth { get; set; }
			public string[] ScrubFields { get; set; }
		}
		
	}
}