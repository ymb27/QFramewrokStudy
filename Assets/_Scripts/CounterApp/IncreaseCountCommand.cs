using QFramework.Example;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFramework.Example
{
    public class IncreaseCountCommand : AbstractCommand // ++
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterAppModel>().Count.Value++;
        }
    }
}
