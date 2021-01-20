# Custom Discord Rich Presence

A small .NET core console application that can easily be configured to create a custom rich presence in Discord

## Installation

For windows users you can download the latest release and run the .exe file located in the archive


## Usage

Upon running the application for the first time, the application will create an empty configuration file (config.json) in which a few values need to be configured. 

#### Blank Config.json File
```json
{
  "ApplicationId": "",
  "Details": "",
  "State": "",
  "LargeImageKey": "",
  "LargeImageText": "",
  "SmallImageKey": "",
  "SmallImageText": ""
}
```

**Application Id**: This is the application ID for you application, you can get this Id by going to the main screen of your application in the Discord Developer Panel [Here](https://discord.com/developers).

**Details**: This is a custom string of text, set this to whatever value you'd like. If you also set the "State" value, Details will be show at the 1st row of the rich presence

**State** Another custom string of text, freely configurable to any value you'd like. If you have also set the "Details" value, this will be shown as the 2nd line in the rich presence.

**LargeImageKey**: This is a key to an image that has been linked to your application (you can view these images and key son the Discord Developer Panel [Here](https://discord.com/developers). By setting this to a key that exists in your appplication. The image will be displayed in the main image container in the rich presence.

**LargeImageText**: This is the text that will be shown upon hovering over the main image container, this requires the LargeImageKey to be set and valid.

**SmallImageKey**: This is another key to an image that has been linked to your application. By setting this to an existing image key in your application, the image will be displayed in the lower right corner of the right presence image area. To be able to display this image, the LargeImageKey will have to be set and valid.

**SmallImageText**: This is the text that will be shown upon hovering over the small image (shown in the bottom right corner of the presence image area. This will require SmallImageKey to be set and valid.


## ❤
If you decide to use my code I'd appreciate you saying hi for a bit :D I'd love to hear what you want to make! 
Feel free to contact me on Discord (Myu#0001) or Email (myu@subsilence.nl)
