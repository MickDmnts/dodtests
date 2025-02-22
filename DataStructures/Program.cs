using System.Diagnostics;

public class Program {
    const int TIMES = 1_000_000_000;

    static void Main(string[] args) {
        //string[] samples = Dump.MemoryGarbage(20, 100);
        string[] samples = Dump.MemoryGarbage(26);

        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < samples.Length; i++) {
            Console.WriteLine(samples[i]);
        }

        Test.Populate(samples);
        Stopwatch stopwatch = new Stopwatch();

        //If
        Console.WriteLine("If start");
        stopwatch.Start();
        for (int i = 0; i < TIMES; i++) {
            string key = samples[i % samples.Length];
            //int result = Test.TestIf("e");
            int result = Test.TestIf(key);
        }
        stopwatch.Stop();
        Console.WriteLine($"If end - Elapsed: {stopwatch.Elapsed.TotalSeconds}");
        //Switch
        Console.WriteLine("Switch start");
        stopwatch.Reset();
        stopwatch.Start();
        for (int i = 0; i < TIMES; i++) {
            string key = samples[i % samples.Length];
            int result = Test.TestSwitch(key);
            //int result = Test.TestSwitch("e");
        }
        stopwatch.Stop();
        Console.WriteLine($"Switch end - Elapsed: {stopwatch.Elapsed.TotalSeconds}");
        //Safe dic
        Console.WriteLine("Safe dic start");
        stopwatch.Reset();
        stopwatch.Start();
        for (int i = 0; i < TIMES; i++) {
            string key = samples[i % samples.Length];
            int result = Test.TestDictionary(key);
        }
        stopwatch.Stop();
        Console.WriteLine($"Safe dic end - Elapsed: {stopwatch.Elapsed.TotalSeconds}");
        //Unsafe dic
        Console.WriteLine("Unsafe dic start");
        stopwatch.Reset();
        stopwatch.Start();
        for (int i = 0; i < TIMES; i++) {
            string key = samples[i % samples.Length];
            int result = Test.UnsafeTestDictionary(key);
        }
        stopwatch.Stop();
        Console.WriteLine($"Unsafe dic end - Elapsed: {stopwatch.Elapsed.TotalSeconds}");
    }
}

