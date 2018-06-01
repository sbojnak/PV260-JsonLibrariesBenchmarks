using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }
    
        [Benchmark]
        public Root NewtonsoftJson_DeserializeStream()
        {

            using (Stream s = new FileStream(JsonPath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<Root>(reader);
            }
        }

        [Benchmark]
        public Root DeserializeJson_DifferentLibrary()
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<Root>(JsonSampleString);
        }
    }
}
