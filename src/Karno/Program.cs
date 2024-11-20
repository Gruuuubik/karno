using Copto;
using System;

namespace Karno
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var opts = Options.Parse(args);

			bool run_benchmark = false;
			opts.Apply(new RuleSet()
			{
				{"benchmark", (b) => run_benchmark = b ?? true }
			});

			if (run_benchmark)
			{
				int number_of_variables = 4;
				int number_of_tests = 10;
				int seed = 42; // The answer to life, the universe and everything.
				bool test_minimization_result = true;

				opts.Apply(new RuleSet()
				{
					{ "vars", (v) => number_of_variables = v.Value },
					{ "tests", (t) => number_of_tests = t.Value },
					{ "reseed", () => seed = (int)DateTime.Now.Ticks },
					{ "test-minimization", (v) => test_minimization_result = v ?? true }
				});

				var benchmark = new KMapBenchmark(seed, number_of_variables, number_of_tests);
				benchmark.Run(true, test_minimization_result);
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}
