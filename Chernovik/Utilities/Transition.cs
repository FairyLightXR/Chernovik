using Chernovik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chernovik.Utilities
{
    internal class Transition
    {
        public static Frame MainFrame { get; set; }

        private static ChernovikDBEntities datacontext;
        public static ChernovikDBEntities DataContext
        {
            get
            {
                if (datacontext == null)
                    datacontext = new ChernovikDBEntities();

                return datacontext;
            }
        }
    }
}
