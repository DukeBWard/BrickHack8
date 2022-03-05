using ModSynth.UI.WinUI.Rendering;
using System;

public class Program
{
    public async static void MainAsync()
    {
        AudioGraphRenderer renderer = new AudioGraphRenderer();
        Console.WriteLine("Initializing AudioGraph...");
        await renderer.InitializeAsync();
        Console.WriteLine("Done");
        Console.WriteLine("Playing...");
        renderer.Play();
    }

    public static void Main()
    {
        MainAsync();
        Console.ReadLine();
    }
}