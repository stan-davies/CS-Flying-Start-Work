using System;

namespace temperatureConverter {
    public static class Program {
        public static void Main(string[] args) {
            bool running = true;

            while (running == true) {
                List<string> options = new List<string>() {"Celsius", "Farenheit", "Kelvin", "Exit"};
                
                Console.WriteLine("Temperature Converter:");

                // uses input function beginning line 84, 1 is subtracted as this is used as an index, hence the I in the name
                int convertFromI = Inp("Convert from (enter an option):", options) - 1;
                string convertFrom = options[convertFromI];

                if (convertFrom == "Exit") {
                    break;
                }

                // removal of categories that are now unwanted
                options.RemoveAt(3);
                options.RemoveAt(convertFromI);
                
                // same thing I said in line 13
                int convertToI = Inp("Convert to (select an option):", options) - 1;
                string convertTo = options[convertToI];

                int temp = Inp($"enter the temperature in degrees {convertFrom}: ", new List<string>() {});

                double convertedTemp = 0;

                // considered using functions for the conversions but it seemed excessive
                switch (convertFrom) {
                    case "Celsius":
                        switch (convertTo) {
                            case "Farenheit":
                                convertedTemp = (temp * 9 / 5) + 32;   
                                break;
                            case "Kelvin":
                                convertedTemp = temp + 273.15;   
                                break;
                        }
                        break;
                    case "Farenheit":
                        // for the last two, conversion had to go from celsius for both C and K so that is done as standard
                        convertedTemp = (temp - 32) * 5 / 9;   

                        if (convertTo == "Kelvin") {
                            convertedTemp += 273.15;   
                        }

                        break;
                    case "Kelvin":
                        convertedTemp = temp - 273.15;   

                        if (convertTo == "Farenheit") {
                            convertedTemp = (convertedTemp * 9 / 5) + 32;   
                        }
                        break;
                }

                Console.WriteLine($"{temp}°{convertFrom[0]} is {convertedTemp}°{convertTo[0]}");

                // gives reading time then clears console for next run
                System.Threading.Thread.Sleep(3000);
                System.Console.Clear();
            }
        }

        // function outputs necessary text and then takes an input, all is run 3 times (lines 14, 26 & 29)
        public static int Inp(string _message, List<string> _options) {
            int intNum = 0;
            bool valid = false;
            List<int> viable = new List<int>();

            while (valid == false) {
                // this loop outputs your options but also creates a new array containing the options numbers which is what you input
                int i = 1;
                Console.WriteLine(_message);
                foreach (string option in _options) {
                    viable.Add(i);
                    Console.WriteLine($" {i}. {option}");
                    i++;
                }

                string? input  = Console.ReadLine();
                // checks if its null or contains not digit characters
                if (!String.IsNullOrEmpty(input) && input.All(char.IsDigit)) {
                    intNum = Convert.ToInt32(input);
                    // checks if the input is valid, for the temperature input, an empty option set is used hence the or
                    if (viable.Contains(intNum) || _options.Count == 0) {
                        return intNum;
                    }
                } else {
                    Console.WriteLine("Please enter a valid input");
                }
            }

            // this has to be here because otherwise "not all codepaths return a value" but they do i'm telling you
            return 0;
        }
    }
}
