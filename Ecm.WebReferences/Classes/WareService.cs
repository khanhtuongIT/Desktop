using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.WebReferences.Classes
{
    ///=============================================
    /// Author:		    Phuongphan
    /// Create date:    14/07/2010
    /// Description:	
    /// <br>Thừa kế từ class Ecm.WebReferences.WareService.WareService (được tạo ra khi add web reference)</br>
    /// <br>Thay đổi URL của web reference theo URL lưu trong HostConfiguration.config</br>
    /// =============================================
    public class WareService : Ecm.WebReferences.WareService.WareService
    {
        /// <summary>
        /// Conctructor
        /// assign this.Url
        /// </summary>

        public WareService()
        {
            string customURL = "" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetWebReferenceUrl("WareService");
            if (customURL != string.Empty)
                this.Url = customURL;
            else
                this.Url = global::Ecm.WebReferences.Properties.Settings.Default.Ecm_WebReferences_WareService_WareService;
        }
    }
}
