![AnyValCore](AnyValCore.png "Any value Core")

[![Build status](https://dev.azure.com/gixabel0908/AnyValCore/_apis/build/status/AnyValCore-CI)](https://dev.azure.com/gixabel0908/AnyValCore/_build/latest?definitionId=-1)

**AnyValCore** is just a class with several static methods that I use whenver I need a random value such a string, a date, a positive integer, etc.

Usage is simple: 
1. Go to your NuGet Package Manager.
2. Type AnyValCore.
3. Install latest (currently 2.2.0)
4. Add AnyValCoreto your usings clause: `using AnyValCore;`
5. Start using `AnyVal`.

Current available values are:
* PositiveInt(),
* PositiveInt(maximumValue),
* PositiveInt32(int minimumValue, int maximumValue),
* PositiveInt64(),
* StringLowerCase(),
* StringLowerCase(int size),
* String(),
* String(int size),
* Alphanumeric(),
* Alphanumeric(int size),
* Decimal(),
* Decimal(int maximumValue),
* DateTime(),
* DateTimeAfter(DateTime anyDateTime),
* DateTimeBefore(DateTime anyDateTime),
* EmailString(),
* Email() non static, deprecated,
* Int32(),
* Paragraphs(int maximumLength),
* AddressString(),
* Bool().

