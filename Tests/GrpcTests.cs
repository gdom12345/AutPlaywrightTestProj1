
using AutPlaywrightTestProj.PageObjects;
using Grpc.Net.Client;
using GrpcService1;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Legacy;

namespace AutPlaywrightTestProj
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class GrpcTests 
    {
        private Greeter.GreeterClient greeterClient;

        [SetUp]
        public async Task Setup()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5209");
            greeterClient = new Greeter.GreeterClient(channel);
        }
        //to use click and record feature
        //run powershell as admin
        //cd C:\Users\domGi\source\repos\AutPlaywrightTestProj\AutPlaywrightTestProj\bin\Debug\net10.0
        //Set-ExecutionPolicy -ExecutionPolicy RemoteSigned
        //./playwright.ps1 codegen http://eaapp.somee.com

        [Test]
        public async Task GrpcTest()
        {
            var input = new HelloRequest() { Name = "Dominic" };
            var response = greeterClient.SayHelloAsync(input);

            Assert.That(response.ResponseAsync.Result.Message, Is.EqualTo($"Hello {input.Name}"));
        }
    }
}
