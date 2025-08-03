using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using AnyValCore;

namespace AnyValCoreTests;

[TestClass]
public class AnyValueTests
{
    [TestMethod]
    public void GivenAnyWhenPositiveIntegerThenPositiveIntegerReturned()
    {
        AnyVal.PositiveInt32().Should().BeGreaterOrEqualTo(0);
        Console.WriteLine(AnyVal.PositiveInt32());
    }

    [TestMethod]
    public void GivenAnyWhenNegativeIntegerThenNegativeIntegerReturned()
    {
        AnyVal.NegativeInt32().Should().BeLessOrEqualTo(0);
        Console.WriteLine(AnyVal.NegativeInt32());
    }

    [TestMethod]
    public void GivenAnyWhenPositiveIntegerMaxThenPositiveIntegerReturned()
    {
        const int maxValue = 50;
        var positiveInt = AnyVal.PositiveInt32(maxValue);
        positiveInt.Should().BeLessOrEqualTo(maxValue);
        positiveInt.Should().BeGreaterOrEqualTo(0);
        Console.WriteLine(positiveInt);
    }

    [TestMethod]
    public void GivenAnyWhenNegativeIntegerMaxThenNegativeIntegerReturned()
    {
        const int minValue = -50;
        var negativeInt = AnyVal.NegativeInt32(minValue);
        negativeInt.Should().BeLessOrEqualTo(0);
        negativeInt.Should().BeGreaterOrEqualTo(minValue);
        Console.WriteLine(negativeInt);
    }

    [TestMethod]
    public void GivenAnyWhenPositiveRangeThenPositiveInRangeReturned()
    {
        const int startValue = 1024;
        const int endValue = 2048;
        var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
        positiveRange.Should().BeGreaterOrEqualTo(startValue);
        positiveRange.Should().BeLessOrEqualTo(endValue);
        Console.WriteLine(positiveRange);
    }

    [TestMethod]
    public void GivenAnyWhenNegativeRangeThenPositiveInRangeReturned()
    {
        const int startValue = 1024;
        const int endValue = -2048;
        var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
        positiveRange.Should().BeGreaterOrEqualTo(startValue);
        positiveRange.Should().BeLessOrEqualTo(Math.Abs(endValue));
        Console.WriteLine(positiveRange);
    }

    [TestMethod]
    public void GivenNegativeFirstIntegerAndPositiveSecondIntegerWhenPositiveIntegerThenValueReturned()
    {
        const int startValue = -100;
        const int endValue = 100;
        AnyVal.PositiveInt32(startValue, endValue).Should().Be(endValue);
        Console.WriteLine(AnyVal.PositiveInt32(startValue, endValue));
    }

    [TestMethod]
    public void GivenNegativeFirstIntegerAndNegativeSecondIntegerWhenPositiveIntegerThenValueReturned()
    {
        const int startValue = -100;
        const int endValue = -200;
        var positiveValue = AnyVal.PositiveInt32(startValue, endValue);
        positiveValue.Should().BeGreaterOrEqualTo(Math.Abs(startValue));
        positiveValue.Should().BeLessOrEqualTo(Math.Abs(endValue));
        Console.WriteLine(positiveValue);
    }

    [TestMethod]
    public void GivenMinValueAndMaxValueWhenNegativeInt32ThenNegativeValueReturned()
    {
        const int startValue = -200;
        const int endValue = -100;
        var negativeValue = AnyVal.NegativeInt32(startValue, endValue);
        negativeValue.Should().BeGreaterOrEqualTo(startValue);
        negativeValue.Should().BeLessOrEqualTo(endValue);

    }

    [TestMethod]
    public void GivenAnyWhenPositiveLongThenPositiveLongReturned()
    {
        AnyVal.PositiveInt64().Should().BeGreaterOrEqualTo(0);
        Console.WriteLine(AnyVal.PositiveInt64());
    }

    [TestMethod]
    public void GivenAnyWhenAlphaLowercaseThenAlphaLowerCaseReturned()
    {
        var alphaLowerCase = AnyVal.StringLowerCase();
        alphaLowerCase.Should().NotBeNullOrEmpty();
        alphaLowerCase.Should().MatchRegex("^[a-z]+$");
        Console.WriteLine(alphaLowerCase);
    }

    [TestMethod]
    public void GivenAnyWhenAlphaThenAlphaReturned()
    {
        var alpha = AnyVal.String();
        alpha.Should().NotBeNullOrEmpty();
        alpha.Should().MatchRegex("^[a-zA-Z]+$");
        Console.WriteLine(alpha);
    }

    [TestMethod]
    public void GivenAnyWhenAlphaMaxLenThenAlphaMaxLenReturned()
    {
        const int maxLength = 120;
        var alpha = AnyVal.String(maxLength);
        alpha.Length.Should().BeLessOrEqualTo(maxLength);
        alpha.Should().NotBeNullOrEmpty();
        alpha.Should().MatchRegex("^[a-zA-Z]{" + maxLength + "}$");
        Console.WriteLine(alpha);
    }

