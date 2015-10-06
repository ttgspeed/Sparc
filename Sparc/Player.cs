using System;
using System.Net;

public class Player
{
    string host, number, ip, ping, guid, name;
    DateTime time;
    bool lobby;

	public Player(string host, string number, string ip, string ping, string guid, string name, bool lobby)
	{
        this.host = host;
        this.number = number;
        this.ip = ip;
        this.ping = ping;
        this.guid = guid;
        this.name = name;
        this.lobby = lobby;
        this.time = DateTime.Now;
	}

    public string getPlayerHost()
    {
        return host;
    }

    public string getPlayerNumber()
    {
        return number;
    }

    public string getPlayerIP()
    {
        return ip;
    }

    public string getPlayerPing()
    {
        return ping;
    }

    public string getPlayerGuid()
    {
        return guid;
    }

    public string getPlayerName()
    {
        return name;
    }

    public string getPlayerStatus()
    {
        return (lobby) ? "Lobby (" + DateTime.Now.ToString("HH:mm") +")": "In Game";
    }

    public DateTime getPlayerTime()
    {
        return time;
    }

    public string[] getPlayerInfo()
    {
        string[] playerinfo = new string[] { number, name, getPlayerStatus(), guid, ip, ping };
        return playerinfo;
    }

    public void setPlayerTime()
    {
        this.time = DateTime.Now;
    }
}
