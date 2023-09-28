using Xunit;
using MyLibrary;

public class FizzBuzzUnitTests
{
    private readonly TwistedFizzBuzz twistedFizzBuzz;

    public FizzBuzzUnitTests()
    {
        twistedFizzBuzz = new();
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    public void StandardFizzBuzz(int pos, string expectedResult)
    {
        twistedFizzBuzz.ParseInput("multiple: 3, word: Fizz");
        twistedFizzBuzz.ParseInput("multiple: 5, word: Buzz");

        var kvpList = twistedFizzBuzz.GetFizzBuzzConfigDivisorTokenpairs();
        var result = twistedFizzBuzz.FizzBuzzChecker(pos, kvpList);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(-5, "Fish")]
    [InlineData(6, "Dog")]
    [InlineData(12, "DogCat")]
    [InlineData(15, "Fish")]
    [InlineData(60, "FishDogCat")]
    public void CustomFizzBuzz1(int pos, string expectedResult)
    {
        // TwistedFizzBuzz twistedFizzBuzz = new();
        twistedFizzBuzz.ParseInput("set: -5, 6, 300, 12, 15");
        twistedFizzBuzz.ParseInput("multiple: 5, word: Fish");
        twistedFizzBuzz.ParseInput("multiple: 6, word: Dog");
        twistedFizzBuzz.ParseInput("multiple: 12, word: Cat");

        var kvpList = twistedFizzBuzz.GetFizzBuzzConfigDivisorTokenpairs();
        var result = twistedFizzBuzz.FizzBuzzChecker(pos, kvpList);
        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData(5, "Fizz")]
    [InlineData(9, "Buzz")]
    [InlineData(27, "BuzzBar")]
    [InlineData(54, "BuzzBar")]
    // [InlineData(10, "Test")]
    // [InlineData(7, "7")]
    // [InlineData(30, "FizzBuzz")]
    public void CustomFizzBuzz2(int pos, string expectedResult)
    {
        // TwistedFizzBuzz twistedFizzBuzz = new();
        twistedFizzBuzz.ParseInput("range: (-20)-127");
        twistedFizzBuzz.ParseInput("multiple: 5, word: Fizz");
        twistedFizzBuzz.ParseInput("multiple: 9, word: Buzz");
        twistedFizzBuzz.ParseInput("multiple: 27, word: Bar");

        var kvpList = twistedFizzBuzz.GetFizzBuzzConfigDivisorTokenpairs();
        var result = twistedFizzBuzz.FizzBuzzChecker(pos, kvpList);
        Assert.Equal(expectedResult, result);
    }
}