    [TestMethod]
    public void GivenAnyAndSizeWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        const int maxLength = 120;
        var alpha = AnyVal.StringWithSingleQuotes(maxLength);
        alpha.Length.Should().Be(maxLength);
        alpha.Should().NotBeNullOrEmpty();
        alpha.Should().Contain("\'");
    }

    [TestMethod]
    public void GivenAnyAndSmallSizeWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        const int maxLength = 2;
        var alpha = AnyVal.StringWithSingleQuotes(maxLength);
        alpha.Length.Should().Be(maxLength);
        alpha.Should().NotBeNullOrEmpty();
        alpha.Should().Contain("\'");
    }

    [TestMethod]
    public void GivenAnyAndWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        var alpha = AnyVal.StringWithSingleQuotes();
        alpha.Should().NotBeNullOrEmpty();
        alpha.Should().Contain("\'");
    }

    [TestMethod]
    public void GivenAnyWhenFloatThenFloatReturned()
    {
        var floatVal = AnyVal.Decimal();
        floatVal.Should().BeLessOrEqualTo(100);
        Console.WriteLine(floatVal);
    }

    [TestMethod]
    public void GivenAnyWhenFloatMaxValThenFloatMaxValReturned()
    {
        const int maxVal = 500;
        var floatVal = AnyVal.Decimal(maxVal);
        floatVal.Should().BeLessOrEqualTo(maxVal);
        Console.WriteLine(floatVal);
    }

    [TestMethod]
    public void GivenAnyWhenDateThenDateReturned()
    {
        var dateVal = AnyVal.DateTime();
        var thisYear = DateTime.Now.Date.Year;
        dateVal.Should().BeAfter(new DateTime(thisYear - 25, 1, 1));
        dateVal.Should().BeBefore(new DateTime(thisYear + 25, 12, 31));
        Console.WriteLine(dateVal);
    }

    [TestMethod]
    public void GivenAnyWhenEmailStringThenEmailReturned()
    {
        AnyVal.EmailString().Should().MatchRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Console.WriteLine(AnyVal.EmailString());
    }

    [TestMethod]
    public void GivenAnyWhenDateAfterThenDateAfterReturned()
    {
        var dateAfter = DateTime.Now;
        AnyVal.DateTimeAfter(dateAfter).Should().BeAfter(dateAfter);
        Console.WriteLine(AnyVal.DateTimeAfter(dateAfter));
    }

    [TestMethod]
    public void GivenAnyWhenDateBeforeThenDateBeforeReturned()
    {
        var dateBefore = DateTime.Now;
        AnyVal.DateTimeBefore(dateBefore).Should().BeBefore(dateBefore);
        Console.WriteLine(AnyVal.DateTimeBefore(dateBefore));
    }

    [TestMethod]
    public void GivenAnyWhenLongParagraphThenParagraphReturned()
    {
        const int maximumLength = 500;
        var paragraphReturned = AnyVal.Paragraphs(maximumLength);
        paragraphReturned.Length.Should().Be(maximumLength);
        paragraphReturned.Should().Contain(" ");
        paragraphReturned.Should().Contain(".\r\n");
        Console.WriteLine(paragraphReturned);
    }

    [TestMethod]
    public void GivenAnyWhenShortParagraphThenParagraphReturned()
    {
        const int maximumLength = 1;
        AnyVal.Paragraphs(maximumLength).Length.Should().Be(maximumLength);
        Console.WriteLine(AnyVal.Paragraphs(maximumLength));
    }

    [TestMethod]
    public void GivenAnyWhenAddressThenAddressReturned()
    {
        AnyVal.AddressString().Should().MatchRegex("^[0-9]{1,4} [a-zA-Z]{8,16} [a-zA-Z]{2}$");
        Console.WriteLine(AnyVal.AddressString());
    }

    [TestMethod]
    public void GivenAnyWhenAlphanumericWithSizeThenAlphanumericReturned()
    {
        var size = AnyVal.PositiveInt32(32);
        var alphaNumericReturned = AnyVal.Alphanumeric(size);
        alphaNumericReturned.Should().MatchRegex("^[a-zA-Z0-9]*");
        alphaNumericReturned.Length.Should().Be(size);
        Console.WriteLine(alphaNumericReturned);
    }

    [TestMethod]
    public void GivenAnyWhenAlphanumericThenAlphanumericReturned()
    {
        AnyVal.Alphanumeric().Should().MatchRegex("^[a-zA-Z0-9]*");
        Console.WriteLine(AnyVal.Alphanumeric());
    }

    [TestMethod]
    public void GivenAnyWhenEnumValueOfThenEnumValueReturned()
    {
        var enumValue = AnyVal.OfEnum<TestEnum>();
        ((int) enumValue).Should().BeGreaterOrEqualTo((int) TestEnum.First);
        ((int) enumValue).Should().BeLessOrEqualTo((int) TestEnum.Third);
        Console.WriteLine(enumValue.ToString());
    }

    [TestMethod]
    public void GivenAnyWhenEnumValueOfExceptFirstThenEnumValueReturned()
    {
        for (var tries = 0; tries < 20; tries++)
        {
            var enumValue = AnyVal.OfEnumExceptFirst<TestEnum>();
            enumValue.Should().NotBe(TestEnum.First);
            Console.WriteLine(enumValue.ToString());
        }
    }

    [TestMethod]
    public void WhenPositiveInt32TwiceThenValuesShouldBeDifferent() => 
        AnyVal.PositiveInt32().Should().NotBe(AnyVal.PositiveInt32());

    [TestMethod]
    public void WhenNegativeInt32TwiceThenValuesShouldBeDifferent() => 
        AnyVal.NegativeInt32().Should().NotBe(AnyVal.NegativeInt32());

    [TestMethod]
    public void WhenPositiveInt64TwiceThenValuesShouldBeDifferent() => 
        AnyVal.PositiveInt64().Should().NotBe(AnyVal.PositiveInt64());

    [TestMethod]
    public void WhenStringLowerCaseTwiceThenValuesShouldBeDifferent() => 
        AnyVal.StringLowerCase().Should().NotBe(AnyVal.StringLowerCase());

    public enum TestEnum { First = 10, Second, Third }
}
