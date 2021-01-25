# WARNING API IS GOING THROUGH HEAVY CHANGES AND WILL MOST LIKELY BREAK

Next version already breaks anything releated to the websocket as I switched the underlying library to Websocket.Client

more breaking changes are coming soon

# GotifySharp

Library used to interact with Gotify Server built in .Net Core 3.0

## Todo
The structure of this library chagned many many time as I expiremented and tried to figure out which way I liked best.

Therefore a lot of code cleanup is needed including breaking changes for naming. I would not use this library in any production enviroments at the moment.

* Create a more consistent naming scheme
* Support Extras in Messages
* Add support for The rest of the APi
  * Version
  * Plugin
  * Health
  * User
  * Deleting in all other endpoints
* Finish Intergration Tests

## Example Use

To createt the object just supply the follows shown below 

### Creating

```CSharp
    IConfig config = new AppConfig(Username, Password, Url, port, Protocol, Path);
    GotifySharp _gotifySharp = new GotifySharp(config);
```

## Response Format

When calling an endpoint it will return an Response object specific to that endpoint. 
Before using the data always check the Success property.

If true then you can read the Model data from the response otherwise get the Error Response and see what Gotify returned.

if you try to access the Success Response on failure or Error Response on Success you will get an Exception

### Getting Applications and Messages

To get a list of Applications just call GetApplications()

```CSharp
    var response = await _gotifySharp.GetApplications();
```

on Success it will return a List<ApplicationModels>

Getting Messages follows the same format but you must pass in the AppID of an application on the Gotify Server

### Websocket

To use the /stream URL just listen for the GotifySharp_OnMessage event

```CSharp
    gotifySharp.OnMessage += GotifySharp_OnMessage;

    private void GotifySharp_OnMessage(object sender, MessageModel e)
    {
        //Code Here
    }
```
