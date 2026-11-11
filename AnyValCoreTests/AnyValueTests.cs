using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyValCore;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace AnyValCoreTests;

[TestClass]
public class AnyValueTests
{
    [TestMethod]
    public void GivenAnyWhenPositiveIntegerThenPositiveIntegerReturned()
    {
        AnyVal.PositiveInt32().ShouldBeGreaterThanOrEqualTo(0);
        Console.WriteLine(AnyVal.PositiveInt32());
    }

    [TestMethod]
    public void GivenAnyWhenPositiveInt32GreaterThanZeroThenPositiveIntegerReturned()
    {
        for (var count = 0; count < 500000; count++)
        {
            AnyVal.PositiveInt32GreaterThanZero().ShouldBeGreaterThan(0);
        }
    }

    [TestMethod]
    public void GivenAnyWhenNegativeIntegerThenNegativeIntegerReturned()
    {
        AnyVal.NegativeInt32().ShouldBeLessThanOrEqualTo(0);
        Console.WriteLine(AnyVal.NegativeInt32());
    }

    [TestMethod]
    public void GivenAnyWhenPositiveIntegerMaxThenPositiveIntegerReturned()
    {
        const int maxValue = 50;
        var positiveInt = AnyVal.PositiveInt32(maxValue);
        positiveInt.ShouldBeLessThanOrEqualTo(maxValue);
        positiveInt.ShouldBeGreaterThanOrEqualTo(0);
        Console.WriteLine(positiveInt);
    }

    [TestMethod]
    public void GivenAnyWhenNegativeIntegerMaxThenNegativeIntegerReturned()
    {
        const int minValue = -50;
        var negativeInt = AnyVal.NegativeInt32(minValue);
        negativeInt.ShouldBeLessThanOrEqualTo(0);
        negativeInt.ShouldBeGreaterThanOrEqualTo(minValue);
        Console.WriteLine(negativeInt);
    }

    [TestMethod]
    public void GivenAnyWhenPositiveRangeThenPositiveInRangeReturned()
    {
        const int startValue = 1024;
        const int endValue = 2048;
        var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
        positiveRange.ShouldBeGreaterThanOrEqualTo(startValue);
        positiveRange.ShouldBeLessThanOrEqualTo(endValue);
        Console.WriteLine(positiveRange);
    }

    [TestMethod]
    public void GivenAnyWhenNegativeRangeThenPositiveInRangeReturned()
    {
        const int startValue = 1024;
        const int endValue = -2048;
        var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
        positiveRange.ShouldBeGreaterThanOrEqualTo(startValue);
        positiveRange.ShouldBeLessThanOrEqualTo(Math.Abs(endValue));
        Console.WriteLine(positiveRange);
    }

    [TestMethod]
    public void GivenNegativeFirstIntegerAndPositiveSecondIntegerWhenPositiveIntegerThenValueReturned()
    {
        const int startValue = -100;
        const int endValue = 100;
        AnyVal.PositiveInt32(startValue, endValue).ShouldBe(endValue);
        Console.WriteLine(AnyVal.PositiveInt32(startValue, endValue));
    }

    [TestMethod]
    public void GivenNegativeFirstIntegerAndNegativeSecondIntegerWhenPositiveIntegerThenValueReturned()
    {
        const int startValue = -100;
        const int endValue = -200;
        var positiveValue = AnyVal.PositiveInt32(startValue, endValue);
        positiveValue.ShouldBeGreaterThanOrEqualTo(Math.Abs(startValue));
        positiveValue.ShouldBeLessThanOrEqualTo(Math.Abs(endValue));
        Console.WriteLine(positiveValue);
    }

    [TestMethod]
    public void GivenMinValueAndMaxValueWhenNegativeInt32ThenNegativeValueReturned()
    {
        const int startValue = -200;
        const int endValue = -100;
        var negativeValue = AnyVal.NegativeInt32(startValue, endValue);
        negativeValue.ShouldBeGreaterThanOrEqualTo(startValue);
        negativeValue.ShouldBeLessThanOrEqualTo(endValue);

    }

    [TestMethod]
    public void GivenAnyWhenPositiveLongThenPositiveLongReturned()
    {
        AnyVal.PositiveInt64().ShouldBeGreaterThanOrEqualTo(0);
        Console.WriteLine(AnyVal.PositiveInt64());
    }

