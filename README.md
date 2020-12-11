Explanation of this existing
========================
What's that?
-----------------------
That's just another way of syncronizing files but via TCP protocol.

What is could be needed for?
-----------------------
That's personal, but I do use this one myself for syncronizing files between different devices via the wifi.

I've made more than one syncronizer for some purposes, but this one is the one I wanted to be well done.

>Why don't use a ready from-the-box file share thing to keep files in cloud, so you could take these wherever and whenever you want?

That's a complicated question to answer, but I would like to wrap things up.
1. I love doing things my own. Especially if they require some knowledge oh how is this supposed to be done ~~, but that's not really the case~~
1. That's a some kind of practise of doing application that might be really useful
1. I dont trust all the clouds because the keep atleast log of action, which might be not really cool to think about sometimes
1. I love do the things that I want them to be working
1. I need to take my freetime to make some stuff that I happy be dealing with

Concept
----------------------
For now its just a pretty simple algorithm that resolves some file mismatches by asking user what is supposed to happen if they has different hashes and downloading/uploading files if they doesnt exist on another side. 
After resolving what is supposed to happen it actually goes for file tranfer based on TCP protocol.
Resolving goes with the commands that are written in the comments in server.cs, and the answers that goes to the client.

For now all the calculations are made on the clients side ~~which is not quite right, but I had to mention that~~ and then client decides what to ask the server side about the file content.

It's all pretty raw and I guess it will comeout to something greater than that.

How to use it
========================
The usage of this is really simple. You have 2 options to choose from

* Server
* Client

Server option say to the program that it has to be answering on requests sent from client, and as you already might figured out, client sents these requests and gets responses.

To start working you have to host the server with the Directory and port textboxes filled. After you have the server up, you have to connect that one with a client. 

Client is a bit complicated.
Since the client do all the work about calcualating mismatches (atleast for now), it has more options that you have to deal with. on client you can choose do you want to download the files or upload them or both or none of them. You can choose what files has to be removed based on their existance on client or their existance on server or both or none of them, as well.
To connect to the server you have to insert the ip address that shown on the servers side (it's a local ip address).
You also can edit the timeout option. It's responsable for keeping connection even if server isnt responsing to the client (the time is in milliseconds). After the timeout it's throwing an exception about server not responding in time.

Contributing
========================
~~The project could not be commented well but I will be working on it~~

If you would like to make some stuff along with this code - feel free to use it, and even if you want to help me developing it I would be even more feeling better about this working. 
All the stuff I could say for now is just link to this guide about [How to contribute](https://github.com/firstcontributions/first-contributions) any stuff, and say that you have to write down all the things you've done.

I will be posting issues so, you could get one or several.

If you want to contribute, please send me a mail to Seagulmp3@gmail.com
