using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ecm.Service.Rex
{
    public class Rex_Luong_Tonghop_Service : MarshalByRefObject
    {
        #region private fields
        System.Data.OleDb.OleDbConnection _SqlConnection;
        #endregion

        public Rex_Luong_Tonghop_Service(System.Data.OleDb.OleDbConnection sqlConnection)
        {
            this._SqlConnection = sqlConnection;
        }

        public string Get_Rex_Luong_Tonghop_By_Kyluong_Id_Bophan(object Id_Kyluong, object Id_Bophan, object Inc_Bophan_Tructhuoc)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Select_By_Id_Kyluong_Id_Bophan", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong",Id_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan",Id_Bophan));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Inc_Bophan_Tructhuoc",Inc_Bophan_Tructhuoc));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        public string Get_Rex_Luong_Tonghop_ByInhansu(object Id_Kyluong, object Id_Nhansu)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Select_ByInhansu", this._SqlConnection);
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", Id_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", Id_Nhansu));
            oleDbCommand.CommandType = CommandType.StoredProcedure;

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        

        public string Rex_Luong_Tonghop_Init(object Nam_Kyluong, object Thang_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Init", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Thang_Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Rex_Luong_Tonghop_Init_ByBophan(object Nam_Kyluong, object Thang_Kyluong, object Id_Bophan)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Init_ByBophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Thang_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", Id_Bophan));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }
        public string Rex_Luong_Tonghop_Tkquyluong(object Nam_Kyluong, object Thang_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Rex_Luong_Tonghop_Tkquyluong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Nam_Kyluong", Nam_Kyluong));
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thang_Kyluong", Thang_Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_Luong_Tonghop_New_By_Thangnam(object Kyluong)
        {

            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Get_Rex_Luong_Tonghop_New_By_Thangnam", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Kyluong", Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public string Get_Rex_Luong_Tonghop_By_Id_Kyluong_Group_By_Bophan(object id_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Get_Rex_Luong_Tonghop_By_Id_Kyluong_Group_By_Bophan", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", id_Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        public bool Check_Rex_Luong_Tonghop_Already_By_Id_Kyluong(object id_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Check_Rex_Luong_Tonghop_Already_By_Id_Kyluong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", id_Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
            return true;
        }

        public object Insert_Rex_Luong_Tonghop(Ecm.Domain.Rex.Rex_Luong_Tonghop rex_Luong_Tonghop)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Insert_Rex_Luong_Tonghop", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;

                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Luong_Tonghop.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", rex_Luong_Tonghop.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", rex_Luong_Tonghop.Id_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienluong", rex_Luong_Tonghop.Tienluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Phucap_Khong_Tinhthue", rex_Luong_Tonghop.Tong_Phucap_Khong_Tinhthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Phucap_Tinhthue", rex_Luong_Tonghop.Tong_Phucap_Tinhthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Tienluong", rex_Luong_Tonghop.Tong_Tienluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Chiuthue", rex_Luong_Tonghop.Sotien_Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhxh", rex_Luong_Tonghop.Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhyt", rex_Luong_Tonghop.Bhyt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhtn", rex_Luong_Tonghop.Bhtn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tamung_Ky1", rex_Luong_Tonghop.Tamung_Ky1));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phucap_Bhxh", rex_Luong_Tonghop.Phucap_Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Nguoi_Phuthuoc", rex_Luong_Tonghop.So_Nguoi_Phuthuoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Nguoi_Phuthuoc", rex_Luong_Tonghop.Sotien_Nguoi_Phuthuoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Buluong", rex_Luong_Tonghop.Buluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Conlai_Chiuthue", rex_Luong_Tonghop.Sotien_Conlai_Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Kyluat", rex_Luong_Tonghop.Kyluat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuclanh", rex_Luong_Tonghop.Thuclanh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tuthien", rex_Luong_Tonghop.Tuthien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", rex_Luong_Tonghop.Id_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuengoai", rex_Luong_Tonghop.Thuengoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cutru", rex_Luong_Tonghop.Cutru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Giamtru_Nguoinop", rex_Luong_Tonghop.Giamtru_Nguoinop));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Update_Rex_Luong_Tonghop(Ecm.Domain.Rex.Rex_Luong_Tonghop rex_Luong_Tonghop)
        {
            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Update_Rex_Luong_Tonghop", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Luong_Tonghop", rex_Luong_Tonghop.Id_Luong_Tonghop));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Bophan", rex_Luong_Tonghop.Id_Bophan));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Nhansu", rex_Luong_Tonghop.Id_Nhansu));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", rex_Luong_Tonghop.Id_Kyluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tienluong", rex_Luong_Tonghop.Tienluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Phucap_Khong_Tinhthue", rex_Luong_Tonghop.Tong_Phucap_Khong_Tinhthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Phucap_Tinhthue", rex_Luong_Tonghop.Tong_Phucap_Tinhthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tong_Tienluong", rex_Luong_Tonghop.Tong_Tienluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Chiuthue", rex_Luong_Tonghop.Sotien_Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhxh", rex_Luong_Tonghop.Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhyt", rex_Luong_Tonghop.Bhyt));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Bhtn", rex_Luong_Tonghop.Bhtn));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tamung_Ky1", rex_Luong_Tonghop.Tamung_Ky1));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Phucap_Bhxh", rex_Luong_Tonghop.Phucap_Bhxh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@So_Nguoi_Phuthuoc", rex_Luong_Tonghop.So_Nguoi_Phuthuoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Nguoi_Phuthuoc", rex_Luong_Tonghop.Sotien_Nguoi_Phuthuoc));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Buluong", rex_Luong_Tonghop.Buluong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Sotien_Conlai_Chiuthue", rex_Luong_Tonghop.Sotien_Conlai_Chiuthue));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Kyluat", rex_Luong_Tonghop.Kyluat));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuclanh", rex_Luong_Tonghop.Thuclanh));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Tuthien", rex_Luong_Tonghop.Tuthien));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Hopdong_Laodong", rex_Luong_Tonghop.Id_Hopdong_Laodong));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Thuengoai", rex_Luong_Tonghop.Thuengoai));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Cutru", rex_Luong_Tonghop.Cutru));
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Giamtru_Nguoinop", rex_Luong_Tonghop.Giamtru_Nguoinop));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Rex_Luong_Tonghop(Ecm.Domain.Rex.Rex_Luong_Tonghop rex_Luong_Tonghop)
        {

            try
            {
                System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Delete_Rex_Luong_Tonghop", this._SqlConnection);
                oleDbCommand.CommandType = CommandType.StoredProcedure;
                oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Luong_Tonghop", rex_Luong_Tonghop.Id_Luong_Tonghop));
                oleDbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object Delete_Rex_Luong_Tonghop_By_Id_Kyluong(object id_Kyluong)
        {
            System.Data.DataSet dsCollection = new DataSet();
            System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("Delete_Rex_Luong_Tonghop_By_Id_Kyluong", this._SqlConnection);
            oleDbCommand.CommandType = CommandType.StoredProcedure;
            oleDbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id_Kyluong", id_Kyluong));

            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(dsCollection, "GridTable");
                        return FastJSON.JSON.Instance.ToJSON(dsCollection);//return Newtonsoft.Json.JsonConvert.SerializeObject(dsCollection.Tables[0], Newtonsoft.Json.Formatting.None); 
        }

        private Ecm.Domain.Rex.Rex_Luong_Tonghop Get_Rex_Luong_Tonghop(DataRow row)
        {
            Ecm.Domain.Rex.Rex_Luong_Tonghop rex_Luong_Tonghop = new Ecm.Domain.Rex.Rex_Luong_Tonghop();
            if ("" + row["Bhtn"] != "")
                rex_Luong_Tonghop.Bhtn = row["Bhtn"];
            if ("" + row["Bhxh"] != "")
                rex_Luong_Tonghop.Bhxh = row["Bhxh"];
            if ("" + row["Bhyt"] != "")
                rex_Luong_Tonghop.Bhyt = row["Bhyt"];
            if ("" + row["Buluong"] != "")
                rex_Luong_Tonghop.Buluong = row["Buluong"];
            if ("" + row["Id_Bophan"] != "")
                rex_Luong_Tonghop.Id_Bophan = row["Id_Bophan"];
            if ("" + row["Id_Kyluong"] != "")
                rex_Luong_Tonghop.Id_Kyluong = row["Id_Kyluong"];
            if ("" + row["Id_Luong_Tonghop"] != "")
                rex_Luong_Tonghop.Id_Luong_Tonghop = row["Id_Luong_Tonghop"];
            if ("" + row["Id_Nhansu"] != "")
                rex_Luong_Tonghop.Id_Nhansu = row["Id_Nhansu"];
            if ("" + row["Kyluat"] != "")
                rex_Luong_Tonghop.Kyluat = row["Kyluat"];
            if ("" + row["Luong_Tangca_Khong_Chiuthue"] != "")
                rex_Luong_Tonghop.Luong_Tangca_Khong_Chiuthue = row["Luong_Tangca_Khong_Chiuthue"];
            if ("" + row["Phucap_Bhxh"] != "")
                rex_Luong_Tonghop.Phucap_Bhxh = row["Phucap_Bhxh"];
            if ("" + row["So_Nguoi_Phuthuoc"] != "")
                rex_Luong_Tonghop.So_Nguoi_Phuthuoc = row["So_Nguoi_Phuthuoc"];
            //if ("" + row["Sotien_Chiuthue"] != "")
            //    rex_Luong_Tonghop.Sotien_Chiuthue = row["Sotien_Chiuthue"];
            if ("" + row["Sotien_Conlai_Chiuthue"] != "")
                rex_Luong_Tonghop.Sotien_Conlai_Chiuthue = row["Sotien_Conlai_Chiuthue"];
            if ("" + row["Sotien_Conlai_Datruthue"] != "")
                rex_Luong_Tonghop.Sotien_Conlai_Datruthue = row["Sotien_Conlai_Datruthue"];
            if ("" + row["Sotien_Nguoi_Phuthuoc"] != "")
                rex_Luong_Tonghop.Sotien_Nguoi_Phuthuoc = row["Sotien_Nguoi_Phuthuoc"];
            if ("" + row["Tamung_Ky1"] != "")
                rex_Luong_Tonghop.Tamung_Ky1 = row["Tamung_Ky1"];
            if ("" + row["Thuclanh"] != "")
                rex_Luong_Tonghop.Thuclanh = row["Thuclanh"];
            if ("" + row["Thue_Tncn"] != "")
                rex_Luong_Tonghop.Thue_Tncn = row["Thue_Tncn"];
            if ("" + row["Tienluong"] != "")
                rex_Luong_Tonghop.Tienluong = row["Tienluong"];
            if ("" + row["Tong_Phucap_Khong_Tinhthue"] != "")
                rex_Luong_Tonghop.Tong_Phucap_Khong_Tinhthue = row["Tong_Phucap_Khong_Tinhthue"];
            if ("" + row["Tong_Phucap_Tinhthue"] != "")
                rex_Luong_Tonghop.Tong_Phucap_Tinhthue = row["Tong_Phucap_Tinhthue"];
            if ("" + row["Tong_Tienluong"] != "")
                rex_Luong_Tonghop.Tong_Tienluong = row["Tong_Tienluong"];
            if ("" + row["Tuthien"] != "")
                rex_Luong_Tonghop.Tuthien = row["Tuthien"];
            if ("" + row["Id_Hopdong_Laodong"] != "")
                rex_Luong_Tonghop.Id_Hopdong_Laodong = row["Id_Hopdong_Laodong"];
            if ("" + row["Cutru"] != "")
                rex_Luong_Tonghop.Cutru = row["Cutru"];
            if ("" + row["Thuengoai"] != "")
                rex_Luong_Tonghop.Thuengoai = row["Thuengoai"];
            if ("" + row["Giamtru_Nguoinop"] != "")
                rex_Luong_Tonghop.Giamtru_Nguoinop = row["Giamtru_Nguoinop"];

            return rex_Luong_Tonghop;
        }

        public object Update_Rex_Luong_Tonghop_Collection(DataSet dsCollection)
        {
            try
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("select * from Rex_Luong_Tonghop", _SqlConnection);
                System.Data.OleDb.OleDbCommandBuilder oleDbCommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(oleDbDataAdapter);
                oleDbDataAdapter = oleDbCommandBuilder.DataAdapter;

                oleDbDataAdapter.Update(dsCollection, "GridTable");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

    }
}
