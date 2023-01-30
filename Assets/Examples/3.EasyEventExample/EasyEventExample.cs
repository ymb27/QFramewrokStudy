using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.StudyExamples
{
    public class EasyEventExample : MonoBehaviour
    {
        public EasyEvent EventA = new EasyEvent();
        public EasyEvent<int> OnCountChangedEvent = new EasyEvent<int>();

        // Start is called before the first frame update
        void Start()
        {
            EventA.Register(() =>
            {
                Debug.Log("EasyEvent Received");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            OnCountChangedEvent.Register(count =>
            {
                Debug.Log(count);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            EasyEvents.Register<EasyEvent<int, string, int>>();
            EasyEvents.Get<EasyEvent<int, string, int>>().Register((count, name, value) =>
            {
                Debug.Log(count + "," + name + "," + value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventA.Trigger();
                OnCountChangedEvent.Trigger(1);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                EasyEvents.Get<EasyEvent<int, string, int>>().Trigger(10, "test", 10);
            }
        }
    }
}