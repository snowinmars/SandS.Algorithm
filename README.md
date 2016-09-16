# SandS.Algorithm

SandS.Algorithm.Common - serving for other package.

Extensions:
  DateTime:
    bool IsFromPast();
    bool IsFromFuture();
  Enumerable:
    IEnumerable<T> Shuffle<T>(Random rng);
    bool SequenceEqualWithoutOrder<T>(IEnumerable<T> sequence);
  GraphicsDevice:
    Texture2D Generate(int width, int height, Color color); - generate texture in runtime
    Texture2D Generate(int width, int height, Color color, int borderThick, Color borderColor);
  IComparable<T>:
    bool Between<T>(T bound1, T bound2);
    T CantBeMore<T>(T cutoff); - if this if more that cutoff, return cutoff, otherwise return this
    T CantBeLess<T>(T cutoff); - if this if less that cutoff, return cutoff, otherwise return this
  IList:
    void FillWithRandomElements<T>(T min, T max, int capacity, Func<T, T, T> funcToGetNewRandomElement);
    void Show<T>(); - print to console. I know, that it's bad, but I need it too often.
  StringBuilder:
    void Trim(bool saveFirstSpace, bool saveLastSpace);
  String:
    string FirstLetterToUpper();
    bool IsComprisesOnlyLatinOrOnlyCyrillicSymbols(char[] canContains = null); - canContains is symbols, that string can contain besides latin or cyrillic.
    bool IsComprisesWithLetters();
    bool IsFramedWith(string symbol);
    bool IsStartWithUpper();
    
Library:
  BigNumbers: in progress
  Bitwise:
    ulong BitsToNumber(bool[] bits); - parse
    IEnumerable<bool> GetNextBit(ulong num); - parse positive number to bits.
    IEnumerable<bool> GetBitsReversed(ulong num); - same as previous, but bits are reading from other side.
    bool IsPowerOfTwo(ulong num);
    ulong NextPowerOfTwo(ulong v); - Compute next highest power of 2, e.g. for 114 it returns 128
    bool[] Add(bool[] lhs, bool[] rhs); - Returns new array as sum of two arrays without overflow
    bool[] UnaryMinus(bool[] array); - Make -(array) in twos-complement
    bool[] Invert(bool[] input); - Invert (0 -> 1 and 1 -> 0) all bits in input array
    bool[] Multiply(bool[] m, bool[] r); - Modifies result array as multiple of two input arrays without overflow. Method uses Booth's multiplication algorithm
    bool[] ArithmeticRightShift(bool[] arr, int shift); - Right shift without overflow
    bool[] Subtract(bool[] lhs, bool[] rhs); - Returns new array as difference of two arrays without overflow
  Generator:
    Labyrinth: code example will be soon
    ISBN10: code example will be soon
    ISSN: code example will be soon
    Prime: code example will be soon
    Text: code example will be soon
  Graph: code example will be soon
  Other:
    Enums:
      InputKeyPressType: OnUp/OnDown
      MouseButton: Left/Middle/Right
      Commands: Wait/MoveUp/MoveDown/MoveLeft/MoveRight
      Direction: Wait/Up/Down/Left/Right
    KeyboardInputHelper: I wrote some wrap over KeyboardState, and after it I saw wrapper like this in Transistor game. SO this is collective code. code example will be soon
    Position: class like Point or Vector2 in XNA, but you can change coords.
      <source lang="C#">
      Point p = new Point();
      p.X = 2; // doesn't work
      Position pos = new Position();
      pos.X = 2; // work
      </source>
    Sort: some sorting algorithms. Just practice, but may be usefull,
    Search: same as Sort.
    FastObjectAllocator: see more at youtube.com/watch?v=BNVP9FJXY6A
