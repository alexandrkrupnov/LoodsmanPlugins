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

        private void getLinkedObjects2()
        {
            //int id = arrProd.GetArr[0].IdVersion;
            var tree = iPluginCall.GetDataSet("GetLinkedObjects2", new object[] { arrProd.GetArr[0].IdVersion, "Состоит из ...",false,true,true}) as IDataSet;
            int id;
            string type;
            string product;
            while (tree.Eof == false)
            {
                switch (Convert.ToInt32(tree.FieldValue["_ID_TYPE"]))
                {
                    case 38:
                        type = "Материал по КД";
                        break;
                    case 64:
                        type = "Комплекс";
                        break;
                    case 65:
                        type = "Сборочная единица";
                        break;                        
                    case 66:
                        type = "Деталь";
                        break;
                    case 67:
                        type = "Комплект";
                        break;
                    case 68:
                        type = "Стандартное изделие";
                        break;
                    case 70:
                        type = "Прочее изделие";
                        break;

                }
                richTextBox1.AppendText(Convert.ToString(tree.FieldValue["_PRODUCT"]));
                richTextBox1.AppendText(Convert.ToString(tree.FieldValue["_PRODUCT"]));
                richTextBox1.AppendText(Convert.ToString(tree.FieldValue["_PRODUCT"]));
                richTextBox1.AppendText(Convert.ToString(tree.FieldValue["_PRODUCT"]));
                tree.Next();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getLinkedObjects2();
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
