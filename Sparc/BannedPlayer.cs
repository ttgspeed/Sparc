using System;
using System.Net;

public class BannedPlayer
{
    string number, ipguid, minutesleft, reason;

    public BannedPlayer(string number, string ipguid, string minutesleft, string reason)
    {
        this.number = number;
        this.ipguid = ipguid;
        this.minutesleft = minutesleft;
        this.reason = reason;
    }

    public string getPlayerNumber()
    {
        return number;
    }

    public string getPlayerIPGUID()
    {
        return ipguid;
    }

    public string getPlayerMinutesLeft()
    {
        return minutesleft;
    }

    public string getPlayerReason()
    {
        return reason;
    }

    public string[] getPlayerInfo()
    {
        string[] playerinfo = new string[] { number, ipguid, minutesleft, reason };
        return playerinfo;
    }
}
