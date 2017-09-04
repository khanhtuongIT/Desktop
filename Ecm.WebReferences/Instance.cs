using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecm.WebReferences
{
    public static class Instance
    {
        public static System.Collections.Hashtable htServices = new System.Collections.Hashtable();
        public static T GetService<T>() where T : System.Web.Services.Protocols.SoapHttpClientProtocol, new()
        {
            Type type = typeof(T);
            var typeName = type.Name;
            T service = (T) htServices[typeName];
            if (service == null)
            {
                service = new T();
                htServices.Add(typeName, service);
            }
            return (T) service;
        }

        static Instance()
        {
            htServices = new System.Collections.Hashtable();

            //GetService<ERPMkg.WebReferences.Classes.Meta>();
            //GetService<ERPMkg.WebReferences.Classes.MetaAccounting>();
            //GetService<ERPMkg.WebReferences.Classes.MetaOrder>();
            //GetService<ERPMkg.WebReferences.Classes.MetaPro>();
            //GetService<ERPMkg.WebReferences.Classes.MetaRex>();
            //GetService<ERPMkg.WebReferences.Classes.MetaStore>();
            //GetService<ERPMkg.WebReferences.Classes.MetaWare>();

            //GetService<ERPMkg.WebReferences.Classes.AccAssets>();
            //GetService<ERPMkg.WebReferences.Classes.AccEquipment>();
            //GetService<ERPMkg.WebReferences.Classes.AccFunds>();
            //GetService<ERPMkg.WebReferences.Classes.Accounting>();
            //GetService<ERPMkg.WebReferences.Classes.AccPricing>();
            //GetService<ERPMkg.WebReferences.Classes.AccWare>();
            //GetService<ERPMkg.WebReferences.Classes.Order>();
            //GetService<ERPMkg.WebReferences.Classes.Pro>();
            //GetService<ERPMkg.WebReferences.Classes.Reports>();
            //GetService<ERPMkg.WebReferences.Classes.Rex>();
            //GetService<ERPMkg.WebReferences.Classes.Store>();
            //GetService<ERPMkg.WebReferences.Classes.SystemService>();
            //GetService<ERPMkg.WebReferences.Classes.Ware>();

        }
    }
}
