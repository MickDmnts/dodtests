public class Building {
    public Room[] _Rooms;

    public Building(int _roomNumber, int _roomArea) {
        _Rooms = new Room[_roomNumber];
        for (int i = 0; i < _Rooms.Length; i++) {
            _Rooms[i] = new Room();
            _Rooms[i]._RoomArea = _roomArea;
        }
    }

    public int Area() {
        int sum = 0;

        foreach (Room rm in _Rooms) {
            sum += rm._RoomArea;
        }
        return sum;
    }

    public override string ToString() {
        return "Length: " + _Rooms.Length + " Area: " + Area();
    }
}
