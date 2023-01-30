using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    // Controller
    public class CounterAppController : MonoBehaviour, IController
    {
        // View
        private Button mBtnAdd;
        private Button mBtnSub;
        private TextMeshProUGUI mCountText;

        // Model
        private ICounterAppModel mModel;


        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        void Start()
        {
            mModel = this.GetModel<ICounterAppModel>();

            // View 组件获取
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<TextMeshProUGUI>();


            // 监听输入
            mBtnAdd.onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand<IncreaseCountCommand>();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand<DecreaseCountCommand>();
            });

            mModel.Count.RegisterWithInitValue(count =>
            {
                UpdateView();
            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        void UpdateView()
        {
            mCountText.text = mModel.Count.ToString();
        }

        private void OnDestroy()
        {
            mModel = null;
        }
    }
}
