using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        protected const string TestFilesFolder = "TestFiles";
        protected string JsonSampleString;
        protected string MyJsonSampleString;
        protected string JsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
        protected string MyJsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "myjson.json");

        protected JsonBenchmarkBase()
        {
            JsonSampleString = File.ReadAllText(JsonPath);

            MyJsonSampleString = File.ReadAllText(MyJsonPath);

        }
    }
}
