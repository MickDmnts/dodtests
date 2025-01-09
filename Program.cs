using System;
using System.Diagnostics;

namespace DOD {
    class Program {
        public static Random _Random = new Random();

        static void Main(string[] args) {
            Program program = new Program();
            int qtt = 1_000_000;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            program.DoDTheBuilder(qtt);
            stopwatch.Stop();



            Console.WriteLine("DOD Elapsed: " + stopwatch.Elapsed.ToString());
        }

        void DoDTheBuilder(int _qtt) {
            BuildingBlock buildingBlock = new BuildingBlock(_qtt);

            for (int i = 0; i < _qtt; i++) {
                int buildingIdx = buildingBlock.BuildBuilding(i);

                for (int j = 0; j < buildingBlock.GetBuildings._BuildingCount; j++) {
                    buildingBlock.BuildRoom(buildingIdx, 2);
                    buildingBlock.BuildDoor(buildingIdx, 2, 2);
                    buildingBlock.BuildFurnitures(buildingIdx, 2, 2);
                }
            }
        }

        /// <summary>
        /// Converts the indexes of a two dimensional value into an one dimension flatten index.
        /// </summary>
        public static int FlattenIndex(int _x, int _y, int _yLength) {
            return _y + _yLength * _x;
        }

        /// <summary>
        /// Converts the indexes of a three dimensional value into an one dimension flatten index.
        /// </summary>
        public static int FlattenIndex(int _x, int _y, int _z, int _yLength, int _zLength) {
            return _z + _zLength * FlattenIndex(_x, _y, _yLength);
        }
    }

    class BuildingBlock {
        public struct Buildings {
            public int[] _RoomAreas;
            public int[] _Chairs;
            public int[] _Tables;
            public int[] _DoorWidths;
            public int[] _DoorHeights;

            public int _BlockMemoryAlloc;
            public int _BuildingMemoryAlloc;

            public int _BuildingCount;
            public int _RoomsCount;
            public int _DoorsCount;
            public int _FurnituresCount;

            public Buildings(int _blocks, int _buildings = 4, int rooms = 4, int doors = 8, int furnitures = 10) {
                this._BlockMemoryAlloc = _blocks;
                this._BuildingMemoryAlloc = this._BlockMemoryAlloc * _buildings;

                this._BuildingCount = _buildings;
                this._RoomsCount = rooms;
                this._DoorsCount = doors;
                this._FurnituresCount = furnitures;

                _RoomAreas = new int[_BuildingMemoryAlloc * rooms];
                for (int i = 0; i < _RoomAreas.Length; i++) {
                    _RoomAreas[i] = -1;
                }

                _DoorWidths = new int[_BuildingMemoryAlloc * doors];
                _DoorHeights = new int[_BuildingMemoryAlloc * doors];
                for (int i = 0; i < _DoorWidths.Length; i++) {
                    _DoorWidths[i] = -1;
                    _DoorHeights[i] = -1;
                }

                _Chairs = new int[_BuildingMemoryAlloc * furnitures];
                _Tables = new int[_BuildingMemoryAlloc * furnitures];
                for (int i = 0; i < _Chairs.Length; i++) {
                    _Chairs[i] = -1;
                    _Tables[i] = -1;
                }
            }
        }

        Buildings _Buildings;
        int _BuildingLength;
        int _RoomsLength;
        int _DoorLength;
        int _FurnitureLength;

        public Buildings GetBuildings => _Buildings;

        public BuildingBlock(int _blocks) {
            _Buildings = new Buildings(_blocks);
        }

        public int BuildBuilding(int _blockIdx) {
            _blockIdx = Math.Clamp(_blockIdx, 0, _Buildings._BlockMemoryAlloc - 1);

            int idx = Program.FlattenIndex(_blockIdx, _BuildingLength, _Buildings._BuildingCount);

            _BuildingLength++;
            _BuildingLength %= _Buildings._BuildingCount;

            return idx;
        }

        public int BuildRoom(int _buildingIdx, int _roomArea) {
            int idx = Program.FlattenIndex(_buildingIdx, _RoomsLength, _Buildings._RoomsCount);
            _Buildings._RoomAreas[idx] = _roomArea;

            _RoomsLength++;
            _RoomsLength %= _Buildings._RoomsCount;

            return idx;
        }

        public int BuildDoor(int _buildingIdx, int _doorHeight, int _doorWidth) {
            int idx = Program.FlattenIndex(_buildingIdx, _DoorLength, _Buildings._DoorsCount);
            _Buildings._DoorHeights[idx] = _doorHeight;
            _Buildings._DoorWidths[idx] = _doorWidth;

            _DoorLength++;
            _DoorLength %= _Buildings._DoorsCount;

            return idx;
        }

        public int BuildFurnitures(int _buildingIdx, int _chairs, int _tables) {
            int idx = Program.FlattenIndex(_buildingIdx, _FurnitureLength, _Buildings._FurnituresCount);
            _Buildings._Chairs[idx] = _chairs;
            _Buildings._Tables[idx] = _tables;

            _FurnitureLength++;
            _FurnitureLength %= _Buildings._FurnituresCount;

            return idx;
        }
    }
}
