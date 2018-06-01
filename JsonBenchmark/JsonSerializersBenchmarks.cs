using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using ServiceStack.Text;
using JsonSerializer = ServiceStack.Text.JsonSerializer;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonSerializersBenchmarks : JsonBenchmarkBase
    {
        private Root jsonRoot;
        private Root myJsonRoot;

        public JsonSerializersBenchmarks()
        {
            jsonRoot = JsonConvert.DeserializeObject<Root>(JsonSampleString);
            myJsonRoot = JsonConvert.DeserializeObject<Root>(MyJsonSampleString);
        }
        
        [Benchmark]
        public string NewtonsoftJson_Serialize()
        {
            return JsonConvert.SerializeObject(jsonRoot);
        }

        [Benchmark]
        public string NewtonsoftJson_SerializeMyJson()
        {
            return JsonConvert.SerializeObject(myJsonRoot);
        }

        [Benchmark]
        public string Json_DifferenetSerialize()
        {
            return JsonSerializer.SerializeToString(jsonRoot);

        }

    }
}
