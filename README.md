# Team Room Portable #

## What is it? ##
Team Room Portable is a Portable Class Library that gives developers access to the Team Rooms, Users and Messages from Team Foundation Service.

## What targets does it have? ##
.NET 4.0+, Silverlight 5, Windows Store apps, Windows Phone 7.5, Windows Phone 8.

## How do I connect to my Team Foundation Service Account? ##
To access the API you need to enable alternative credentials for your account.

See the section __Enable basic authentication for your account__ from ([here](http://tfs.visualstudio.com/en-us/learn/use-git-and-xcode-with-tfs.aspx)).

Look at the TeamRoomPortableSample for how to use this, enjoy.

## How do I install it? ##
PM> Install-Package TeamRoomPortable

## Change log ##
1.0.1 - August 4, 2013
 
+	All data object now implements INotifyPropertyChanged

+	Removed NuGet Package Restore from project as it does not play nicely together with Microsoft.Bcl.Async

+	The API now supports querying user information for all members of a given team room, this is especially useful when identifying who posted a given message.
	






















