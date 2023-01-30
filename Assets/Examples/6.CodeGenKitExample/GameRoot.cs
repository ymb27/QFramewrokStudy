using UnityEngine;
using QFramework;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace QFramework.StudyExamples
{
    public partial class GameRoot : ViewController
    {
        void Start()
        {
            // Code Here
            Player.Bag.transform.localPosition = new Vector3(1, 1, 1);
        }
    }
}
