using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QFramework.Example
{
    public interface IAchievementSystem: ISystem
    {

    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem// +
    {
        protected override void OnInit()
        {
            var model = this.GetModel<ICounterAppModel>();

            model.Count.Register(count =>
            {
                if (count == 10)
                {
                    Debug.Log("触发 点击达人 成就");
                }
                else if (count == 20)
                {
                    Debug.Log("触发 点击专家 成就");
                }
                else if (count == -10)
                {
                    Debug.Log("触发 点击菜鸟 成就");
                }
            });
        }
    }
}
