public static class Dump {
    public static string[] MemoryGarbage(int _wordSize, int _length) {
        string[] data = new string[_length];
        Random random = new Random();

        for (int i = 0; i < _length; i++) {
            string word = string.Empty;
            for (int j = 0; j < _wordSize; j++) {
                word += (char)(random.Next(25) + 'a');
            }

            data[i] = word;
        }

        return data;
    }

    public static string[] MemoryGarbage(string _word, int _length) {
        string[] data = new string[_length];

        for (int i = 0; i < _length; i++) {
            data[i] = _word;
        }

        return data;
    }

    public static string[] MemoryGarbage(int _length) {
        string[] data = new string[_length];

        for (int i = 0; i < _length; i++) {
            string word = string.Empty;
            word += (char)(i + 'a');
            data[i] = word;
        }

        return data;
    }
}

