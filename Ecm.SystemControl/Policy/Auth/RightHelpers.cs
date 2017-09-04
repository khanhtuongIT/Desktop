using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows;
namespace Ecm.SystemControl.Policy.Auth
{
    public class RightHelpers:   GoobizFrame.Windows.PlugIn.RightHelpers
    {
        Ecm.WebReferences.Classes.PolicyService objPolicyService = new Ecm.WebReferences.Classes.PolicyService();
        public Ecm.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new Ecm.WebReferences.PolicyService.Pol_Dm_Right();

        //public override bool Contains(string Right_Name)
        //{
        //    try
        //    {
        //        Ecm.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new Ecm.WebReferences.PolicyService.Pol_Dm_Right();
        //        Pol_Dm_Right.Right_System_Name = Right_Name;
        //        System.Data.DataSet dsPol_Dm_Right = objPolicyService.Pol_Dm_Right_Select_ByName(Pol_Dm_Right);
        //        return (dsPol_Dm_Right.Tables[0].Rows.Count > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //         GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
        //        return false;
        //    }
        //}

        //public override object Pol_Dm_Right_Insert(object Pol_Dm_Right)
        //{
        //    try
        //    {
        //        Ecm.WebReferences.PolicyService.Pol_Dm_Right v_Pol_Dm_Right = new Ecm.WebReferences.PolicyService.Pol_Dm_Right();

        //        v_Pol_Dm_Right.Right_System_Name = (( GoobizFrame.Windows.PlugIn.RightHelpers.Pol_Dm_Right)Pol_Dm_Right).Right_System_Name;
        //        v_Pol_Dm_Right.Right_Display_Name = (( GoobizFrame.Windows.PlugIn.RightHelpers.Pol_Dm_Right)Pol_Dm_Right).Right_Display_Name;
        //        v_Pol_Dm_Right.Right_Description = (( GoobizFrame.Windows.PlugIn.RightHelpers.Pol_Dm_Right)Pol_Dm_Right).Right_Description;

        //        return objPolicyService.Pol_Dm_Right_Insert(v_Pol_Dm_Right);
        //    }
        //    catch (Exception ex)
        //    {
        //         GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
        //        return null;
        //    }
        //}
    }
}
