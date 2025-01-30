public class BuildingSquare {
    public int[] _RoomAreas;

    public int _RoomLimit;

    public int[] _RoomCount;

    public int _BuildingLimit;

    public int _BuildingCount;

    public BuildingSquare(int _buildingLimit, int _roomLimit) {
        _RoomLimit = _roomLimit;
        _BuildingLimit = _buildingLimit;

        _RoomAreas = new int[_RoomLimit * _BuildingLimit];

        _RoomCount = new int[_BuildingLimit];
    }
}
