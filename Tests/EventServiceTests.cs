using NUnit.Framework;
using Services;
namespace Tests
{
    public class EventServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddEventTest()
        {
            var eventService = new EventService();
            Assert.That(eventService.AddEvent(), Is.Not.Null);
        }
    }
}