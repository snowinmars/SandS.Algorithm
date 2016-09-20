# SandS.Algorithm
<ul>
<li>SandS.Algorithm.Common - serving for other package.</li>

<li>Extensions:
  <ul>
    <li>DateTime:
      <ul>
        <li>bool IsFromPast();</li>
        <li>bool IsFromFuture();</li>
      </ul>
    </li>
    <li>Enumerable:
      <ul>
        <li>IEnumerable<T> Shuffle<T>(Random rng);</li>
        <li>bool SequenceEqualWithoutOrder<T>(IEnumerable<T> sequence);</li>
      </ul>
    </li>
    <li>GraphicsDevice:
      <ul>
        <li>Texture2D Generate(int width, int height, Color color); - generate texture in runtime</li>
        <li>Texture2D Generate(int width, int height, Color color, int borderThick, Color borderColor);</li>
      </ul>
    </li>
    <li>IComparable<T>:
      <ul>
        <li>bool Between<T>(T bound1, T bound2);</li>
        <li>T CantBeMore<T>(T cutoff); - if this if more that cutoff, return cutoff, otherwise return this</li>
        <li>T CantBeLess<T>(T cutoff); - if this if less that cutoff, return cutoff, otherwise return this</li>
      </ul>
    </li>
    <li>IList:
      <ul>
        <li>void FillWithRandomElements<T>(T min, T max, int capacity, Func<T, T, T> funcToGetNewRandomElement);</li>
        <li>void Show<T>(); - print to console. I know, that it's bad, but I need it too often.</li>
      </ul>
    </li>
    <li>StringBuilder:
      <ul>
        <li>void Trim(bool saveFirstSpace, bool saveLastSpace);</li>
      </ul>
    </li>
    <li>String:
      <ul>
        <li>string FirstLetterToUpper();</li>
        <li>bool IsComprisesOnlyLatinOrOnlyCyrillicSymbols(char[] canContains = null); - canContains is symbols, that string can contain besides latin or cyrillic.</li>
        <li>bool IsComprisesWithLetters();</li>
        <li>bool IsFramedWith(string symbol);</li>
        <li>bool IsStartWithUpper();</li>
      </ul>
    </li>
  </ul>
</li>

<li>Library:
  <ul>
    <li>BigNumbers: in progress</li>
    <li>Bitwise:
      <ul>
        <li>ulong BitsToNumber(bool[] bits); - parse</li>
        <li>IEnumerable<bool> GetNextBit(ulong num); - parse positive number to bits.</li>
        <li>IEnumerable<bool> GetBitsReversed(ulong num); - same as previous, but bits are reading from other side.</li>
        <li>bool IsPowerOfTwo(ulong num);</li>
        <li>ulong NextPowerOfTwo(ulong v); - Compute next highest power of 2, e.g. for 114 it returns 128</li>
        <li>bool[] Add(bool[] lhs, bool[] rhs); - Returns new array as sum of two arrays without overflow</li>
        <li>bool[] UnaryMinus(bool[] array); - Make -(array) in twos-complement</li>
        <li>bool[] Invert(bool[] input); - Invert (0 -> 1 and 1 -> 0) all bits in input array</li>
        <li>bool[] Multiply(bool[] m, bool[] r); - Modifies result array as multiple of two input arrays without overflow. Method uses Booth's multiplication algorithm</li>
        <li>bool[] ArithmeticRightShift(bool[] arr, int shift); - Right shift without overflow</li>
        <li>bool[] Subtract(bool[] lhs, bool[] rhs); - Returns new array as difference of two arrays without overflow</li>
      </ul>
    </li>
    <li>Generator:
      <ul>
        <li>Labyrinth: code example will be soon</li>
        <li>ISBN10: code example will be soon</li>
        <li>ISSN: code example will be soon</li>
        <li>Prime: code example will be soon</li>
        <li>Text: code example will be soon</li>
      </ul>
    </li>
    <li>Graph: code example will be soon</li>
    <li>Other:
      <ul>
        <li>Enums:
          <ul>
            <li>InputKeyPressType: OnUp/OnDown</li>
            <li>MouseButton: Left/Middle/Right</li>
            <li>Commands: Wait/MoveUp/MoveDown/MoveLeft/MoveRight</li>
            <li>Direction: Wait/Up/Down/Left/Right</li>
          </ul>
        </li>
      </ul>
    </li>
    <li>KeyboardInputHelper: I wrote some wrap over KeyboardState, and after it I saw wrapper like this in Transistor game. SO this is collective code. code example will be soon</li>
    <li>Position: class like Point or Vector2 in XNA, but you can change coords.
      <source lang="C#">
      Point p = new Point();
      p.X = 2; // doesn't work
      Position pos = new Position();
      pos.X = 2; // work
      </source>
    </li>
    <li>Sort: some sorting algorithms. Just practice, but may be usefull.</li>
    <li>Search: same as Sort.</li>
    <li>FastObjectAllocator: see more at youtube.com/watch?v=BNVP9FJXY6A</li>
  </ul>
</li>
</ul>