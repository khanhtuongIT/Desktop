using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ecm.SystemControl.ModulesAdmin
{
    public partial class ModuleProperies : Form
    {
        System.Reflection.AssemblyName[] assemblyNames;
        private string assemblyName;
        public string AssemblyName
        {
            get { return assemblyName; }
            set 
            { 
                assemblyName = value;
                DisplayAssemblyDependences();
            }

        }
        
        public ModuleProperies()
        {
            InitializeComponent();
            if (!DesignMode)
                 GoobizFrame.Windows.MdiUtils.UserInterfaceHelper.UpdateButtonItems(barManager1);
        }

        private void DisplayAssemblyDependences()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(assemblyName);
            assemblyNames = assembly.GetReferencedAssemblies();

            dgModuleDetails.DataSource = assemblyNames;
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "item_Close":
                    this.Close();
                    break;

                case "item_RemoveAll":

                    break;
            }
        }
    }
}