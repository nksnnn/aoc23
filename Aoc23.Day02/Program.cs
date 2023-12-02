// Only games where the amount of RED < 13, GREEN < 14 & BLUE < 15

var input = File.ReadLines(AppContext.BaseDirectory + "input.txt");

var inputExample = new List<string>() {
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
};

const int maxRed = 12, maxGreen = 13, maxBlue = 14;

var total = 0;

foreach (var line in input) {

    var isLineValid = true;

    var gameNumber = int.Parse(line.Split(":")[0].Split(" ")[1]);

    var splitLine = line[(gameNumber < 10 ? 7 : gameNumber > 99 ? 9 : 8)..].Split(";"); // Copy the line into a new array omitting the Game XX: part
    
    for (var i = 0; i < splitLine.Length && isLineValid; i++) {

        int blue = 0, green = 0, red = 0;

        var splitCubes = splitLine[i][1..].Replace(",", "").Split(" ");

        for (var j = 0; j < splitCubes.Length && isLineValid; j += 2) {

            var cubesAmount = int.Parse(splitCubes[j]);
            
            switch (splitCubes[j + 1]) {
                case "green":
                    green += cubesAmount;
                    break;
                case "red":
                    red += cubesAmount;
                    break;
                case "blue":
                    blue += cubesAmount;
                    break;
                default:
                    Console.WriteLine("woopsies");
                    break;
            }

            if (blue > maxBlue || red > maxRed || green > maxGreen) {
                isLineValid = false;
            }

        }
    }

    if (isLineValid) total += gameNumber;

}

Console.WriteLine($"Day 02 part 1: {total}.");
Console.WriteLine("*-------------------*");

var totalPower = 0;

foreach (var line in input) {

    int minRed = 0, minGreen = 0, minBlue = 0;

    var splitSets = line.Split(":")[1].Replace(",", "").Split(";");

    foreach (var set in splitSets) {

        var splitCubes = set[1..].Split(" ");

        for (var i = 0; i < splitCubes.Length; i += 2) {

            var cubesAmount = int.Parse(splitCubes[i]);

            switch (splitCubes[i + 1]) {
                case "green":
                    if (minGreen < cubesAmount) minGreen = cubesAmount;
                    break;
                case "red":
                    if (minRed < cubesAmount) minRed = cubesAmount;
                    break;
                case "blue":
                    if (minBlue < cubesAmount) minBlue = cubesAmount;
                    break;
                default:
                    Console.WriteLine("woopsies again");
                    break;
            }
            
        }

    }

    totalPower += (minGreen * minBlue * minRed);

}

Console.WriteLine($"Day 02 part 2: {totalPower}.");