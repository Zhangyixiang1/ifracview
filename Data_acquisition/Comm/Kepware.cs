using OPCAutomation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Comm
{ //Kepware相关类，初始化以及读取
    public class Kepware
    {      //kepware相关变量
        public OPCServer KepServer;
        public OPCGroups KepGroups;
        public OPCGroup KepGroup;
        public OPCItems KepItems;
        public OPCItem KepItem;
        public int[] Item_serverhandle1_To_PC = new int[65536];
        public int item_oder_To_PC = 1;
        public int item_oder = 1;
        public Array kepvalue;
        public Array keperr;
        public object kepqua;
        public object kepstamp;
        public bool kepconn;
        public bool kep_initial(string path, string devicesymbol)
        {
            try
            {

                int num = path.LastIndexOf("\\Config");
                string device = path.Substring(num + 8);

                KepServer = new OPCServer();
                ////连接opc server
                KepServer.Connect("KEPware.KEPServerEx.V4", "");
                //(2)建立一个opc组集合
                KepGroups = KepServer.OPCGroups;
                //(3)建立一个opc组
                KepGroup = KepGroups.Add(null); //Group组名字可有可无
                //(4)添加opc标签
                KepGroup.IsActive = true; //设置该组为活动状态，连接PLC时，设置为非活动状态也一样
                KepGroup.IsSubscribed = true; //设置异步通知
                KepGroup.UpdateRate = 250;
                KepServer.OPCGroups.DefaultGroupDeadband = 0;
                KepItems = KepGroup.OPCItems; //建立opc标签集合

                //string path = System.Environment.CurrentDirectory;
                StreamReader sr = new StreamReader(path);
                string content = sr.ReadToEnd();
                string[] str = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                //混砂车标注名处理
                if (devicesymbol == "B")
                {
                    foreach (object temp0 in str)
                    {
                        string temp1 = temp0.ToString();
                        string temp = temp1.Replace("\t", "");
                        KepItems.AddItem("iFrac.Blender." + temp.ToString(), item_oder);
                        Item_serverhandle1_To_PC[item_oder_To_PC] = KepItems.Item(item_oder).ServerHandle;
                        item_oder_To_PC = item_oder_To_PC + 1;
                        item_oder = item_oder + 1;

                    }


                }
                //压力泵标注名处理
                if (devicesymbol == "F")
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        string temp1 = str[i].ToString();
                        string temp = temp1.Replace("\t", "");
                        int num1 = i / 5 + 1; int num2 = i % 5 + 1;
                        KepItems.AddItem("iFrac_F" + num1.ToString("00") + ".Frac.var" + num2, item_oder);


                        Item_serverhandle1_To_PC[item_oder_To_PC] = KepItems.Item(item_oder).ServerHandle;
                        item_oder_To_PC = item_oder_To_PC + 1;
                        item_oder = item_oder + 1;

                    }

                }
                //0512 状态信号和ip地址
                if (devicesymbol == "S")
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        string temp1 = str[i].ToString();
                        string temp = temp1.Replace("\t", "");
                       
                        KepItems.AddItem(temp, item_oder);
                        Item_serverhandle1_To_PC[item_oder_To_PC] = KepItems.Item(item_oder).ServerHandle;
                        item_oder_To_PC = item_oder_To_PC + 1;
                        item_oder = item_oder + 1;

                    }
                }



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Array kep_read()
        {
            kepvalue = new Array[KepItems.Count];
            keperr = new Array[KepItems.Count];
            Array handle2 = (Array)Item_serverhandle1_To_PC;
            KepGroup.SyncRead(1, KepItems.Count, ref handle2, out kepvalue, out keperr, out kepqua, out kepstamp);
            return kepvalue;

        }
    }

}

