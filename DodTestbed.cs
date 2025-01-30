using System.Diagnostics;

namespace DOD {
    class Program {
        //public static Random Random = new Random();

        static void Main(string[] _args) {
            BuildingSquare buildingSquare = new BuildingSquare(100_000_000, 5);

            Dod dod = new Dod(buildingSquare);

            Building building = new Building(buildingSquare._RoomLimit, 10);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < buildingSquare._BuildingLimit; i++) {
                dod.Build(building);
            }
            sw.Stop();
            Console.WriteLine("Building: " + sw.Elapsed);
        }

    }
}
