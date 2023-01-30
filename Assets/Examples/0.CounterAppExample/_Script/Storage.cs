using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QFramework.StudyExamples
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue = 0);
    }

    public class Storage : IStorage
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}
