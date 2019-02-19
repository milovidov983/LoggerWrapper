using System;

namespace ConsoleApp1 {
	class Program {
		static void Main(string[] args) {
			var logger = Settings.Logger;

			logger.Debug("Hello!");

			Console.Read();
		}
	}
}
