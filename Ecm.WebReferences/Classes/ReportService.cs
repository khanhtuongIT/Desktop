using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.MdiUtils;

namespace Ecm.WebReferences.Classes
{
    ///=============================================
    /// Author:		    Phuongphan
    /// Create date:    14/07/2010
    /// Description:	
    /// <br>Thừa kế từ class Ecm.WebReferences.ReportService.ReportServices (được tạo ra khi add web reference)</br>
    /// <br>Thay đổi URL của web reference theo URL lưu trong HostConfiguration.config</br>
    /// =============================================
    public class ReportService : Ecm.WebReferences.ReportService.ReportService
    {
        /// <summary>
        /// Conctructor
        /// assign this.Url
        /// </summary>
        public ReportService()
        {
            string customURL = "" + ThemeSettings.GetWebReferenceUrl( "ReportServices");
            if (customURL != string.Empty)
                this.Url = customURL;
            else
                this.Url = global::Ecm.WebReferences.Properties.Settings.Default.Ecm_WebReferences_ReportService_ReportServices;

        }
    }
}
