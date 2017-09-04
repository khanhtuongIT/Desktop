using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

using Ecm.Service;
using Ecm.Service.Pol;

namespace Ecm.Webservice
{
    

    /// <summary>
    /// Summary description for PolicyService
    /// </summary>
    [WebService(Namespace = "Ecm.PolicyServices.PolicyService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class PolicyService : System.Web.Services.WebService
    {
        System.Data.OleDb.OleDbConnection sqlMapper;

        #region Khai báo các đối tượng service - Pol
        Pol_Dm_User_Service _Pol_Dm_User_Service;
        Pol_Dm_Role_Service _Pol_Dm_Role_Service;
        Pol_Dm_Right_Service _Pol_Dm_Right_Service;
        Pol_Dm_Action_Service _Pol_Dm_Action_Service;
        Pol_Action_Role_Service _Pol_Action_Role_Service;
        Pol_Action_User_Service _Pol_Action_User_Service;
        Pol_Role_Right_Service _Pol_Role_Right_Service;
        Pol_User_Right_Service _Pol_User_Right_Service;
        Pol_User_Role_Service _Pol_User_Role_Service;
        Rex_Nhansu_Service _Rex_Nhansu_Service;
        #endregion //Khai báo các đối tượng service - Pol

        Ecm.Service.Ware.DocumentProcessStatus_Service _DocumentProcessStatus_Service;

        public PolicyService()
        {
            sqlMapper = DbConnection.OleDbConnection;

            #region Khởi tạo các đối tượng service - Pol
            _Pol_Dm_User_Service = new Pol_Dm_User_Service(sqlMapper);
            _Pol_Dm_Role_Service = new Pol_Dm_Role_Service(sqlMapper);
            _Pol_Dm_Right_Service = new Pol_Dm_Right_Service(sqlMapper);
            _Pol_Dm_Action_Service = new Pol_Dm_Action_Service(sqlMapper);
            _Pol_Action_Role_Service = new Pol_Action_Role_Service(sqlMapper);
            _Pol_Action_User_Service = new Pol_Action_User_Service(sqlMapper);
            _Pol_Role_Right_Service = new Pol_Role_Right_Service(sqlMapper);
            _Pol_User_Right_Service = new Pol_User_Right_Service(sqlMapper);
            _Pol_User_Role_Service = new Pol_User_Role_Service(sqlMapper);
            _Rex_Nhansu_Service = new Rex_Nhansu_Service(sqlMapper);
            #endregion //Khởi tạo các đối tượng service - Pol
            _DocumentProcessStatus_Service = new Ecm.Service.Ware.DocumentProcessStatus_Service(sqlMapper);
        }

        #region Pol - Webmethod
        #region Người dùng (User)
        [WebMethod(Description = "Trả về danh sách người dùng (trong một mảng) Pol_Dm_User_Collection")]
        public string Get_Pol_Dm_User_Collection3()
        {
            return _Pol_Dm_User_Service.Get_Pol_Dm_User_Collection();
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện id_user, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByID(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByID(Pol_Dm_User);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện user_name, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByName(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByName(Pol_Dm_User);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện user_name và user_password, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByAuth(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByAuth(Pol_Dm_User);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Dm_User vào bảng pol_dm_user")]
        public object Pol_Dm_User_Insert(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Insert(Pol_Dm_User);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Update(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Update(Pol_Dm_User);
        }

        [WebMethod(Description = "Cập nhật mật khẩu của một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Password_Update(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Password_Update(Pol_Dm_User);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Delete(Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Delete(Pol_Dm_User);
        }

        #endregion //Người dùng (User)

        #region Nhóm quyền (Role)
        [WebMethod(Description = "Trả về danh sách nhóm quyền (trong một mảng) Pol_Dm_Role_Collection")]
        public string Get_Pol_Dm_Role_Collection3()
        {
            return _Pol_Dm_Role_Service.Get_Pol_Dm_Role_Collection();
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Role trong bảng pol_dm_role theo điều kiện id_role, trả về danh sách nhóm quyền (trong một mảng) Pol_Dm_Role_Collection")]
        public string Pol_Dm_Role_Select_ByID(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Select_ByID(Pol_Dm_Role);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Dm_Role vào bảng pol_dm_role")]
        public object Pol_Dm_Role_Insert(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Insert(Pol_Dm_Role);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_Role trong bảng pol_dm_role")]
        public object Pol_Dm_Role_Update(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Update(Pol_Dm_Role);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_Role trong bảng pol_dm_role")]
        public object Pol_Dm_Role_Delete(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Delete(Pol_Dm_Role);
        }

        [WebMethod(Description = "cập nhật một dataset DataSet_Pol_Dm_Role vào trong bảng pol_dm_role")]
        public object Update_Pol_Dm_Role_Collection(DataSet ds_Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Update_Pol_Dm_Role_Collection(ds_Pol_Dm_Role);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Role trong bảng pol_dm_role theo điều kiện role_name, trả về danh sách nhóm quyền (trong một mảng) Pol_Dm_Role_Collection")]
        public string Select_Pol_Dm_Role_ByName(Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role)
        {
            return _Pol_Dm_Role_Service.Select_Pol_Dm_Role_ByName(Pol_Dm_Role);
        }
        #endregion //Nhóm quyền (Role)

        #region Quyền (Right)

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Right trong bảng pol_dm_right theo điều kiện id_right, trả về danh sách quyền (trong một mảng) Pol_Dm_Right_Collection")]
        public string Pol_Dm_Right_Select_ByID(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Select_ByID(Pol_Dm_Right);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Right trong bảng pol_dm_right theo điều kiện right_name, trả về danh sách quyền (trong một mảng) Pol_Dm_Right_Collection")]
        public string Pol_Dm_Right_Select_ByName(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Select_ByName(Pol_Dm_Right);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Dm_Right vào bảng pol_dm_right")]
        public object Pol_Dm_Right_Insert(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Insert(Pol_Dm_Right);
        }


        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_Right trong bảng pol_dm_right")]
        public object Pol_Dm_Right_Update(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Update(Pol_Dm_Right);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_Right trong bảng pol_dm_right")]
        public object Pol_Dm_Right_Delete(Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Delete(Pol_Dm_Right);
        }

        [WebMethod(Description = "cập nhật một dataset Pol_Dm_Right vào trong bảng pol_dm_right")]
        public object Update_Pol_Dm_Right_Collection(DataSet ds_Pol_Dm_Right)
        {
            return _Pol_Dm_Right_Service.Update_Pol_Dm_Right_Collection(ds_Pol_Dm_Right);
        }
        #endregion //Quyền (Right)

        #region Thao tác (Action)

        [WebMethod(Description = "Trả về danh sách thao tác được Serialize thành DataSet")]
        public string Get_Pol_Dm_Action_Collection3()
        {
            return _Pol_Dm_Action_Service.Get_Pol_Dm_Action_Collection();
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Dm_Action vào bảng pol_dm_action")]
        public object Pol_Dm_Action_Insert(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            return _Pol_Dm_Action_Service.Pol_Dm_Action_Insert(Pol_Dm_Action);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_Action trong bảng pol_dm_action")]
        public object Pol_Dm_Action_Update(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            return _Pol_Dm_Action_Service.Pol_Dm_Action_Update(Pol_Dm_Action);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_Action trong bảng pol_dm_action")]
        public object Pol_Dm_Action_Delete(Ecm.Domain.Pol.Pol_Dm_Action Pol_Dm_Action)
        {
            return _Pol_Dm_Action_Service.Pol_Dm_Action_Delete(Pol_Dm_Action);
        }

        [WebMethod(Description = "cập nhật một dataset DataSet_Pol_Dm_Action vào trong bảng pol_dm_action")]
        public object Update_Pol_Dm_Action_Collection(DataSet ds_Pol_Dm_Action)
        {
            return _Pol_Dm_Action_Service.Update_Pol_Dm_Action_Collection(ds_Pol_Dm_Action);
        }
        #endregion //Thao tác (Action)

        #region Người dùng trong nhóm quyền (User in Role)

        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_user, trả về danh sách nhóm quyền được Serialize thành DataSet")]
        public string Select_Pol_User_Role_ByIDUser3(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Pol_User_Role_Select_ByIDUser(Pol_User_Role);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_role, trả về danh sách người dùng (trong một mảng) Pol_Dm_User_Collection")]
        public string Select_Pol_User_Role_ByIDRole1(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Pol_User_Role_Select_ByIDRole(Pol_User_Role);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_role, trả về danh sách người dùng được Serialize thành DataSet")]
        public string Select_Pol_User_Role_ByIDRole3(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Pol_User_Role_Select_ByIDRole(Pol_User_Role);
        }



        [WebMethod(Description = "Insert một đối tượng Pol_User_Role vào bảng pol_user_Role")]
        public object Pol_User_Role_Insert(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Pol_User_Role_Insert(Pol_User_Role);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_User_Role trong bảng pol_user_Role")]
        public object Update_Pol_User_Role(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Update_Pol_User_Role(Pol_User_Role);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_User_Role trong bảng pol_user_Role")]
        public object Pol_User_Role_Delete(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Pol_User_Role_Delete(Pol_User_Role);
        }

        [WebMethod(Description = "Cập nhật một dataset DataSet_Pol_User_Role vào trong bảng pol_user_Role")]
        public object Update_Pol_User_Role_Collection(DataSet ds_Pol_User_Role)
        {
            return _Pol_User_Role_Service.Update_Pol_User_Role_Collection(ds_Pol_User_Role);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_role và id_user, trả về danh sách nhóm quyền (trong một mảng) Pol_Dm_Role_Collection")]
        public string Select_Pol_User_Role_ByID_UserRole1(Ecm.Domain.Pol.Pol_User_Role Pol_User_Role)
        {
            return _Pol_User_Role_Service.Select_Pol_User_Role_ByID_UserRole(Pol_User_Role);
        }
        #endregion //Người dùng trong nhóm quyền (User in Role)

        #region Người dùng trong quyền (User in Right)

        [WebMethod(Description = "Select một đối tượng Pol_User_Right trong bảng pol_user_right theo điều kiện id_right, trả về danh sách người dùng được Serialize thành DataSet")]
        public string Select_Pol_User_Right_ByIDRight3(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return _Pol_User_Right_Service.Pol_User_Right_Select_ByIDRight(Pol_User_Right);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Right trong bảng pol_user_right theo điều kiện id_user, trả về danh sách quyền được Serialize thành DataSet")]
        public string Select_Pol_User_Right_ByIDUser3(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return _Pol_User_Right_Service.Pol_User_Right_Select_ByIDUser(Pol_User_Right);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_User_Right vào bảng pol_user_right")]
        public object Pol_User_Right_Insert(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return _Pol_User_Right_Service.Pol_User_Right_Insert(Pol_User_Right);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_User_Right trong bảng pol_user_right")]
        public object Update_Pol_User_Right(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return _Pol_User_Right_Service.Update_Pol_User_Right(Pol_User_Right);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_User_Right trong bảng pol_user_right")]
        public object Pol_User_Right_Delete(Ecm.Domain.Pol.Pol_User_Right Pol_User_Right)
        {
            return _Pol_User_Right_Service.Pol_User_Right_Delete(Pol_User_Right);
        }

        [WebMethod(Description = "cập nhật một dataset DataSet_Pol_User_Right vào trong bảng pol_user_right")]
        public object Update_Pol_User_Right_Collection(DataSet ds_Pol_User_Right)
        {
            return _Pol_User_Right_Service.Update_Pol_User_Right_Collection(ds_Pol_User_Right);
        }
        #endregion //Người dùng trong quyền (User in Right)

        #region Quyền trong nhóm quyền (Right in Role)



        [WebMethod(Description = "Select một đối tượng Pol_Role_Right trong bảng pol_role_right theo điều kiện id_role, trả về danh sách quyền được Serialize thành DataSet")]
        public string Select_Pol_Role_Right_ByIDRole3(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Select_ByIDRole(Pol_Role_Right);

        }

        [WebMethod(Description = "Select một đối tượng Pol_Role_Right trong bảng pol_role_right theo điều kiện id_right, trả về danh sách nhóm quyền được Serialize thành DataSet")]
        public string Select_Pol_Role_Right_ByIDRight3(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Select_ByIDRight(Pol_Role_Right);

        }

        [WebMethod(Description = "Insert một đối tượng Pol_Role_Right vào bảng pol_role_right")]
        public object Pol_Role_Right_Insert(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Insert(Pol_Role_Right);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Role_Right trong bảng pol_role_right")]
        public object Update_Pol_Role_Right(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Update_Pol_Role_Right(Pol_Role_Right);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Role_Right trong bảng pol_role_right")]
        public object Pol_Role_Right_Delete(Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Delete(Pol_Role_Right);
        }

        [WebMethod(Description = "Cập nhật một dataset DataSet_Pol_Role_Right vào trong bảng pol_role_right")]
        public object Update_Pol_Role_Right_Collection(DataSet ds_Pol_Role_Right)
        {
            return _Pol_Role_Right_Service.Update_Pol_Role_Right_Collection(ds_Pol_Role_Right);
        }
        #endregion //Quyền trong nhóm quyền (Right in Role)

        #region Thao tác của nhóm quyền (Action of Role)




        [WebMethod(Description = "Select một đối tượng Pol_Action_Role trong bảng pol_action_role theo điều kiện id_role và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Select_Pol_Action_Role_ByID_RoleRight3(Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role)
        {
            return _Pol_Action_Role_Service.Pol_Action_Role_Select_ByID_RoleRight(Pol_Action_Role);
        }



        [WebMethod(Description = "Insert một đối tượng Pol_Action_Role vào bảng pol_action_role")]
        public object Pol_Action_Role_Insert(Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role)
        {
            return _Pol_Action_Role_Service.Pol_Action_Role_Insert(Pol_Action_Role);
        }


        [WebMethod(Description = "Xóa một đối tượng Pol_Action_Role trong bảng pol_action_role")]
        public object Pol_Action_Role_Delete(Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role)
        {
            return _Pol_Action_Role_Service.Pol_Action_Role_Delete(Pol_Action_Role);
        }

        [WebMethod(Description = "Cập nhật một dataset DataSet_Pol_Action_Role vào trong bảng pol_action_role")]
        public object Update_Pol_Action_Role_Collection(DataSet ds_Pol_Action_Role)
        {
            return _Pol_Action_Role_Service.Update_Pol_Action_Role_Collection(ds_Pol_Action_Role);
        }
        #endregion //Thao tác của nhóm quyền (Action of Role)

        #region Thao tác của người dùng (Action of User)

        [WebMethod(Description = "Select một đối tượng Pol_Action_User trong bảng pol_action_user theo điều kiện id_user và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Select_Pol_Action_User_ByID_UserRight3(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return _Pol_Action_User_Service.Pol_Action_User_Select_ByID_UserRight(Pol_Action_User);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Action_User trong bảng pol_action_user theo điều kiện id_user và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Pol_Action_User_Select_ByID_UserRight_ForAuth(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return _Pol_Action_User_Service.Pol_Action_User_Select_ByID_UserRight_ForAuth(Pol_Action_User);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Action_User vào bảng pol_action_user")]
        public object Pol_Action_User_Insert(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return _Pol_Action_User_Service.Pol_Action_User_Insert(Pol_Action_User);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Action_User trong bảng pol_action_user")]
        public object Update_Pol_Action_User(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return _Pol_Action_User_Service.Update_Pol_Action_User(Pol_Action_User);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Action_User trong bảng pol_action_user")]
        public object Pol_Action_User_Delete(Ecm.Domain.Pol.Pol_Action_User Pol_Action_User)
        {
            return _Pol_Action_User_Service.Pol_Action_User_Delete(Pol_Action_User);
        }

        [WebMethod(Description = "Cập nhật một dataset DataSet_Pol_Action_User vào trong bảng pol_action_user")]
        public object Update_Pol_Action_User_Collection(DataSet ds_Pol_Action_User)
        {
            return _Pol_Action_User_Service.Update_Pol_Action_User_Collection(ds_Pol_Action_User);
        }
        #endregion //Thao tác của người dùng (Action of User)



        //#region Chứng thực và kiểm quyền người dùng (Authorization)
        //[WebMethod(Description = "Kiểm tra các thao tác của người dùng trên form")]
        //public Ecm.Model.Pol.Pol_Dm_Action_Collection Autorization(string Role_System_Name, string Right_System_Name, string User_Name)
        //{
        //    object Id_Role = Get_Id_Role(Role_System_Name);
        //    object Id_Right = Get_Id_Right(Right_System_Name);
        //    object Id_User = Get_Id_User(User_Name);

        //    Ecm.Model.Pol.Pol_Dm_Action_Collection Pol_Dm_Action_Collection = new Ecm.Model.Pol.Pol_Dm_Action_Collection();

        //    Ecm.Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
        //    Pol_User_Role.Id_Role = Id_Role;
        //    Pol_User_Role.Id_User = Id_User;
        //    Ecm.Model.Pol.Pol_Dm_Role_Collection Pol_Dm_Role_Collection = Select_Pol_User_Role_ByID_UserRole1(Pol_User_Role);

        //    if (Pol_Dm_Role_Collection.Count > 0)
        //    {
        //        Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role = new Ecm.Domain.Pol.Pol_Action_Role();
        //        Pol_Action_Role.Id_Role = Id_Role;
        //        Pol_Action_Role.Id_Right = Id_Right;
        //        Ecm.Model.Pol.Pol_Dm_Action_Collection Pol_Dm_Action_Collection1 = Select_Pol_Action_Role_ByID_RoleRight1(Pol_Action_Role);
        //        foreach (Ecm.Domain.Pol.Pol_Dm_Action pol_Dm_Action in Pol_Dm_Action_Collection1)
        //        {
        //            Pol_Dm_Action_Collection.Add(pol_Dm_Action);
        //        }

        //        Ecm.Domain.Pol.Pol_Action_User Pol_Action_User = new Ecm.Domain.Pol.Pol_Action_User();
        //        Pol_Action_User.Id_User = Id_User;
        //        Pol_Action_User.Id_Right = Id_Right;
        //        Ecm.Model.Pol.Pol_Dm_Action_Collection Pol_Dm_Action_Collection2 = Select_Pol_Action_User_ByID_UserRight1(Pol_Action_User);

        //        foreach (Ecm.Domain.Pol.Pol_Dm_Action pol_Dm_Action in Pol_Dm_Action_Collection2)
        //        {
        //            Pol_Dm_Action_Collection.Add(pol_Dm_Action);
        //        }
        //    }
        //    return Pol_Dm_Action_Collection;
        //}

        //[WebMethod(Description = "Trả về Id_Role của khi biết được Role_System_Name")]
        //public object Get_Id_Role(string Role_System_Name)
        //{
        //    Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role = new Ecm.Domain.Pol.Pol_Dm_Role();
        //    Pol_Dm_Role.Role_System_Name = Role_System_Name;
        //    Ecm.Model.Pol.Pol_Dm_Role_Collection Pol_Dm_Role_Collection = Select_Pol_Dm_Role_ByName(Pol_Dm_Role);
        //    return Pol_Dm_Role_Collection[1].Id_Role;
        //}

        //[WebMethod(Description = "Trả về Id_Right của khi biết được Right_System_Name")]
        //public object Get_Id_Right(string Right_System_Name)
        //{
        //    Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
        //    Pol_Dm_Right.Right_System_Name = Right_System_Name;
        //    Ecm.Model.Pol.Pol_Dm_Right_Collection Pol_Dm_Right_Collection = Pol_Dm_Right_Select_ByName(Pol_Dm_Right);
        //    return Pol_Dm_Right_Collection[1].Id_Right;
        //}

        //[WebMethod(Description = "Trả về Id_User của khi biết được User_Name")]
        //public object Get_Id_User(string User_Name)
        //{
        //    Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
        //    Pol_Dm_User.User_Name = User_Name;
        //    Ecm.Model.Pol.Pol_Dm_User_Collection Pol_Dm_User_Collection = Pol_Dm_User_Select_ByName(Pol_Dm_User);
        //    return Pol_Dm_User_Collection[1].Id_User;
        //}
        //#endregion //Chứng thực và kiểm quyền người dùng (Authorization)



        [WebMethod]
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
        #endregion //Pol - Webmethod


        [WebMethod]
        public DateTime GetServerDateTime()
        {
            return SystemService.GetServerDateTime();
        }

        #region DocumentProcessStatus
        [WebMethod(Description = "")]
        public string Get_DocumentProcessStatus(object Tablename, object PK_Name, object Identity)
        {
            return _DocumentProcessStatus_Service.Get_DocumentProcessStatus(Tablename, PK_Name, Identity);
        }

        [WebMethod(Description = "")]
        public object Update_DocumentProcessStatus(object Tablename, object PK_Name, object Identity
            , object Doc_Process_Status, object Id_Nhansu_Test, object Ghichu_Test
            , object Id_Nhansu_Verify, object Ghichu_Verify
            )
        {
            Ecm.Domain.Ware.DocumentProcessStatus DocumentProcessStatus = new Ecm.Domain.Ware.DocumentProcessStatus();

            DocumentProcessStatus.Tablename = Tablename;
            DocumentProcessStatus.PK_Name = PK_Name;
            DocumentProcessStatus.Identity = Identity;
            DocumentProcessStatus.Doc_Process_Status = Doc_Process_Status;
            DocumentProcessStatus.Id_Nhansu_Test = Id_Nhansu_Test;
            DocumentProcessStatus.Ghichu_Test = Ghichu_Test;
            DocumentProcessStatus.Id_Nhansu_Verify = Id_Nhansu_Verify;
            DocumentProcessStatus.Ghichu_Verify = Ghichu_Verify;

            return _DocumentProcessStatus_Service.Update_DocumentProcessStatus(DocumentProcessStatus);
        }

        #endregion

        #region Cac phuong thuc theo goobiz framework
        ///Phuongphan - 02/08/2010

        #region Pol_Dm_User
        /// <summary>
        /// use in  DatabaseLogon
        /// </summary>
        /// <param name="pUser_Name"></param>
        /// <param name="pUser_Password"></param>
        /// <returns></returns>
        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện user_name và user_password, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByAuth_UserInfoInText(string pUser_Name, string pUser_Password)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.User_Name = pUser_Name;
            Pol_Dm_User.User_Password = pUser_Password;

            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByAuth(Pol_Dm_User);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện user_name, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByText_UserName(object User_Name)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.User_Name = User_Name;
            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByName(Pol_Dm_User);
        }

        /// <summary>
        /// use in IDCardLogon, IDCardLogonWithResult
        /// </summary>
        /// <param name="Ma_Nhansu"></param>
        /// <returns></returns>
        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện user_name và user_password, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByMa_Nhansu(string Ma_Nhansu)
        {
            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByMa_Nhansu(Ma_Nhansu);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Dm_User vào bảng pol_dm_user")]
        public object Pol_Dm_User_Insert_ByText(object User_Name, object User_Fullname, object User_Description, object Id_Nhansu)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.User_Name = User_Name;
            Pol_Dm_User.User_Fullname = User_Fullname;
            Pol_Dm_User.User_Description = User_Description;
            Pol_Dm_User.Id_Nhansu = Id_Nhansu;

            return _Pol_Dm_User_Service.Pol_Dm_User_Insert(Pol_Dm_User);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Update_ByText(object Id_User, object User_Name, object User_Fullname, object User_Description, object Id_Nhansu, object User_Disable)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.Id_User = Id_User;
            Pol_Dm_User.User_Name = User_Name;
            Pol_Dm_User.User_Fullname = User_Fullname;
            Pol_Dm_User.User_Description = User_Description;
            Pol_Dm_User.Id_Nhansu = Id_Nhansu;
            if ("" + User_Disable != "")
                Pol_Dm_User.User_Disable = User_Disable;
            else
                Pol_Dm_User.User_Disable = null;

            return _Pol_Dm_User_Service.Pol_Dm_User_Update(Pol_Dm_User);
        }

        [WebMethod(Description = "Cập nhật mật khẩu của một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Password_Update_ByText(object Id_User, object User_Password)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.Id_User = Id_User;
            Pol_Dm_User.User_Password = User_Password;

            return _Pol_Dm_User_Service.Pol_Dm_User_Password_Update(Pol_Dm_User);
        }

        [WebMethod(Description = "Cập nhật mật khẩu của một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_AuthCode_Update_ByText(object Id_User, object AuthCode)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.Id_User = Id_User;
            Pol_Dm_User.AuthCode = AuthCode;

            return _Pol_Dm_User_Service.Pol_Dm_User_AuthCode_Update(Pol_Dm_User);
        }
        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_User trong bảng pol_dm_user")]
        public object Pol_Dm_User_Delete_ByText(object Id_User)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.Id_User = Id_User;
            return _Pol_Dm_User_Service.Pol_Dm_User_Delete(Pol_Dm_User);
        }


        [WebMethod(Description = "cập nhật một dataset DataSet_Pol_Dm_User vào trong bảng pol_dm_user")]
        public object Update_Pol_Dm_User_Collection(DataSet ds_Pol_Dm_User)
        {
            return _Pol_Dm_User_Service.Update_Pol_Dm_User_Collection(ds_Pol_Dm_User);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_User trong bảng pol_dm_user theo điều kiện id_user, trả về Pol_Dm_User_Collection")]
        public string Pol_Dm_User_Select_ByIDText(object Id_User)
        {
            Ecm.Domain.Pol.Pol_Dm_User Pol_Dm_User = new Ecm.Domain.Pol.Pol_Dm_User();
            Pol_Dm_User.Id_User = Id_User;

            return _Pol_Dm_User_Service.Pol_Dm_User_Select_ByID(Pol_Dm_User);
        }

        #endregion

        #region Pol_Dm_Role
        [WebMethod(Description = "Xóa một đối tượng Pol_Dm_Role trong bảng pol_dm_role")]
        public object Pol_Dm_Role_Delete_ByText(object Id_Role)
        {
            Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role = new Ecm.Domain.Pol.Pol_Dm_Role();
            Pol_Dm_Role.Id_Role = Id_Role;
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Delete(Pol_Dm_Role);
        }

        //fr 20101104
        [WebMethod(Description = "Insert một đối tượng Pol_Dm_Role vào bảng pol_dm_role")]
        public object Pol_Dm_Role_Insert_ByText(object Role_System_Name, object Role_Description)
        {
            Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role = new Ecm.Domain.Pol.Pol_Dm_Role();
            Pol_Dm_Role.Role_System_Name = Role_System_Name;
            Pol_Dm_Role.Role_Description = Role_Description;
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Insert(Pol_Dm_Role);
        }

        //fr 20101104
        /// <returns></returns>
        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_Role trong bảng pol_dm_role")]
        public object Pol_Dm_Role_Update_ByText(object Id_Role, object Role_System_Name, object Role_Description)
        {
            Ecm.Domain.Pol.Pol_Dm_Role Pol_Dm_Role = new Ecm.Domain.Pol.Pol_Dm_Role();
            Pol_Dm_Role.Id_Role = Id_Role;
            Pol_Dm_Role.Role_System_Name = Role_System_Name;
            Pol_Dm_Role.Role_Description = Role_Description;
            return _Pol_Dm_Role_Service.Pol_Dm_Role_Update(Pol_Dm_Role);
        }
        #endregion

        #region Pol_Dm_Right
        //fr 20101105
        [WebMethod(Description = "Trả về danh sách quyền được Serialize thành DataSet")]
        public string Get_Pol_Dm_Right_Collection3()
        {
            return _Pol_Dm_Right_Service.Get_Pol_Dm_Right_Collection();
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Right trong bảng pol_dm_right theo điều kiện id_right, trả về danh sách quyền (trong một mảng) Pol_Dm_Right_Collection")]
        public string Pol_Dm_Right_Select_ByIDText(object Id_Right)
        {
            Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
            Pol_Dm_Right.Id_Right = Id_Right;

            return _Pol_Dm_Right_Service.Pol_Dm_Right_Select_ByID(Pol_Dm_Right);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Dm_Right trong bảng pol_dm_right theo điều kiện right_name, trả về danh sách quyền (trong một mảng) Pol_Dm_Right_Collection")]
        public string Pol_Dm_Right_Select_ByNameText(object Right_System_Name)
        {
            Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
            Pol_Dm_Right.Right_System_Name = Right_System_Name;
            return _Pol_Dm_Right_Service.Pol_Dm_Right_Select_ByName(Pol_Dm_Right);
        }

        [WebMethod(Description = "Cập nhật một đối tượng Pol_Dm_Right trong bảng pol_dm_right")]
        public object Pol_Dm_Right_Update_ByText(object Id_Right, object Right_System_Name, object Right_Description)
        {
            Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
            Pol_Dm_Right.Id_Right = Id_Right;
            Pol_Dm_Right.Right_System_Name = Right_System_Name;
            Pol_Dm_Right.Right_Description = Right_Description;

            return _Pol_Dm_Right_Service.Pol_Dm_Right_Update(Pol_Dm_Right);
        }

        [WebMethod(Description = "add một đối tượng Pol_Dm_Right trong bảng pol_dm_right")]
        public object Pol_Dm_Right_Insert_ByText(object Right_System_Name, object Right_Display_Name, object Right_Description)
        {
            Ecm.Domain.Pol.Pol_Dm_Right Pol_Dm_Right = new Ecm.Domain.Pol.Pol_Dm_Right();
            Pol_Dm_Right.Right_System_Name = Right_System_Name;
            Pol_Dm_Right.Right_Display_Name = Right_Display_Name;
            Pol_Dm_Right.Right_Description = Right_Description;

            return _Pol_Dm_Right_Service.Pol_Dm_Right_Insert(Pol_Dm_Right);
        }

        #endregion

        #region Pol_Role_Right
        [WebMethod(Description = "Select một đối tượng Pol_Role_Right trong bảng pol_role_right theo điều kiện id_role, trả về danh sách quyền được Serialize thành DataSet")]
        public string Select_Pol_Role_Right_ByTextIDRole3(object Id_Role)
        {
            Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right = new Ecm.Domain.Pol.Pol_Role_Right();
            Pol_Role_Right.Id_Role = Id_Role;
            return _Pol_Role_Right_Service.Pol_Role_Right_Select_ByIDRole(Pol_Role_Right);

        }

        //fr 20101104
        [WebMethod(Description = "Select một đối tượng Pol_Role_Right trong bảng pol_role_right theo điều kiện id_role, trả về danh sách quyền được Serialize thành DataSet")]
        public string SelectAll_Pol_Role_Right()
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_SelectAll();

        }

        //fr 20101104
        [WebMethod]
        public object Init_Pol_Role_Right()
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Init();
        }

        //fr 20101104
        [WebMethod]
        public object Reset_Pol_Role_Right()
        {
            return _Pol_Role_Right_Service.Pol_Role_Right_Reset();
        }

        [WebMethod(Description = "Select một đối tượng Pol_Role_Right trong bảng pol_role_right theo điều kiện id_right, trả về danh sách nhóm quyền được Serialize thành DataSet")]
        public string Select_Pol_Role_Right_ByTextIDRight3(object Id_Right)
        {
            Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right = new Ecm.Domain.Pol.Pol_Role_Right();
            Pol_Role_Right.Id_Right = Id_Right;

            return _Pol_Role_Right_Service.Pol_Role_Right_Select_ByIDRight(Pol_Role_Right);

        }


        [WebMethod(Description = "Insert một đối tượng Pol_Role_Right vào bảng pol_role_right")]
        public object Pol_Role_Right_Insert_ByText(object Id_Role, object Id_Right)
        {
            Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right = new Ecm.Domain.Pol.Pol_Role_Right();
            Pol_Role_Right.Id_Role = Id_Role;
            Pol_Role_Right.Id_Right = Id_Right;

            return _Pol_Role_Right_Service.Pol_Role_Right_Insert(Pol_Role_Right);
        }


        [WebMethod(Description = "Xóa một đối tượng Pol_Role_Right trong bảng pol_role_right")]
        public object Pol_Role_Right_Delete_ByText(object Id_Role, object Id_Right)
        {
            Ecm.Domain.Pol.Pol_Role_Right Pol_Role_Right = new Ecm.Domain.Pol.Pol_Role_Right();
            Pol_Role_Right.Id_Role = Id_Role;
            Pol_Role_Right.Id_Right = Id_Right;
            return _Pol_Role_Right_Service.Pol_Role_Right_Delete(Pol_Role_Right);
        }

        #endregion

        #region Pol_User_Role
        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_role, trả về danh sách người dùng được Serialize thành DataSet")]
        public string Select_Pol_User_Role_ByTextIDRole3(object Id_Role)
        {
            Ecm.Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
            Pol_User_Role.Id_Role = Id_Role;
            return _Pol_User_Role_Service.Pol_User_Role_Select_ByIDRole(Pol_User_Role);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Role trong bảng pol_user_role theo điều kiện id_user, trả về danh sách nhóm quyền được Serialize thành DataSet")]
        public string Select_Pol_User_Role_ByTextIDUser3(object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
            Pol_User_Role.Id_User = Id_User;
            return _Pol_User_Role_Service.Pol_User_Role_Select_ByIDUser(Pol_User_Role);
        }


        [WebMethod(Description = "Xóa một đối tượng Pol_User_Role trong bảng pol_user_Role")]
        public object Pol_User_Role_Delete_ByText(object Id_Role, object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
            Pol_User_Role.Id_Role = Id_Role;
            Pol_User_Role.Id_User = Id_User;

            return _Pol_User_Role_Service.Pol_User_Role_Delete(Pol_User_Role);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_User_Role vào bảng pol_user_Role")]
        public object Pol_User_Role_Insert_ByText(object Id_Role, object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Role Pol_User_Role = new Ecm.Domain.Pol.Pol_User_Role();
            Pol_User_Role.Id_Role = Id_Role;
            Pol_User_Role.Id_User = Id_User;

            return _Pol_User_Role_Service.Pol_User_Role_Insert(Pol_User_Role);
        }



        #endregion

        #region Pol_User_Right
        [WebMethod(Description = "Select một đối tượng Pol_User_Right trong bảng pol_user_right theo điều kiện id_right, trả về danh sách người dùng được Serialize thành DataSet")]
        public string Select_Pol_User_Right_ByTextIDRight3(object Id_Right)
        {
            Ecm.Domain.Pol.Pol_User_Right Pol_User_Right = new Ecm.Domain.Pol.Pol_User_Right();
            Pol_User_Right.Id_Right = Id_Right;
            return _Pol_User_Right_Service.Pol_User_Right_Select_ByIDRight(Pol_User_Right);
        }

        [WebMethod(Description = "Select một đối tượng Pol_User_Right trong bảng pol_user_right theo điều kiện id_user, trả về danh sách quyền được Serialize thành DataSet")]
        public string Select_Pol_User_Right_ByTextIDUser3(object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Right Pol_User_Right = new Ecm.Domain.Pol.Pol_User_Right();
            Pol_User_Right.Id_User = Id_User;

            return _Pol_User_Right_Service.Pol_User_Right_Select_ByIDUser(Pol_User_Right);
        }


        [WebMethod(Description = "Insert một đối tượng Pol_User_Right vào bảng pol_user_right")]
        public object Pol_User_Right_Insert_ByText(object Id_Right, object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Right Pol_User_Right = new Ecm.Domain.Pol.Pol_User_Right();
            Pol_User_Right.Id_Right = Id_Right;
            Pol_User_Right.Id_User = Id_User;

            return _Pol_User_Right_Service.Pol_User_Right_Insert(Pol_User_Right);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_User_Right trong bảng pol_user_right")]
        public object Pol_User_Right_Delete_ByText(object Id_Right, object Id_User)
        {
            Ecm.Domain.Pol.Pol_User_Right Pol_User_Right = new Ecm.Domain.Pol.Pol_User_Right();
            Pol_User_Right.Id_Right = Id_Right;
            Pol_User_Right.Id_User = Id_User;

            return _Pol_User_Right_Service.Pol_User_Right_Delete(Pol_User_Right);
        }



        #endregion

        #region Pol_Action_Role
        [WebMethod(Description = "Select một đối tượng Pol_Action_Role trong bảng pol_action_role theo điều kiện id_role và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Select_Pol_Action_Role_ByTextIDRoleRight3(object Id_Role, object Id_Right)
        {
            Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role = new Ecm.Domain.Pol.Pol_Action_Role();
            Pol_Action_Role.Id_Role = Id_Role;
            Pol_Action_Role.Id_Right = Id_Right;
            return _Pol_Action_Role_Service.Pol_Action_Role_Select_ByID_RoleRight(Pol_Action_Role);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Action_Role vào bảng pol_action_role")]
        public object Pol_Action_Role_Insert_ByText(object Id_Role, object Id_Right, object Id_Action)
        {
            Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role = new Ecm.Domain.Pol.Pol_Action_Role();
            Pol_Action_Role.Id_Role = Id_Role;
            Pol_Action_Role.Id_Right = Id_Right;
            Pol_Action_Role.Id_Action = Id_Action;

            return _Pol_Action_Role_Service.Pol_Action_Role_Insert(Pol_Action_Role);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Action_Role trong bảng pol_action_role")]
        public object Pol_Action_Role_Delete_ByText(object Id_Role, object Id_Right, object Id_Action)
        {
            Ecm.Domain.Pol.Pol_Action_Role Pol_Action_Role = new Ecm.Domain.Pol.Pol_Action_Role();
            Pol_Action_Role.Id_Role = Id_Role;
            Pol_Action_Role.Id_Right = Id_Right;
            Pol_Action_Role.Id_Action = Id_Action;

            return _Pol_Action_Role_Service.Pol_Action_Role_Delete(Pol_Action_Role);
        }

        #endregion

        #region Pol_Action_User
        /// <summary>
        /// use in  IDCardLogonWithResult
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="right_system_name"></param>
        /// <returns></returns>
        [WebMethod(Description = "Select một đối tượng Pol_Action_User trong bảng pol_action_user theo điều kiện id_user và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Pol_Action_User_Select_ByUSnRIName(string user_name, string right_system_name)
        {
            return _Pol_Action_User_Service.Pol_Action_User_Select_ByUSnRIName(user_name, right_system_name);
        }

        [WebMethod(Description = "Select một đối tượng Pol_Action_User trong bảng pol_action_user theo điều kiện id_user và id_right, trả về danh sách thao tác được Serialize thành DataSet")]
        public string Select_Pol_Action_User_ByTextID_UserRight3(object Id_Right, object Id_User)
        {
            Ecm.Domain.Pol.Pol_Action_User Pol_Action_User = new Ecm.Domain.Pol.Pol_Action_User();
            Pol_Action_User.Id_Right = Id_Right;
            Pol_Action_User.Id_User = Id_User;

            return _Pol_Action_User_Service.Pol_Action_User_Select_ByID_UserRight(Pol_Action_User);
        }

        [WebMethod(Description = "Insert một đối tượng Pol_Action_User vào bảng pol_action_user")]
        public object Pol_Action_User_Insert_ByText(object Id_Right, object Id_User, object Id_Action)
        {
            Ecm.Domain.Pol.Pol_Action_User Pol_Action_User = new Ecm.Domain.Pol.Pol_Action_User();
            Pol_Action_User.Id_Right = Id_Right;
            Pol_Action_User.Id_User = Id_User;
            Pol_Action_User.Id_Action = Id_Action;

            return _Pol_Action_User_Service.Pol_Action_User_Insert(Pol_Action_User);
        }

        [WebMethod(Description = "Xóa một đối tượng Pol_Action_User trong bảng pol_action_user")]
        public object Pol_Action_User_Delete_ByText(object Id_Right, object Id_User, object Id_Action)
        {
            Ecm.Domain.Pol.Pol_Action_User Pol_Action_User = new Ecm.Domain.Pol.Pol_Action_User();
            Pol_Action_User.Id_Right = Id_Right;
            Pol_Action_User.Id_User = Id_User;
            Pol_Action_User.Id_Action = Id_Action;

            return _Pol_Action_User_Service.Pol_Action_User_Delete(Pol_Action_User);
        }


        #endregion

        #region Nhan su
        [WebMethod(Description = "Tra ve ds nhan su")]
        public string Get_All_Rex_Nhansu_Collection3()
        {
            return _Rex_Nhansu_Service.Get_All_Rex_Nhansu_Collection();
        }
        #endregion
        #endregion
    }
}
