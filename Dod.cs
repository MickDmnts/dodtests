
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
}
