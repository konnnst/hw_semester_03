﻿using System;
using System.IO;

namespace Client;

public class Commands
{
    public static string Get(string path)
    {
        var response = "";

        if (!File.Exists(path))
        {
            response = "-1\n";
        }
        else
        {
            var file = new FileInfo(path);

            response += $"{file.Length}\n";
            foreach (var bytePiece in File.ReadAllBytes(path))
            {
                response += $"{bytePiece} ";
            }
        }

        return response;
    }

    public static string List(string path)
    {
        var response = "";
        if (!Directory.Exists(path))
        {
            response = "-1\n";
        }
        else
        {
            var files = Directory.GetFiles(path);
            var directories = Directory.GetDirectories(path);

            response += $"{files.Count() + directories.Count()}\n";

            foreach (var fileName in files)
            {
                response += $"f {fileName}\n";
            }

            foreach (var directoryName in directories)
            {
                response += $"d {directoryName}\n";
            }
        }

        return response;
    }
}

public class ClientTerminal
{
    public void RunClient()
    {
        var parser = new Parser();
        var run = 1;
        while (run == 1)
        {
            Console.Write("simple_ftp > ");
            var command = Console.ReadLine();
            Console.WriteLine(command);
        }
    }
}

internal class MyClient
{
    static void Main()
    {
        var client = new ClientNetwork();
        client.SendMessage();
        Console.ReadKey();
    } 
}