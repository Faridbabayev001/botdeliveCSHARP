![botdelive](https://botdelive.com/images/logo.png)

About
-------------

**BotDelive** is a Push Notification and 2-factor authentication API service that works over the chat bots (Telegram and Messenger).

Requirements
-------------

1. [Create an account](https://botdelive.com/login).
2. Create an app on the dashboard to get appId and secretKey credentials.
3. Install nuget package

Usage
-------------

Let's install and initialize the library first. Don't forget to replace `<YOUR_APP_ID>` and `<YOUR_SECRET_KEY>`.
```c#
using BotDelive;

Botdelive bd = new Botdelive('<YOUR_APP_ID>', '<YOUR_SECRET_KEY>');
```

**Verify the "Access Code":**
```c#
bd.Verify('<BOT_GENERATED_ACCESS_CODE>');
```

**Send 2-factor authentication request (long polling):**
```c#
bd.Auth(<USER_ID>);
```

**Send Push Notification request:**
```c#
bd.Push(<USER_ID>, <MESSAGE>);
```

Documentation
-------------

Complete documentation available at: [https://botdelive.com/docs](https://botdelive.com/docs)
