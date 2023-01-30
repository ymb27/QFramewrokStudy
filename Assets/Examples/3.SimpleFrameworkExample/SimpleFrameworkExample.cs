using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class SimpleFrameworkExample : MonoBehaviour
    {
        #region Framework
        public interface ICommand
        {
            void Execute();
        }

        public class BindableProperty<T>
        {
            private T mValue = default;
            public T Value
            {
                get => mValue;
                set
                {
                    if (mValue != null && mValue.Equals(value)) return;
                    mValue = value;
                    OnValueChanged?.Invoke(mValue);
                }
            }

            public event Action<T> OnValueChanged = _ => { };
        }
        #endregion

        #region Model
        public static class CounterModel
        {
            public static BindableProperty<int> Counter = new BindableProperty<int>()
            {
                Value = 0
            };
        }
        #endregion

        #region Command
        public struct IncreaseCommand : ICommand
        {
            public void Execute()
            {
                CounterModel.Counter.Value++;
            }
        }

        public struct DecreaseCommand : ICommand
        {
            public void Execute()
            {
                CounterModel.Counter.Value--;
            }
        }
        #endregion

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                new IncreaseCommand().Execute();
            }

            GUILayout.Label(CounterModel.Counter.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new DecreaseCommand().Execute();
            }
        }
    }
}