using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProvider;
using LoodsmanDotNet;
using System.Windows.Forms;

namespace compositionProduct
{
    class Objects
    {
        //properties -> only get
        int idVersion;
        int version;
        string product;
        string type;
        string state;
        int level;

        //automatic properties



        public Objects(int id, int ver, string prod, string tp, string st, int lvl)
        {
            idVersion = id;
            version = ver;
            product = prod;
            type = tp;
            state = st;
            level = lvl;
        }


        public int IdVersion
        {
            get { return idVersion; }
        }
        
        public int Version
        {
            get { return version; }
        }

        public string Product
        {
            get { return product; }
        }

        public string Type
        {
            get { return type; }
        }

        public string State
        {
            get { return state; }
        }

        public int Level
        {
            get { return level; }
        }

    }

    class ArrProduct
    {
        List<Objects> arr = new List<Objects>();

        public ArrProduct()
        {

        }

        public List<Objects> GetArr
        {
            get {return arr; }
        }

        public void AddToArrProduct(Objects obj)
        {
            arr.Add(obj);
        }
    }


}
