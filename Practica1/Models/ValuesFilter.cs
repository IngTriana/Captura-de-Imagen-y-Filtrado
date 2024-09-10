using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace Practica1.Models
{
    public class ValuesFilter
    {
        public int VRmin
        {
            get => Properties.Settings.Default.VRmin;
            set => Properties.Settings.Default.VRmin = value;
        }
        public int VRmax
        {
            get => Properties.Settings.Default.VRmax;
            set => Properties.Settings.Default.VRmax = value;
        }
        public int VGmin
        {
            get => Properties.Settings.Default.VGmin;
            set => Properties.Settings.Default.VGmin = value;
        }
        public int VGmax
        {
            get => Properties.Settings.Default.VGmax;
            set => Properties.Settings.Default.VGmax = value;
        }
        public int VBmin
        {
            get => Properties.Settings.Default.VBmin;
            set => Properties.Settings.Default.VBmin = value;
        }
        public int VBmax
        {
            get => Properties.Settings.Default.VBmax;
            set => Properties.Settings.Default.VBmax = value;
        }
        
        static public void SaveData(string path)
        {
            ValuesFilter obj = new ValuesFilter();
            string stringdata = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, stringdata);
        }

        static public void LoadData(string path)
        {
            string stringdata = File.ReadAllText(path);
            ValuesFilter obj = JsonConvert.DeserializeObject<ValuesFilter>(stringdata);
        }
    }
}
