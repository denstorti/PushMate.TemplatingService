# PushMate Templating Service
[![Build status](https://ci.appveyor.com/api/projects/status/b5olcptd8j5uw784/branch/master?svg=true)](https://ci.appveyor.com/project/denstorti/pushmate-templatingservice/branch/master)

Native C# library for templating. 

Intended use is for push notifications, SMS and Email systems, templating not only the text itself but also other specific attributes of each platform. For example: sound in push notifications. Use case: send push notifications messages containing the Name and Balance of each customer and play the sound they choose when it arrives.

```csharp
  string baseTemplate = "Hello $name$. Your account balance is $$balance$. Thanks $name$!";
  
  var dictVariables = new Dictionary<string, string>
  {
      { "name", "Denis"},
      { "balance", "1000.00"}
  };

  string result = TemplateService.ApplyTextTemplate(baseTemplate, dictVariables);

  Assert.Equal("Hello Denis. Your account balance is $1000.00. Thanks Denis!", result);
```
