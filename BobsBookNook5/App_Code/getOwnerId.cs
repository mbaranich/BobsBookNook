﻿using System;


/// <summary>
/// Summary description for getOwnerId
/// </summary>
public class getOwnerId
{
    public getOwnerId()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string getID(string uploadPath)
    {
        string ownerID;

        try
        {
            ownerID = System.IO.File.ReadAllText(uploadPath + "ownerID.txt");
            ownerID = ownerID.Replace("\r\n", "");
            return (ownerID);
        }
        catch { return ("");  }
    }
}