using UnityEngine;

namespace QFramework.StudyExamples
{
    public interface IEvent { }

    public struct EventA : IEvent
    {
        public int Count;
    }

    public struct EventB : IEvent
    {
        public int Count;
    }

    public class TypeEventSystemExample : MonoBehaviour, IOnEvent<EventA>, IOnEvent<EventB>
    {

        // Start is called before the first frame update
        void Start()
        {
            this.RegisterEvent<EventA>().UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<EventB>().UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TypeEventSystem.Global.Send(new EventA()
                {
                    Count = 10
                });
            }
            else if (Input.GetMouseButtonDown(1))
            {
                TypeEventSystem.Global.Send(new EventB()
                {
                    Count = -10
                });
            }
        }

        public void OnEvent(EventA e)
        {
            Debug.Log(e.Count);
        }

        public void OnEvent(EventB e)
        {
            Debug.Log(e.Count);
        }
    }
}
