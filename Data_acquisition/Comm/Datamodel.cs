using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_acquisition.Comm
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class Datamodel
    {  //阶段号
        public int NUM { get; set; }
        //数据流
        public double[] DATA { get; set; }
        public Datamodel(int num, double[] data)
        {
            this.NUM = num; this.DATA = data;

        }
        public Datamodel() { }
    }
    public class Offmodel
    {
        //索引号
        public int index { get; set; }
        //是否启用 
        public bool active { get; set; }
        //幅度值
        public double value { get; set; }
        public Offmodel(int index, bool active, double value)
        {
            this.index = index; this.active = active; this.value = value;
        }
    }
}
