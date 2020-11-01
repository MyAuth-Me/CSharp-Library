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

# API Documentation
In this example we are using the no encryption API for MyAuth as there wasn't anything that could do  what we needed properly while maintaining fast and clean code.

## Authenticating
You can send a GET request with these queries to get a response
* Token (This is the license key)
* Hash (This is the users hardware id)
* Secret (This is the public key of your application)

And it will return with one of the following messages.
Quick note: Information is split by `|` so you can split and check the index 0 in the array to check if it's `true` or `error` like shown in the example of authentication
* false|no_exist (The license doesn't exist)
* false|hwid (The HWID mismatches the database)
* false|expired (The license has expired)
* false|restart (A value of the license has updated HWID, Expiry. Restart the application or resend request)


# Cons and Pros
Pros | Cons
------------ |-----
Very basic  | No encryption.
Clean Classes | No json deserialization
