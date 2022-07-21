import { Room, Client } from "colyseus";
import { MyRoomState } from "./schema/MyRoomState";

export class MyRoom extends Room<MyRoomState> {

  /**
   * Callback for when the room is created
   */
   async onCreate(options: any) {
    this.setState(new MyRoomState());

    this.onMessage("up", (client: Client, msg) => {
      console.log(msg);
      this.state.data = msg["Data"];
      client.send("up", msg);
    });
  }

  async onJoin(client: Client) {
    console.log(`${client.sessionId} joined...!`)
    setTimeout(() => {
      console.log("broadcasting...");
      this.broadcast("up", {Data: `${client.sessionId} joined..`})
    }, 2000);
  }

  //
  // Callback when a client has left the room
  // https://docs.colyseus.io/server/room/#onleave-client-consented
  //
  // Read about handling reconnection:
  // https://docs.colyseus.io/server/room/#allowreconnection-client-seconds
  //
  async onLeave(client: Client, consented: boolean) {
  }

  onDispose() {
    console.log("*********************** MyRoom disposed ***********************");
  }

}
