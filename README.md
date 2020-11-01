# CSharp-Library
A very basic C# library for https://MyAuth.Me.

Keep in mind this is a very basic project just for showing basic usage.

# Usage
When I wrote this code I had easy usage in mind to make it beautiful and efficient code.
You can initialize an application like so
```csharp
App app = new App("PUBLIC_KEY");
```
And you can authenticate like so
```csharp
Response res = app.Authenticate(key);

if(res.status == ResponseError.success)
{
  // Login Success
}else{
  switch (res.status)
  {
    case ResponseError.invalid_hwid:
      Console.WriteLine("[-] Invalid HWID!");
      break;
    case ResponseError.expired:
      Console.WriteLine("[-] Your license has expired");
      break;
    case ResponseError.invalid_details:
      Console.WriteLine("[-] We couldn't find that license!");
      break;
    case ResponseError.restart_app:
      Console.WriteLine("[+] License updated. Restart application!");
      break;
    case ResponseError.internal_error:
      Console.WriteLine("[-] Internal server issue!");
      break;
                     
    }  
}
```
You can of course rewrite this but it's just a basic example


# Cons and Pros
Pros | Cons
------------ |-----
Very basic  | No encryption.
Clean Classes | No json deserialization
