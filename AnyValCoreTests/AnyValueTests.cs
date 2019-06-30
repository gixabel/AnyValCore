﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using AnyValCore;

namespace AnyValCoreTests
{
    [TestClass]
    public class AnyValueTests
    {
        [TestMethod]
        public void GivenAnyWhenPositiveIntegerThenPositiveIntegerReturned()
        {
            var positiveInt = AnyVal.PositiveInt32();
            positiveInt.Should().BeGreaterOrEqualTo(0);
            Console.WriteLine(positiveInt);
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
            var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
            positiveRange.Should().Be(endValue);
            Console.WriteLine(positiveRange);
        }

        [TestMethod]
        public void GivenNegativeFirstIntegerAndNegativeSecondIntegerWhenPositiveIntegerThenValueReturned()
        {
            const int startValue = -100;
            const int endValue = -200;
            var positiveRange = AnyVal.PositiveInt32(startValue, endValue);
            positiveRange.Should().BeGreaterOrEqualTo(Math.Abs(startValue));
            positiveRange.Should().BeLessOrEqualTo(Math.Abs(endValue));
            Console.WriteLine(positiveRange);
        }

        [TestMethod]
        public void GivenAnyWhenPositiveLongThenPositiveLongReturned()
        {
            var positiveLong = AnyVal.PositiveInt64();
            positiveLong.Should().BeGreaterOrEqualTo(0);
            Console.WriteLine(positiveLong);
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
            dateVal.Should().BeAfter(new DateTime(thisYear - 20, 1, 1));
            dateVal.Should().BeBefore(new DateTime(thisYear + 20, 12, 31));
            Console.WriteLine(dateVal);
        }

        [TestMethod]
        public void GivenAnyWhenEmailStringThenEmailReturned()
        {
            var email = AnyVal.EmailString();
            email.Should().MatchRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Console.WriteLine(email);
        }

        [TestMethod]
        public void GivenAnyWhenEmailThenEmailReturned()
        {
            var email = new AnyVal().Email();
            email.Should().MatchRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Console.WriteLine(email);
        }

        [TestMethod]
        public void GivenAnyWhenDateAfterThenDateAfterReturned()
        {
            var dateAfter = DateTime.Now;
            var dateAfterFromAny = AnyVal.DateTimeAfter(dateAfter);
            dateAfterFromAny.Should().BeAfter(dateAfter);
            Console.WriteLine(dateAfterFromAny);
        }

        [TestMethod]
        public void GivenAnyWhenDateBeforeThenDateBeforeReturned()
        {
            var dateBefore = DateTime.Now;
            var dateBeforeFromAny = AnyVal.DateTimeBefore(dateBefore);
            dateBeforeFromAny.Should().BeBefore(dateBefore);
            Console.WriteLine(dateBeforeFromAny);
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
            var paragraphReturned = AnyVal.Paragraphs(maximumLength);
            paragraphReturned.Length.Should().Be(maximumLength);
            Console.WriteLine(paragraphReturned);
        }

        [TestMethod]
        public void GivenAnyWhenAddressThenAddressReturned()
        {
            var addressReturned = AnyVal.AddressString();
            addressReturned.Should().MatchRegex("^[0-9]{1,4} [a-zA-Z]{4,10} [a-zA-Z]{2}$");
            Console.WriteLine(addressReturned);
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
            var alphaNumericReturned = AnyVal.Alphanumeric();
            alphaNumericReturned.Should().MatchRegex("^[a-zA-Z0-9]*");
            Console.WriteLine(alphaNumericReturned);
        }

        [TestMethod]
        public void GivenAnyWhenEnumValueOfThenEnumValueReturned()
        {
            var enumValue = AnyVal.OfEnum<TestEnum>();
            ((int) enumValue).Should().BeGreaterOrEqualTo((int) TestEnum.First);
            ((int) enumValue).Should().BeLessOrEqualTo((int) TestEnum.Third);
            Console.WriteLine(enumValue.ToString());
        }

        public enum TestEnum { First = 1, Second, Third };
    }
}
