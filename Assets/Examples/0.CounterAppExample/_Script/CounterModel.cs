using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.StudyExamples
{
    public interface ICounterAppModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterAppModel : AbstractModel, ICounterAppModel
    {
        public BindableProperty<int> Count { get; } = new BindableProperty<int>(0);

        protected override void OnInit()
        {
            var storage = new Storage();
            Count.Value = storage.LoadInt(nameof(Count), 0);

            Count.Register(count =>
            {
                storage.SaveInt(nameof(Count), count);
            });
        }
    }
}


