public class Test {
    static Dictionary<string, int> _Test = new Dictionary<string, int>();

    public static void Populate(string[] _samples) {
        for (int i = 0; i < _samples.Length; i++) {
            _Test.Add(_samples[i], i);
        }
    }

    public static int TestIfIf(string _key) {
        if (_key == "cduquptfjc") { return 1; }
        if (_key == "mvhhtipiux") { return 2; }
        if (_key == "vxartnpdye") { return 3; }
        if (_key == "kqrglkzwys") { return 4; }
        if (_key == "kyupkxlnkx") { return 5; }
        if (_key == "qgqueygrqt") { return 6; }
        if (_key == "osnkjqyyss") { return 7; }
        if (_key == "wsdsoekubn") { return 8; }
        if (_key == "mrpxbdbokg") { return 9; }
        if (_key == "vlhbbgygpt") { return 10; }
        if (_key == "kvwfwqxdfb") { return 11; }
        if (_key == "jksgdtqgqd") { return 12; }
        if (_key == "ovokeqmhlf") { return 13; }
        if (_key == "rdmkhzgezd") { return 14; }
        if (_key == "thcdwljvnn") { return 15; }
        if (_key == "ulxsahdqew") { return 16; }
        if (_key == "rjenalvjmt") { return 17; }
        if (_key == "juhaxggzfv") { return 18; }
        if (_key == "ddfusqhxfu") { return 19; }
        if (_key == "nawviotkkr") { return 20; }
        if (_key == "arzudqslfy") { return 21; }
        if (_key == "fueztqovwm") { return 22; }
        if (_key == "zuawxdnsbj") { return 23; }
        if (_key == "evmxdbfqhy") { return 24; }
        if (_key == "ejebpoifkm") { return 25; }
        if (_key == "mjxkyxhljw") { return 26; }

        return -1;
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

    public static int TestSwitchSwitch(string _key) {
        switch (_key) {
            case "cduquptfjc": { return 1; }
            case "mvhhtipiux": { return 2; }
            case "vxartnpdye": { return 3; }
            case "kqrglkzwys": { return 4; }
            case "kyupkxlnkx": { return 5; }
            case "qgqueygrqt": { return 6; }
            case "osnkjqyyss": { return 7; }
            case "wsdsoekubn": { return 8; }
            case "mrpxbdbokg": { return 9; }
            case "vlhbbgygpt": { return 10; }
            case "kvwfwqxdfb": { return 11; }
            case "jksgdtqgqd": { return 12; }
            case "ovokeqmhlf": { return 13; }
            case "rdmkhzgezd": { return 14; }
            case "thcdwljvnn": { return 15; }
            case "ulxsahdqew": { return 16; }
            case "rjenalvjmt": { return 17; }
            case "juhaxggzfv": { return 18; }
            case "ddfusqhxfu": { return 19; }
            case "nawviotkkr": { return 20; }
            case "arzudqslfy": { return 21; }
            case "fueztqovwm": { return 22; }
            case "zuawxdnsbj": { return 23; }
            case "evmxdbfqhy": { return 24; }
            case "ejebpoifkm": { return 25; }
            case "mjxkyxhljw": { return 26; }
        }

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
