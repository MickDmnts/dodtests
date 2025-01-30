﻿using System.Diagnostics;

namespace DOD {
    class Program {
        public static Random Random = new Random();

        static void Main(string[] _args) {
            Program program = new Program();
            int qtt = 20_000_000;

            program.DoDTheBuilder(qtt);
        }

        void DoDTheBuilder(int _qtt) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BuildingBlock buildingBlock = new BuildingBlock(_qtt);

            List<int> rooms = new List<int>();
            List<int> doors = new List<int>();
            List<int> furnitures = new List<int>();

            for (int i = 0; i < _qtt; i++) {
                int buildingIdx = buildingBlock.BuildBuilding(i);

                for (int j = 0; j < buildingBlock.GetBuildings._BuildingCount; j++) {
                    rooms.Add(buildingBlock.RoomFlattenIndex(i, buildingBlock.BuildRoom(buildingIdx, 2)));
                    doors.Add(buildingBlock.DoorFlattenIndex(i, buildingBlock.BuildDoor(buildingIdx, 2, 2)));
                    furnitures.Add(buildingBlock.FurnituresFlattenIndex(i, buildingBlock.BuildFurnitures(buildingIdx, 2, 2)));
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Building Elapsed: " + stopwatch.Elapsed.ToString());

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < buildingBlock.GetBuildings._BuildingCount; i++) {
                //@TODO
            }

            /* for (int j = 0; j < rooms.Count; j++) {
                buildingBlock.GetRoomArea(rooms[j]);
            }

            for (int j = 0; j < doors.Count; j++) {
                buildingBlock.GetDoorWidth(doors[j]);
                buildingBlock.GetDoorHeight(doors[j]);
            }

            for (int j = 0; j < furnitures.Count; j++) {
                buildingBlock.GetTables(furnitures[j]);
                buildingBlock.GetChairs(furnitures[j]);
            } */

            stopwatch.Stop();
            Console.WriteLine("Building Reading: " + stopwatch.Elapsed.ToString());

            /* int idx = buildingBlock.BuildBuilding(0);
            int roomIdx = buildingBlock.BuildRoom(idx, 37);
            int doorIdx = buildingBlock.BuildDoor(idx, 1, 2);
            int furnIdx = buildingBlock.BuildFurnitures(idx, 2, 5);

            Console.WriteLine($"Idx: {idx} Room: {roomIdx} Door: {doorIdx} Furn: {furnIdx}");

            int flattenIdx = buildingBlock.BuildingFlattenIndex(0, idx);
            Console.WriteLine($"Flatten: {flattenIdx}");

            int flattenRoomIdx = buildingBlock.RoomFlattenIndex(idx, roomIdx);
            Console.WriteLine($"Flatten Room: {flattenRoomIdx}");

            int roomArea = buildingBlock.GetRoomArea(flattenRoomIdx);
            Console.WriteLine($"Room Area: {roomArea}");

            int furnitureRoomIdx = buildingBlock.FurnituresFlattenIndex(idx, furnIdx);
            int tableIdx = buildingBlock.GetTables(furnitureRoomIdx);
            int chairIdx = buildingBlock.GetChairs(furnitureRoomIdx);
            Console.WriteLine($"Furn: {furnitureRoomIdx} Table: {tableIdx} Chair: {chairIdx}");

            int doorRoomIdx = buildingBlock.DoorFlattenIndex(idx, doorIdx);
            int doorWidth = buildingBlock.GetDoorWidth(doorRoomIdx);
            int doorHeight = buildingBlock.GetDoorHeight(doorRoomIdx);
            Console.WriteLine($"Door: {doorRoomIdx} Width: {doorWidth} Height: {doorHeight}"); */

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

    public struct Building {
        public Room[] _Rooms;
    }

    public struct Room {
        public int _Area;
        public Door[] _Doors;
        public Furniture[] _Furnitures;
    }

    public struct Door {
        public int _Width;
        public int _Height;
    }

    public struct Furniture {
        public int _Chairs;
        public int _Tables;
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

            public Buildings(int _blocks, int _buildings = 4, int _rooms = 4, int _doors = 8, int _furnitures = 10) {
                this._BlockMemoryAlloc = _blocks;
                this._BuildingMemoryAlloc = this._BlockMemoryAlloc * _buildings;

                this._BuildingCount = _buildings;
                this._RoomsCount = _rooms;
                this._DoorsCount = _doors;
                this._FurnituresCount = _furnitures;

                _RoomAreas = new int[_BuildingMemoryAlloc * _rooms];
                for (int i = 0; i < _RoomAreas.Length; i++) {
                    _RoomAreas[i] = -1;
                }

                _DoorWidths = new int[_BuildingMemoryAlloc * _doors];
                _DoorHeights = new int[_BuildingMemoryAlloc * _doors];
                for (int i = 0; i < _DoorWidths.Length; i++) {
                    _DoorWidths[i] = -1;
                    _DoorHeights[i] = -1;
                }

                _Chairs = new int[_BuildingMemoryAlloc * _furnitures];
                _Tables = new int[_BuildingMemoryAlloc * _furnitures];
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

        #region Building API
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
        #endregion

        #region Flatten Accessing API
        public int BuildingFlattenIndex(int _blockIdx, int _buildingIdx) {
            _blockIdx = Math.Clamp(_blockIdx, 0, _Buildings._BlockMemoryAlloc - 1);
            _buildingIdx = Math.Clamp(_buildingIdx, 0, _Buildings._BuildingCount - 1);

            return Program.FlattenIndex(_blockIdx, _buildingIdx, _Buildings._BuildingCount);
        }

        public int RoomFlattenIndex(int _buildingIdx, int _roomIdx) {
            _roomIdx = Math.Clamp(_roomIdx, 0, _Buildings._RoomsCount - 1);

            return Program.FlattenIndex(_buildingIdx, _roomIdx, _Buildings._RoomsCount);
        }

        public int FurnituresFlattenIndex(int _buildingIdx, int _furnitureIdx) {
            _furnitureIdx = Math.Clamp(_furnitureIdx, 0, _Buildings._FurnituresCount - 1);

            return Program.FlattenIndex(_buildingIdx, _furnitureIdx, _Buildings._FurnituresCount);
        }

        public int DoorFlattenIndex(int _buildingIdx, int _doorIdx) {
            _doorIdx = Math.Clamp(_doorIdx, 0, _Buildings._DoorsCount - 1);

            return Program.FlattenIndex(_buildingIdx, _doorIdx, _Buildings._DoorsCount);
        }
        #endregion

        #region Actual Value Accessing API
        public int GetRoomArea(int _flattenRoomIdx) {
            return _Buildings._RoomAreas[_flattenRoomIdx];
        }

        public int GetChairs(int _flattenFurnitureIdx) {
            return _Buildings._Chairs[_flattenFurnitureIdx];
        }

        public int GetTables(int _flattenFurnitureIdx) {
            return _Buildings._Tables[_flattenFurnitureIdx];
        }

        public int GetDoorWidth(int _flattenDoorIdx) {
            return _Buildings._DoorWidths[_flattenDoorIdx];
        }

        public int GetDoorHeight(int _flattenDoorIdx) {
            return _Buildings._DoorHeights[_flattenDoorIdx];
        }
        #endregion
    }
}
