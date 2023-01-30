#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace QFramework.Example
{
    public class EditorCounterApp : EditorWindow,IController
    {

        [MenuItem("CounterApp/Window")]
        public static void Open()
        {
            var counterApp = GetWindow<EditorCounterApp>();
            counterApp.Show();
        }

        private ICounterAppModel mCounterAppModel;

        private void OnEnable()
        {
            mCounterAppModel = this.GetModel<ICounterAppModel>();
        }

        private void OnDisable()
        {
            mCounterAppModel = null;
        }

        private void OnGUI()
        {
            if(GUILayout.Button("+"))
            {
                this.SendCommand<IncreaseCountCommand>();
            }

            GUILayout.Label(mCounterAppModel.Count.Value.ToString());

            if(GUILayout.Button("-"))
            {
                this.SendCommand<DecreaseCountCommand>();
            }
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }
}
#endif