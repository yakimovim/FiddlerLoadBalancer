using System;
using Fiddler;

[assembly: RequiredVersion("2.2.8.6")]

namespace FiddlerLoadBalancer
{
    public class Balancer : IAutoTamper
    {
        private string[] _hosts;
        private Random _rnd;

        public void OnLoad()
        {
            _rnd = new Random((int)DateTime.UtcNow.Ticks);
            _hosts = new[]
                     {
                         "your-host-name:9091",
                         "your-host-name:9092",
                     };
        }

        public void OnBeforeUnload()
        {}

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (_hosts != null && (oSession.host == "your-host-name" || oSession.host == "your-host-name:80"))
            {
                oSession.host = _hosts[_rnd.Next(0, _hosts.Length)];
            }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {}

        public void AutoTamperResponseBefore(Session oSession)
        {}

        public void AutoTamperResponseAfter(Session oSession)
        {}

        public void OnBeforeReturningError(Session oSession)
        {}
    }
}
