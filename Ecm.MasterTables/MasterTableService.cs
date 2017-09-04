using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SunLine.MasterTables
{
    public class MasterTableService
    {
        static MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        static string localdata_path = @"Resources\localdata";

        public static void LoadMasterData()
        {
            System.Threading.Thread threadRun = new System.Threading.Thread(new System.Threading.ThreadStart(RunThread));
            threadRun.Start();
            threadRun.Join();
        }

        private static void RunThread()
        {
            //tao thu muc du lieu local
            if (! System.IO.Directory.Exists(localdata_path))
                System.IO.Directory.CreateDirectory(localdata_path);

            #region BAR
            //bar_dm_menu
            DataSet ds_bar_dm_menu = objMasterService.Get_All_Bar_Dm_Menu();
            ds_bar_dm_menu.WriteXml(localdata_path + @"\bar_dm_menu.XML", XmlWriteMode.WriteSchema);

            //bar_dm_menu_hanghoa_ban
            DataSet ds_bar_dm_menu_hanghoa_ban = objMasterService.Get_All_Bar_Dm_Menu_Hanghoa_Ban();
            ds_bar_dm_menu_hanghoa_ban.WriteXml(localdata_path + @"\bar_dm_menu_hanghoa_ban.XML", XmlWriteMode.WriteSchema);
  
            //bar_dm_menu_hanghoa_ban
            DataSet ds_bar_dm_table = objMasterService.Get_All_Bar_Dm_Table();
            ds_bar_dm_table.WriteXml(localdata_path + @"\bar_dm_table.XML", XmlWriteMode.WriteSchema);

            #endregion

            #region WARE
            //WARE_DM_HANGHOA_BAN
            DataSet ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban();
            ds_Hanghoa_Ban.WriteXml(localdata_path + @"\WARE_DM_HANGHOA_BAN.XML", XmlWriteMode.WriteSchema);

            //ware_dm_congthuc_phache
            DataSet ds_ware_dm_congthuc_phache = objMasterService.Get_All_Ware_Dm_Congthuc_Phache();
            ds_ware_dm_congthuc_phache.WriteXml(localdata_path + @"\ware_dm_congthuc_phache.XML", XmlWriteMode.WriteSchema);

            //ware_dm_congthuc_phache_chitiet
            DataSet ds_ware_dm_congthuc_phache_chitiet = objMasterService.Get_All_Ware_Dm_Congthuc_Phache_Chitiet();
            ds_ware_dm_congthuc_phache_chitiet.WriteXml(localdata_path + @"\ware_dm_congthuc_phache_chitiet.XML", XmlWriteMode.WriteSchema);

            //ware_dm_congthuc_phache_chitiet
            DataSet ds_ware_dm_cuahang_ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban();
            ds_ware_dm_cuahang_ban.WriteXml(localdata_path + @"\ware_dm_cuahang_ban.XML", XmlWriteMode.WriteSchema);

            //ware_dm_donvitinh
            DataSet ds_ware_dm_donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh();
            ds_ware_dm_donvitinh.WriteXml(localdata_path + @"\ware_dm_donvitinh.XML", XmlWriteMode.WriteSchema);

           #endregion
        }
    }
}
