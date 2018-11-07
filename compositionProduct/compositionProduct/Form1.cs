using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoodsmanDotNet;
using DataProvider;
using compositionProduct;

namespace compositionProduct
{
    public partial class Form1 : Form
    {
        IPluginCall iPluginCall;
        ArrProduct arrProd = new ArrProduct();
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IPluginCall i)
        {
            iPluginCall = i;
            InitializeComponent();
            infoAboutRootParent();
        }

        private void infoAboutRootParent()
        {
            int id = Convert.ToInt32(iPluginCall.RunMethod("CGetTreeSelectedIDs", new object[] { }));
            var info = iPluginCall.GetDataSet("GetInfoAboutVersion", new object[] { "","","",id,15}) as IDataSet;
            /// <data>
            /// Local fields
            /// <data>
            int version = Convert.ToInt32(info.FieldValue["_VERSION"]);
            string state = Convert.ToString(info.FieldValue["_STATE"]);
            string type = Convert.ToString(info.FieldValue["_TYPE"]);
            string product = Convert.ToString(info.FieldValue["_PRODUCT"]);
            int level = 0;
            Objects newObj = new Objects(id,version,product,type,state,level);
            arrProd.AddToArrProduct(newObj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repotToRtb();
        }

        private void repotToRtb()
        {
            foreach (Objects obj in arrProd.GetArr)
            {
                richTextBox1.AppendText(obj.Product);
            }
                      
        }

 
    }
}
