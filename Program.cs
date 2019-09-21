using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;

[Serializable]
public class VoteInfo
{
    public VoteInfo()
    {
        Answers = new int[0];
    }
    public VoteInfo(int answerCount)
    {
        Answers = new int[answerCount];
    }
    public int TotalVotes { get; set; }
    public bool Final { get; set; }
    public bool AllVotesReceived { get; set; }
    public bool ShowAbsResults { get; set; }
    public int NotAnsweredCount { get; set; }
    public int[] Answers { get; set; }
}

public static class VoteSerializer
{

    public static void SerializerToJson(IList<VoteInfo> votes)
    {
        var serializedJson = JsonConvert.SerializeObject(votes);
    }

    public static void SerializeToByte(IList<VoteInfo> votes)
    {
        IFormatter formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, votes);
            stream.Flush();
            stream.Position = 0;
        }

    }

}

[MemoryDiagnoser]
public class VoteSerializerBenchmarks
{

    readonly List<VoteInfo> Votes = new List<VoteInfo>();
    [Benchmark]
    public void SerializerToJson()
    {
        VoteSerializer.SerializerToJson(Votes);
    }

    [Benchmark]
    public void SerializeToByte()
    {
        VoteSerializer.SerializeToByte(Votes);
    }
}

namespace Benchmarkdotnet_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<VoteSerializerBenchmarks>();
        }
    }
}
