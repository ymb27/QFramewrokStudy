

using UnityEngine;

namespace QFramework.StudyExamples
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            // 注册 Model
            this.RegisterModel<ICounterAppModel>(new CounterAppModel());
            this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

            this.RegisterUtility<IStorage>(new Storage());
        }

        protected override void ExecuteCommand(ICommand command)
        {
            Debug.Log("Before execute command: " + command.GetType().Name);
            base.ExecuteCommand(command);
            Debug.Log("After execute command: " + command.GetType().Name);
        }
    }
}
