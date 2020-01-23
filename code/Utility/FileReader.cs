using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongReader
{
    public SongReader(string fileName)
    {
        Reader = new StreamReader(fileName);
    }

    public void ReadSongTiming(ref List<float> Out)
    {
        if (Reader != null)
        {
            Out = new List<float>();

            string line;

            while ((line = Reader.ReadLine()) != null)
            {
                Out.Add(float.Parse(line));
            }
        }
    }

    public void ReadSongIndex(ref List<int> Out)
    {
        if (Reader != null)
        {
            Out = new List<int>();

            string line;

            while ((line = Reader.ReadLine()) != null)
            {
                Out.Add(int.Parse(line));
            }
        }
    }

    StreamReader Reader;
}
