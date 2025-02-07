
public class Dod {
    BuildingSquare _BuildingSquare;

    public Dod(BuildingSquare _buildingSquare) {
        _BuildingSquare = _buildingSquare;
    }

    public int Build(Building _building) {
        int index = _BuildingSquare._BuildingCount;
        int roomLimit = _BuildingSquare._RoomLimit;
        int roomCount = Math.Clamp(_building._Rooms.Length, 0, roomLimit);

        _BuildingSquare._RoomCount[index] = roomCount;

        for (int i = 0; i < roomCount; i++) {
            int roomAreaIndex = Flatten(index, i, roomLimit);

            _BuildingSquare._RoomAreas[roomAreaIndex] = _building._Rooms[i]._RoomArea;
        }
        _BuildingSquare._BuildingCount++;

        return index;

    }

    int Flatten(int _x, int _y, int _yLength) {
        return _y + (_x * _yLength);
    }

    public void Get(int _buildingIndex, Building _building) {
        int roomCount = _BuildingSquare._RoomCount[_buildingIndex];
        int i = 0;

        /*        while (i < roomCount) {
                    if (i < _BuildingSquare._RoomLimit && i >= roomCount) {
                        _building._Rooms[i]._RoomArea = 0;
                        i++;
                        continue;
                    }

                    int roomAreaIndex = Flatten(_buildingIndex, i, _BuildingSquare._RoomLimit);

                    _building._Rooms[i]._RoomArea = _BuildingSquare._RoomAreas[roomAreaIndex];

                    i++;
                }*/

        while (i < roomCount) {
            int roomAreaIndex = Flatten(_buildingIndex, i, _BuildingSquare._RoomLimit);

            _building._Rooms[i]._RoomArea = _BuildingSquare._RoomAreas[roomAreaIndex];

            i++;
        }

        while (i < _BuildingSquare._RoomLimit) {
            _building._Rooms[i]._RoomArea = 0;

            i++;
        }

    }
}
