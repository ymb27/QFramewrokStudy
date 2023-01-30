using QFramework;
using UnityEngine;

namespace QFramework.StudyExamples
{
    public class IOCContainerExample : MonoBehaviour
    {
        public class SomeService
        {
            public void Say()
            {
                Debug.Log("SomeService.Say: Hi");
            }
        }

        public interface INetworkService
        {
            void Connect();
        }

        public class NetworkService : INetworkService
        {
            public void Connect()
            {
                Debug.Log("NetworkService.Connect: Success");
            }
        }

        void Start()
        {
            var container = new IOCContainer();
            container.Register(new SomeService());
            container.Register<INetworkService>(new NetworkService());

            container.Get<SomeService>().Say();
            container.Get<INetworkService>().Connect();
        }
    }
}
