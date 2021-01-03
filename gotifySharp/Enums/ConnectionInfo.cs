using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Enums
{
    public static class ConnectionInfo
    {
        public enum WebsocketReconnectStatus
        {
            //
            // Summary:
            //     Type used for initial connection to websocket stream
            Initial = 0,
            //
            // Summary:
            //     Type used when connection to websocket was lost in meantime
            Lost = 1,
            //
            // Summary:
            //     Type used when connection to websocket was lost by not receiving any message
            //     in given time-range
            NoMessageReceived = 2,
            //
            // Summary:
            //     Type used after unsuccessful previous reconnection
            Error = 3,
            //
            // Summary:
            //     Type used when reconnection was requested by user
            ByUser = 4,
            //
            // Summary:
            //     Type used when reconnection was requested by server
            ByServer = 5,
            //
            //Summary:
            //     Type used when the connection succeeds
            Successful = 6
        }

        public enum WebsocketDisconnectStatus
        {
            //
            // Summary:
            //     Type used for initial connection to websocket stream
            Exit = 0,
            //
            // Summary:
            //     Type used when connection to websocket was lost in meantime
            Lost = 1,
            //
            // Summary:
            //     Type used when connection to websocket was lost by not receiving any message
            //     in given time-range
            NoMessageReceived = 2,
            //
            // Summary:
            //     Type used after unsuccessful previous reconnection
            Error = 3,
            //
            // Summary:
            //     Type used when reconnection was requested by user
            ByUser = 4,
            //
            // Summary:
            //     Type used when reconnection was requested by server
            ByServer = 5,
            //
            //Summary:
            //     Type used when the connection succeeds
            Successful = 6
        }
    }
}
