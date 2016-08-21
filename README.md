Usage:
``` csharp
Log.Write("Hello World");
Log.Write("You should log", Severity.Warning);
```

Adding additional log info example:
``` csharp
Log.InfoProvider.Add(new LongTimeInfoProvider());
```

Writing to custom sources:
``` csharp
Log.Destinations.Add(new StreamLogDestination(stream));
```

Build custom components with:
+ ILogDestination
+ ILogInfoProvider
