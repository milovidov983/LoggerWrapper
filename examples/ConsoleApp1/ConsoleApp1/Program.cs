using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApp1 {
	class Program {


		public class VisualCheckInfo {
			private Dictionary<VisualCheck, bool?> _visualChecks;

			public Dictionary<VisualCheck, bool?> VisualChecks {
				get {
					return _visualChecks;
				}
				set {
					if(value == null || value.Count < 1) {
						return;
					}

					foreach(var newdata in value) {
						if (_visualChecks.ContainsKey(newdata.Key)) {
							_visualChecks[newdata.Key] = newdata.Value;
						}
					}

				}

			}

			public VisualCheckInfo() {
				_visualChecks = new Dictionary<VisualCheck, bool?> {
					{ VisualCheck.DirtyСlothesРairAndSkin, null },
					{ VisualCheck.EscortByUnauthorizedPersons, null },
					{ VisualCheck.HighExcitementNervousnessAndAnxiety, null },
					{ VisualCheck.IgnoranceOfPersonalData, null }
				};
			}


		}




		static void Main(string[] args) {


			var v = new VisualCheckInfo();


			var newData1 = new Dictionary<VisualCheck, bool?>() {
				{ VisualCheck.DirtyСlothesРairAndSkin, false }
			};
			var a = Enum.GetValues(typeof(VisualCheck)).Cast<VisualCheck>();

			var newData2 = new Dictionary<VisualCheck, bool?>() {
				{ VisualCheck.DirtyСlothesРairAndSkin, false },
				{ (VisualCheck)33, false }
			};

			v.VisualChecks = newData2;

			Console.Read();
		}



















		[Description("Визуальная проверка клиента")]
		public enum VisualCheck {
			[Description("Грязная одежда, волосы и кожа")]
			DirtyСlothesРairAndSkin = 1,
			[Description("Неприятный резкий запах")]
			UnpleasantPungentSmell = 2,
			[Description("Сильный запах алкоголя")]
			StrongSmellOfAlcohol = 3,
			[Description("Суженные или расширенные зрачки глаз")]
			NarrowedOrDilatedPupilsOfTheEyes = 4,
			[Description("Тюремные наколки")]
			PrisonTattoos = 5,
			[Description("Множественные порезы и ожоги на коже")]
			MultipleCutsAndBurnsOnTheSkin = 6,
			[Description("Заторможенная и замедленная речь")]
			SlowAndSlowSpeech = 7,
			[Description("Нарушенная координация движения")]
			ImpairedMovementCoordination = 8,
			[Description("Высокая возбужденность, нервозность и обеспокоенность")]
			HighExcitementNervousnessAndAnxiety = 9,
			[Description("Незнание анкетных данных")]
			IgnoranceOfPersonalData = 10,
			[Description("Сопровождение посторонними лицами")]
			EscortByUnauthorizedPersons = 11,

		}
	}
}
