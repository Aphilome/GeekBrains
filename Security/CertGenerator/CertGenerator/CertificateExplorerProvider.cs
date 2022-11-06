﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerator
{
    public class CertificateExplorerProvider
    {
        private string[] certStores = new string[] { "LocalMachine.My", "CurrentUser.My", "LocalMachine.Root", "CurrentUser.Root" };
        private List<X509Certificate2Wrapper> certList;
        private const string CURRENT_USER_MY = "Current user - my";
        private const string LOCAL_MACHINE_MY = "Local machine - my";
        private const string LOCAL_MACHINE_ROOT = "Local machine - root";
        private const string CURRENT_USER_ROOT = "Current user - root";

        private bool requirePrivateKey;

        public CertificateExplorerProvider(bool requirePrivateKey)
        {
            this.requirePrivateKey = requirePrivateKey;
        }

        public List<X509Certificate2Wrapper> Certificates
        {
            get { return certList; }
        }

        public void LoadCertificates()
        {
            certList = new List<X509Certificate2Wrapper>();
            foreach (string store in certStores)
            {
                certList.AddRange(LoadStore(store));
            }
        }

        private List<X509Certificate2Wrapper> LoadStore(string storeName)
        {
            X509Store store = new X509Store(ExtractStoreName(storeName), ExtractStoreLocation(storeName));
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            try
            {
                return CertificatesToView(store.Certificates, storeName);
            }
            finally
            {
                store.Close();
            }
        }

        private List<X509Certificate2Wrapper> CertificatesToView(X509Certificate2Collection certificates,
            string groupName)
        {
            List<X509Certificate2Wrapper> certList = new List<X509Certificate2Wrapper>();
            foreach (X509Certificate2 cert in certificates)
            {
                string groupDesc = null;
                switch (groupName)
                {
                    case "CurrentUser.My":
                        groupDesc = CURRENT_USER_MY;
                        break;
                    case "LocalMachine.My":
                        groupDesc = LOCAL_MACHINE_MY;
                        break;
                    case "LocalMachine.Root":
                        groupDesc = LOCAL_MACHINE_ROOT;
                        break;
                    case "CurrentUser.Root":
                        groupDesc = CURRENT_USER_ROOT;
                        break;
                }
                if (requirePrivateKey)
                {
                    if (cert.HasPrivateKey)
                    {
                        certList.Add(new X509Certificate2Wrapper(cert, groupName, groupDesc));
                    }
                }
                else
                {
                    certList.Add(new X509Certificate2Wrapper(cert, groupName, groupDesc));
                }
            }
            return certList;
        }

        public static StoreName ExtractStoreName(string store)
        {
            return (StoreName)Enum.Parse(typeof(StoreName),
                store.Substring(store.IndexOf('.') + 1));
        }

        public static StoreLocation ExtractStoreLocation(string store)
        {
            return (StoreLocation)Enum.Parse(typeof(StoreLocation),
                store.Substring(0, store.IndexOf('.')));
        }

    }
}