    [TestMethod]
    public void GivenAnyWhenAlphaLowercaseThenAlphaLowerCaseReturned()
    {
        var alphaLowerCase = AnyVal.StringLowerCase();
        alphaLowerCase.ShouldNotBeNullOrEmpty();
        alphaLowerCase.ShouldMatch("^[a-z]+$");
        Console.WriteLine(alphaLowerCase);
    }

    [TestMethod]
    public void GivenAnyWhenAlphaThenAlphaReturned()
    {
        var alpha = AnyVal.String();
        alpha.ShouldNotBeNullOrEmpty();
        alpha.ShouldMatch("^[a-zA-Z]+$");
        Console.WriteLine(alpha);
    }

    [TestMethod]
    public void GivenAnyWhenAlphaMaxLenThenAlphaMaxLenReturned()
    {
        const int maxLength = 120;
        var alpha = AnyVal.String(maxLength);
        alpha.Length.ShouldBeLessThanOrEqualTo(maxLength);
        alpha.ShouldNotBeNullOrEmpty();
        alpha.ShouldMatch("^[a-zA-Z]{" + maxLength + "}$");
        Console.WriteLine(alpha);
    }

    [TestMethod]
    public void GivenAnyAndSizeWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        const int maxLength = 120;
        var alpha = AnyVal.StringWithSingleQuotes(maxLength);
        alpha.Length.ShouldBe(maxLength);
        alpha.ShouldNotBeNullOrEmpty();
        alpha.ShouldContain("\'");
    }

    [TestMethod]
    public void GivenAnyAndSmallSizeWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        const int maxLength = 2;
        var alpha = AnyVal.StringWithSingleQuotes(maxLength);
        alpha.Length.ShouldBe(maxLength);
        alpha.ShouldNotBeNullOrEmpty();
        alpha.ShouldContain("\'");
    }

    [TestMethod]
    public void GivenAnyAndWhenStringWithSingleQuotesThenStringWithQuotesReturned()
    {
        var alpha = AnyVal.StringWithSingleQuotes();
        alpha.ShouldNotBeNullOrEmpty();
        alpha.ShouldContain("\'");
    }

    [TestMethod]
    public void GivenAnyWhenFloatThenFloatReturned()
    {
        var floatVal = AnyVal.Decimal();
        floatVal.ShouldBeLessThanOrEqualTo(100);
        Console.WriteLine(floatVal);
    }

    [TestMethod]
    public void GivenAnyWhenFloatMaxValThenFloatMaxValReturned()
    {
        const int maxVal = 500;
        var floatVal = AnyVal.Decimal(maxVal);
        floatVal.ShouldBeLessThanOrEqualTo(maxVal);
        Console.WriteLine(floatVal);
    }

    [TestMethod]
    public void GivenAnyWhenDecimalGreaterThanZeroThenDecimalReturned()
    {
        for (var cycle = 1; cycle <= 2000; cycle++)
        {
            AnyVal.DecimalGreaterThanZero().ShouldBeGreaterThan(0);
        }
    }

    [TestMethod]
    public void GivenAnyWhenDateThenDateReturned()
    {
        var dateVal = AnyVal.DateTime();
        var thisYear = DateTime.Now.Date.Year;
        dateVal.ShouldBeGreaterThan(new DateTime(thisYear - 25, 1, 1));
        dateVal.ShouldBeLessThan(new DateTime(thisYear + 25, 12, 31));
        Console.WriteLine(dateVal);
    }

    [TestMethod]
    public void GivenAnyWhenEmailStringThenEmailReturned()
    {
        AnyVal.EmailString().ShouldMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Console.WriteLine(AnyVal.EmailString());
    }

    [TestMethod]
    public void GivenAnyWhenDateAfterThenDateAfterReturned()
    {
        var dateAfter = DateTime.Now;
        AnyVal.DateTimeAfter(dateAfter).ShouldBeGreaterThan(dateAfter);
        Console.WriteLine(AnyVal.DateTimeAfter(dateAfter));
    }

    [TestMethod]
    public void GivenAnyWhenDateBeforeThenDateBeforeReturned()
    {
        var dateBefore = DateTime.Now;
        AnyVal.DateTimeBefore(dateBefore).ShouldBeLessThan(dateBefore);
        Console.WriteLine(AnyVal.DateTimeBefore(dateBefore));
    }

    [TestMethod]
    public void GivenAnyWhenLongParagraphThenParagraphReturned()
    {
        const int maximumLength = 500;
        var paragraphReturned = AnyVal.Paragraphs(maximumLength);
        paragraphReturned.Length.ShouldBe(maximumLength);
        paragraphReturned.ShouldContain(" ");
        paragraphReturned.ShouldContain(".\r\n");
        Console.WriteLine(paragraphReturned);
    }

    [TestMethod]
    public void GivenAnyWhenShortParagraphThenParagraphReturned()
    {
        const int maximumLength = 1;
        AnyVal.Paragraphs(maximumLength).Length.ShouldBe(maximumLength);
        Console.WriteLine(AnyVal.Paragraphs(maximumLength));
    }

    [TestMethod]
    public void GivenAnyWhenAddressThenAddressReturned()
    {
        AnyVal.AddressString().ShouldMatch("^[0-9]{1,4} [a-zA-Z]{8,16} [a-zA-Z]{2}$");
        Console.WriteLine(AnyVal.AddressString());
    }

    [TestMethod]
    public void GivenAnyWhenAlphanumericWithSizeThenAlphanumericReturned()
    {
        var size = AnyVal.PositiveInt32(32);
        var alphaNumericReturned = AnyVal.Alphanumeric(size);
        alphaNumericReturned.ShouldMatch("^[a-zA-Z0-9]*");
        alphaNumericReturned.Length.ShouldBe(size);
        Console.WriteLine(alphaNumericReturned);
    }

    [TestMethod]
    public void GivenAnyWhenAlphanumericThenAlphanumericReturned()
    {
        AnyVal.Alphanumeric().ShouldMatch("^[a-zA-Z0-9]*");
        Console.WriteLine(AnyVal.Alphanumeric());
    }

    [TestMethod]
    public void GivenAnyWhenEnumValueOfThenEnumValueReturned()
    {
        var enumValue = AnyVal.OfEnum<TestEnum>();
        ((int) enumValue).ShouldBeGreaterThanOrEqualTo((int) TestEnum.First);
        ((int) enumValue).ShouldBeLessThanOrEqualTo((int) TestEnum.Third);
        Console.WriteLine(enumValue.ToString());
    }

    [TestMethod]
    public void GivenAnyWhenEnumValueOfExceptFirstThenEnumValueReturned()
    {
        for (var tries = 0; tries < 200; tries++)
        {
            var enumValue = AnyVal.OfEnumExceptFirst<TestEnum>();
            enumValue.ShouldNotBe(TestEnum.First);
            Console.WriteLine(enumValue.ToString());
        }
    }

    [TestMethod]
    public void WhenPositiveInt32TwiceThenValuesShouldBeDifferent() => 
        AnyVal.PositiveInt32().ShouldNotBe(AnyVal.PositiveInt32());

    [TestMethod]
    public void WhenNegativeInt32TwiceThenValuesShouldBeDifferent() => 
        AnyVal.NegativeInt32().ShouldNotBe(AnyVal.NegativeInt32());

    [TestMethod]
    public void WhenPositiveInt64TwiceThenValuesShouldBeDifferent() => 
        AnyVal.PositiveInt64().ShouldNotBe(AnyVal.PositiveInt64());

    [TestMethod]
    public void WhenStringLowerCaseTwiceThenValuesShouldBeDifferent() => 
        AnyVal.StringLowerCase().ShouldNotBe(AnyVal.StringLowerCase());

    // Guards thread-safety of the shared generator. System.Random is not
    // thread-safe: concurrent calls corrupt its internal state and every later call
    // returns 0. Consumers run NUnit [Parallelizable] fixtures, so this is a real
    // path. A plain loop cannot catch it - the calls have to actually overlap.

    [TestMethod]
    public void GivenParallelCallersWhenIntegersRequestedThenGeneratorStaysHealthy()
    {
        // A legitimate zero from PositiveInt32() has odds of 1 in int.MaxValue,
        // so a single zero here means the generator was corrupted.
        const int iterations = 200000;
        var zeroCount = 0;

        Parallel.For(0, iterations, _ =>
        {
            if (AnyVal.PositiveInt32() == 0)
            {
                Interlocked.Increment(ref zeroCount);
            }
        });

        zeroCount.ShouldBe(0);
    }

    public enum TestEnum { First = 10, Second, Third }
}
