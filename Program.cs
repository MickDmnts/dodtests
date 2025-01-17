using System.Diagnostics;

namespace DOD {

    class Program {
        static void Main(string[] _args) {
            Program program = new Program();

            int gtt = 20000000;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            program.Test(gtt);
            stopwatch.Stop();
            Console.WriteLine("DOD Elapsed: " + stopwatch.Elapsed.ToString() + ", " + gtt);
        }

        void Test(int _qtt) {

            for (int i = 0; i < _qtt; i++) {
                BuildingBlock bb = new BuildingBlock(_qtt);
            }
        }
    }

    // Furniture class
    class Furniture {
        int _Idx;
        public Furniture(int _idx) {
            this._Idx = _idx;
        }

    }

    // House class
    class House {
        int _Idx;
        public House(int _idx) {
            this._Idx = _idx;
        }
    }

    // Building class
    class Building {
        int _Idx;
        public Building(int _idx) {
            this._Idx = _idx;
        }
    }

    class Room {
        int _Idx;
        public Room(int _idx) {
            this._Idx = _idx;
        }
    }

    // BuildingBlock class
    class BuildingBlock {
        int _Qtt;
        public BuildingBlock(int _qtt) {

            this._Qtt = _qtt;
            BuildBuilding();
            BuildHouse();
            BuildFurniture();
        }
        public void BuildBuilding() {
            for (int i = 0; i < 20; i++) {
                Building bl = new Building(i);
            }
        }

        public void BuildHouse() {
            for (int i = 0; i < 50; i++) {
                House house = new House(i);
            }
        }
        public void BuildRoom() {
            for (int i = 0; i < 50; i++) {
                Room rom = new Room(i);
            }
        }
        public void BuildFurniture() {
            for (int i = 0; i < 100; i++) {
                Furniture fur = new Furniture(i);
            }
        }


    }
}
