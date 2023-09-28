using System;
using MyLibrary;

TwistedFizzBuzz twistedFizzBuzz = new();
twistedFizzBuzz.ParseInput("range: (-2)-(-37)");
twistedFizzBuzz.Start();

Console.WriteLine("----------------------");

TwistedFizzBuzz twistedFizzBuzz2 = new();
twistedFizzBuzz2.ParseInput("set: -5, 6, 300, 12, 15");
twistedFizzBuzz2.Start();

Console.WriteLine("----------------------");

TwistedFizzBuzz twistedFizzBuzz3 = new();
twistedFizzBuzz3.ParseInput("set: 119, 51, 21, 357");
twistedFizzBuzz3.ParseInput("multiple: 7, word: Poem");
twistedFizzBuzz3.ParseInput("multiple: 17, word: Writer");
twistedFizzBuzz3.ParseInput("multiple: 3, word: College");
// twistedFizzBuzz3.ParseInput("asdasfj;lwejkvf");
twistedFizzBuzz3.Start();

Console.WriteLine("----------------------");

TwistedFizzBuzz twistedFizzBuzz4 = new();
twistedFizzBuzz4.ParseInput("range: (-20)-127");
twistedFizzBuzz4.ParseInput("multiple: 5, word: Fizz");
twistedFizzBuzz4.ParseInput("multiple: 9, word: Buzz");
twistedFizzBuzz4.ParseInput("multiple: 27, word: Bar");
twistedFizzBuzz4.Start();