using Data_acquisition;
using Data_acquisition.Ctrl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Data_acquisiton
{


    class MultiLanguage
    {
        public static string DefaultLanguage = "ChineseSimplified";

        /// <summary>  
        /// 从XML文件中读取需要修改Text的內容  
        /// </summary>  
        /// <param name="frmName">窗口名，用于获取对应窗口的那部分内容</param>  
        /// <param name="lang">目标语言</param>  
        /// <returns></returns>  
        private static Hashtable ReadXMLText(string frmName, string lang)
        {
            try
            {
                Hashtable hashResult = new Hashtable();
                XmlReader reader = null;
                //判断是否存在该语言的配置文件  
                if (!(new System.IO.FileInfo("Languages/" + lang + ".xml")).Exists)
                {
                    return null;
                }
                else
                {
                    reader = new XmlTextReader("Languages/" + lang + ".xml");
                }
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(reader);
                XmlNode root = doc.DocumentElement;
                //获取XML文件中对应该窗口的内容  
                XmlNodeList nodeList = root.SelectNodes("Form[Name='" + frmName + "']/Controls/Control");
                foreach (XmlNode node in nodeList)
                {
                    try
                    {
                        //修改内容为控件的Text值  
                        XmlNode node1 = node.SelectSingleNode("@name");
                        XmlNode node2 = node.SelectSingleNode("@text");
                        if (node1 != null)
                        {
                            hashResult.Add(node1.InnerText, node2.InnerText);
                        }
                    }
                    catch { }
                }
                reader.Close();
                // reader.Dispose();
                return hashResult;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>  
        /// 加载语言  
        /// </summary>  
        /// <param name="form">加载语言的窗口</param>  
        public static void LoadLanguage(Form form, string lan)
        {
            //获取当前默认语言  
            string language = lan;
            //根据用户选择的语言获得表的显示文字   
            Hashtable hashText = ReadXMLText(form.Name, language);
            if (hashText == null)
            {
                return;
            }
            //获取当前窗口的所有控件  
            Control.ControlCollection sonControls = form.Controls;
            try
            {
                //遍历所有控件  
                foreach (Control control in sonControls)
                {
                    if (control.GetType() == typeof(Panel))     //Panel  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(GroupBox))     //GroupBox  
                    {
                        GetSetSubControls(control.Controls, hashText);

                    }
                    else if (control.GetType() == typeof(TabControl))       //TabControl  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TabPage))      //TabPage  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(Parashow))
                    {
                        Parashow pr = control as Parashow;
                        if (Form_Main.lan == "English")
                            pr.label1.Text = pr.Tagname_EN;
                        else if (Form_Main.lan == "Chinese")
                            pr.label1.Text = pr.Tagname;
                    }
                    else if (control.GetType() == typeof(ParaLine))
                    {
                        ParaLine pr = control as ParaLine;
                        if (Form_Main.lan == "English")
                        {
                            pr.label1.Text = pr.Tagname_EN;
                            pr.label1.Font = new System.Drawing.Font("宋体", 10F);
                        }
                        else if (Form_Main.lan == "Chinese")
                           { pr.label1.Text = pr.Tagname;
                           pr.label1.Font = new System.Drawing.Font("宋体", 15F);
                           }
                    }
                    else if(control.GetType() == typeof(Parashownew))
                    {
                        Parashownew pr = control as Parashownew;
                        if (Form_Main.lan == "English")
                            pr.label1.Text = pr.Tagname_EN;
                        else if (Form_Main.lan == "Chinese")
                            pr.label1.Text = pr.Tagname;
                    }
                    else if (control.GetType() == typeof(MenuStrip))   //MenuStrip
                    {
                        MenuStrip ms = control as MenuStrip;
                        foreach (ToolStripMenuItem item in ms.Items)
                        {
                            item.Text = (string)hashText[item.Name];
                            for (int i = 0; i < item.DropDownItems.Count; i++)
                            {
                                item.DropDownItems[i].Text = (string)hashText[item.DropDownItems[i].Name];
                            }
                        }
                    }
                    else if (control.GetType() == typeof(StatusStrip))   //StatusStrip
                    {
                        StatusStrip ms = control as StatusStrip;
                        foreach (ToolStripItem item in ms.Items)
                        {
                            if (!string.IsNullOrEmpty((string)hashText[item.Name]))
                                item.Text = (string)hashText[item.Name];
                        }
                    }
                    if (hashText.Contains(control.Name))
                    {
                        control.Text = (string)hashText[control.Name];
                    }
                }
                if (hashText.Contains(form.Name))
                {
                    form.Text = (string)hashText[form.Name];
                }
            }
            catch { }
        }

        /// <summary>  
        /// 获取并设置控件中的子控件  
        /// </summary>  
        /// <param name="controls">父控件</param>  
        /// <param name="hashResult">哈希表</param>  
        private static void GetSetSubControls(Control.ControlCollection controls, Hashtable hashText)
        {
            try
            {
                foreach (Control control in controls)
                {
                    if (control.GetType() == typeof(Panel))     //Panel  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(GroupBox))     //GroupBox  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TabControl))       //TabControl  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TabPage))      //TabPage  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    if (hashText.Contains(control.Name))
                    {
                        control.Text = (string)hashText[control.Name];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
