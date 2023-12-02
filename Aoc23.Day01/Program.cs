using System.Text.RegularExpressions;

List<string> example = new List<string> {
    "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"
};
var input = File.ReadLines(AppContext.BaseDirectory + "input.txt");

var total = 0;

foreach (var line in input) {
    
    var test = Regex.Matches(line, @"\d");
    if (test.Count == 1) {
        var value = test.ToList()[0].Value;
        total += int.Parse($"{value}{value}");
    } else {
        var firstValue = test.ToList()[0].Value;
        var lastValue = test.ToList()[test.Count - 1].Value;
        total += int.Parse($"{firstValue}{lastValue}");
    }
    
}

Console.WriteLine($"Day 1 first part: {total}.");
Console.WriteLine("*----------------------*");


// gave up on part 2 for now