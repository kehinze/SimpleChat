using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace SimpleChat.Api.Controllers
{
    [DataContract(Name = "TestEvent")]
    public class TestEvent
    {
        [DataMember(Name = "TestMessage")]
        public string TestMessage { get; set; }
    }

    public class TestController : ApiController
    {
        [Route("api/Test")]
        public HttpResponseMessage GetTest()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Message = "Web api up and running"
            });
        }

        [Route("api/TestBroadcastToUi")]
        public HttpResponseMessage GetTestBroadcastToUi()
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<Hubs.ChatHub>();

            var testEvent = new TestEvent()
            {
                TestMessage = "Hello"
            };

            hub.Clients.All.RaiseEvent(new 
                {
                    Type = testEvent.GetType().Name,
                    Body = testEvent
                });

            return Request.CreateResponse(HttpStatusCode.OK, testEvent);
        }
    }
}