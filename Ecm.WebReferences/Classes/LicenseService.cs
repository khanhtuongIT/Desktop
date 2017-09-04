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
    public class LicenseService : Ecm.WebReferences.LicenseService.LicenseService
    {
        /// <summary>
        /// Conctructor
        /// assign this.Url
        /// </summary>

        public LicenseService()
        {

            string customURL = "" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetWebReferenceUrl( "LicenseService");
            if (customURL != string.Empty)
                this.Url = customURL;
            else
                this.Url = global::Ecm.WebReferences.Properties.Settings.Default.Ecm_WebReferences_LicenseService_LicenseService;

        }
    }
}
