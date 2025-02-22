public class Test {
    static Dictionary<string, int> _Test = new Dictionary<string, int>();

    public static void Populate(string[] _samples) {
        for (int i = 0; i < _samples.Length; i++) {
            _Test.Add(_samples[i], i);
        }
    }

    public static int TestIf(string _key) {
        if (_key == "a") { return 1; }
        if (_key == "b") { return 2; }
        if (_key == "c") { return 3; }
        if (_key == "d") { return 4; }
        if (_key == "e") { return 5; }
        if (_key == "f") { return 6; }
        if (_key == "g") { return 7; }
        if (_key == "h") { return 8; }
        if (_key == "i") { return 9; }
        if (_key == "j") { return 10; }
        if (_key == "k") { return 11; }
        if (_key == "l") { return 12; }
        if (_key == "m") { return 13; }
        if (_key == "n") { return 14; }
        if (_key == "o") { return 15; }
        if (_key == "p") { return 16; }
        if (_key == "q") { return 17; }
        if (_key == "r") { return 18; }
        if (_key == "s") { return 19; }
        if (_key == "t") { return 20; }
        if (_key == "u") { return 21; }
        if (_key == "v") { return 22; }
        if (_key == "w") { return 23; }
        if (_key == "x") { return 24; }
        if (_key == "y") { return 25; }
        if (_key == "z") { return 26; }

        return -1;
    }

    public static int TestSwitch(string _key) {
        switch (_key) {
            case "a": return 1;
            case "b": return 2;
            case "c": return 3;
            case "d": return 4;
            case "e": return 5;
            case "f": return 6;
            case "g": return 7;
            case "h": return 8;
            case "i": return 9;
            case "j": return 10;
            case "k": return 11;
            case "l": return 12;
            case "m": return 13;
            case "n": return 14;
            case "o": return 15;
            case "p": return 16;
            case "q": return 17;
            case "r": return 18;
            case "s": return 19;
            case "t": return 20;
            case "u": return 21;
            case "v": return 22;
            case "w": return 23;
            case "x": return 24;
            case "y": return 25;
            case "z": return 26;
        }

        return -1;
    }

    public static int UnsafeTestDictionary(string _key) {
        return _Test[_key];
    }

    public static int TestDictionary(string _key) {
        if (_Test.ContainsKey(_key)) {
            return _Test[_key];
        }

        return -1;
    }
}
