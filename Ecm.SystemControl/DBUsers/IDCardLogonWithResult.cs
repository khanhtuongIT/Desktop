using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.DBUsers
{
    public partial class IDCardLogonWithResult : DevExpress.XtraEditors.XtraForm
    {
        Ecm.WebReferences.Classes.PolicyService objPolicy = new Ecm.WebReferences.Classes.PolicyService();
         GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config(@"Resources\Default\ActiveDirectoryLogon.config");
        public Actions Actions = new Actions();

        private object id_nhansu;
        public object Id_Nhansu
        {
            get { return id_nhansu; }
        }

        private object right_name;
        public object Right_System_Name
        {
            get { return right_name; }
            set { right_name = value; }
        }

        /// <summary>
        /// from Ecm.Policy.Auth.Converter
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public long Get_Id_User(string user_name)
        {
            Ecm.WebReferences.PolicyService.Pol_Dm_User Pol_Dm_User = new Ecm.WebReferences.PolicyService.Pol_Dm_User();
            Pol_Dm_User.User_Name = user_name;
            DataSet Pol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByName(Pol_Dm_User).ToDataSet();
            return Convert.ToInt64("" + Pol_Dm_User_Set.Tables[0].Rows[0]["Id_User"]);
        }

        /// <summary>
        /// from Ecm.Policy.Auth.Converter
        /// </summary>
        /// <param name="right_name"></param>
        /// <returns></returns>
        public long Get_Id_Right(string right_name)
        {
            Ecm.WebReferences.PolicyService.Pol_Dm_Right Pol_Dm_Right = new Ecm.WebReferences.PolicyService.Pol_Dm_Right();
            Pol_Dm_Right.Right_System_Name = right_name;
            DataSet Pol_Dm_Right_Set = objPolicy.Pol_Dm_Right_Select_ByName(Pol_Dm_Right).ToDataSet();
            return
                (Pol_Dm_Right_Set.Tables[0].Rows.Count > 0)
                ? Convert.ToInt64(Pol_Dm_Right_Set.Tables[0].Rows[0]["Id_Right"])
                : -1;
        }

        /// <summary>
        /// from Ecm.Policy.Auth.Authorization
        /// </summary>
        /// <param name="id_user"></param>
        /// <param name="id_right"></param>
        /// <returns></returns>
        public DataSet Get_Action_User(long id_user, long id_right)
        {
            Ecm.WebReferences.PolicyService.Pol_Action_User Pol_Action_User = new Ecm.WebReferences.PolicyService.Pol_Action_User();
            Pol_Action_User.Id_User = id_user;
            Pol_Action_User.Id_Right = id_right;
            return objPolicy.Pol_Action_User_Select_ByID_UserRight_ForAuth(Pol_Action_User).ToDataSet();
        }

        public IDCardLogonWithResult()
        {
            InitializeComponent();

            //background
            config.GroupName = "ActiveDirectoryLogon";
            panelBackground.ContentImage = Image.FromFile("" + config.GetValue("Bitmaps", "Background"));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LogOn()
        {
            try
            {
                if (textUser.Text.Trim() == "")
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] {
                            labelUser.Text});
                    return;
                }
                else
                {
                    string ma_nhansu = textUser.Text;
                    //Mã hóa password nếu password không rỗng
                    string user_password = "";
                    if (user_password != null && user_password != "")
                        user_password = SecurityManager.HashData(user_password);

                    DataSet dsPol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByMa_Nhansu(ma_nhansu).ToDataSet();
                    if (dsPol_Dm_User_Set.Tables[0].Rows.Count > 0)
                    {
                        string user_name = "" + dsPol_Dm_User_Set.Tables[0].Rows[0]["User_Name"];
                        id_nhansu = dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_Nhansu"];

                        long Id_Right = Get_Id_Right("" + right_name);
                        long Id_User = Get_Id_User(user_name);
                        DataSet Right_Pol_Dm_Action_Array = this.Get_Action_User(Id_User, Id_Right);
                        if (Right_Pol_Dm_Action_Array.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < Right_Pol_Dm_Action_Array.Tables[0].Rows.Count; j++)
                            {
                                if (!Actions.Contains("" + Right_Pol_Dm_Action_Array.Tables[0].Rows[j]["Action_Name"]))
                                    Actions.Add("" + Right_Pol_Dm_Action_Array.Tables[0].Rows[j]["Action_Name"]);
                            }
                        }

                        this.Close();
                    }
                    else
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00007", new string[] {
                            textUser.Text});
                }
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
        }

        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textUser.Text != "")
                LogOn();
        }

      
    }

    public class Actions : System.Collections.CollectionBase
    {
        public string this[int index]
        {
            get { return (string)List[index]; }
            set { List[index] = value; }
        }

        public int Add(string value)
        {
            return List.Add(value);
        }

        public bool Contains(string value)
        {
            return List.Contains(value);
        }

        public void CopyTo(string[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(string value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, string value)
        {
            List.Insert(index, value);
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }
    }
}