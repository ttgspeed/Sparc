using System;
using System.Net;

public class Admin
{
    string number, ip;

    public Admin(string number, string ip)
    {
        this.number = number;
        this.ip = ip;
    }

    public string getPlayerNumber()
    {
        return number;
    }

    public string getPlayerIP()
    {
        return ip;
    }

    public string[] getPlayerInfo()
    {
        string[] playerinfo = new string[] { number, ip };
        return playerinfo;
    }
}
