using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.WebReferences.Classes
{
    ///=============================================
    /// Author:		    Phuongphan
    /// Create date:    14/07/2010
    /// Description:	
    /// <br>Thừa kế từ class Ecm.WebReferences.RexService.RexService (được tạo ra khi add web reference)</br>
    /// <br>Thay đổi URL của web reference theo URL lưu trong HostConfiguration.config</br>
    /// =============================================
    public class RexService : Ecm.WebReferences.RexService.RexService
    {
        /// <summary>
        /// Conctructor
        /// assign this.Url
        /// </summary>
        public RexService()
        {
            string customURL = "" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetWebReferenceUrl( "RexService");
            if (customURL != string.Empty)
                this.Url = customURL;
            else
                this.Url = global::Ecm.WebReferences.Properties.Settings.Default.Ecm_WebReferences_RexService_RexService;
        }
    }
}
