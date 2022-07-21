# Disposable Message Callbacks for Unity SDK - Testing

### Steps
1. Run Server -> `npm install && npm start`
2. Run Client -> Open client in as a Unity project and import Colyseus Unity SDK, then build and run.
3. Click Join Room button.
4. Click Send message button. This will send a message to the server and message will be bounced back to clients, there will be two message listeners. You will be able to see the logs.
5. Click Dispose Message Listner button and try again with Send Message button.

