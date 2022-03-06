using ModSynth.UI.WinUI.Rendering;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.Presets.Abstract;
using System;

public class Program
{
    public async static void MainAsync()
    {
        AudioGraphRenderer renderer = new AudioGraphRenderer();
        Preset preset = new Preset3();
        renderer.Graph = preset.SynthGraph;
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
