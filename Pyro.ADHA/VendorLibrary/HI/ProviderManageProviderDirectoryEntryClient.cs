using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Pyro.ADHA.mcaR32.ProviderManageProviderDirectoryEntry;
using Pyro.ADHA.VendorLibrary.Common;


namespace Pyro.ADHA.VendorLibrary.HI
{
    /// <summary>
    /// 
    /// </summary>
    public class ProviderManageProviderDirectoryEntryClient : IDisposable
    {
        internal ProviderManageProviderDirectoryEntryPortType providerDirectoryEntryClient;

        /// <summary>
        /// SOAP messages for the last client call.
        /// </summary>
        public HIEndpointProcessor.SoapMessages SoapMessages { get; set; }

        /// <summary>
        /// The ProductType to be used in all searches.
        /// </summary>
        ProductType product;

        /// <summary>
        /// The User to be used in all searches.
        /// </summary>
        QualifiedId user;

        /// <summary>
        /// Gets the timestamp for the soap request.
        /// </summary>
        public TimestampType LastSoapRequestTimestamp { get; private set; }

        /// <summary>
        /// HI service name.
        /// </summary>
        public const string HIServiceOperation = "ProviderManageProviderDirectoryEntry";

        /// <summary>
        /// HI service version.
        /// </summary>
        public const string HIServiceVersion = "3.2.0";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointUri"></param>
        /// <param name="product"></param>
        /// <param name="user"></param>
        /// <param name="signingCert"></param>
        /// <param name="tlsCert"></param>
        public ProviderManageProviderDirectoryEntryClient(Uri endpointUri, ProductType product, QualifiedId user, 
            X509Certificate2 signingCert, X509Certificate2 tlsCert)
        {
            Validation.ValidateArgumentRequired("endpointUri", endpointUri);

            InitializeClient(endpointUri.ToString(), null, signingCert, tlsCert, product, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="product"></param>
        /// <param name="user"></param>
        /// <param name="signingCert"></param>
        /// <param name="tlsCert"></param>
        public ProviderManageProviderDirectoryEntryClient(string endpointConfigurationName, ProductType product, QualifiedId user, 
            X509Certificate2 signingCert, X509Certificate2 tlsCert)
        {
            Validation.ValidateArgumentRequired("endpointConfigurationName", endpointConfigurationName);

            InitializeClient(null, endpointConfigurationName, signingCert, tlsCert, product, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public manageProviderDirectoryEntryResponse ManageProviderDirectoryEntry(manageProviderDirectoryEntry request)
        {
            var timestamp = new TimestampType
            {
                created = DateTime.Now.ToUniversalTime(),
                expires = DateTime.Now.AddDays(30).ToUniversalTime(),
                expiresSpecified = true
            };

            var directoryEntryRequest = new manageProviderDirectoryEntryRequest(
                product, new SignatureContainerType(), timestamp, user, request);


            LastSoapRequestTimestamp = directoryEntryRequest.timestamp;

            manageProviderDirectoryEntryResponse1 response = null;

            try
            {
                response = providerDirectoryEntryClient.manageProviderDirectoryEntry(directoryEntryRequest);
            }
            catch (Exception ex)
            {
                FaultHelper.ProcessAndThrowFault<ServiceMessagesType>(ex);
            }

            if (response != null && response.manageProviderDirectoryEntryResponse != null)
                return response.manageProviderDirectoryEntryResponse;
            
            throw new ApplicationException(Properties.Resources.UnexpectedServiceResponse);
        }


        private void InitializeClient(string endpointUrl, string endpointConfigurationName, X509Certificate2 signingCert, 
            X509Certificate2 tlsCert, ProductType clientProduct, QualifiedId clientUser)
        {
            Validation.ValidateArgumentRequired("product", clientProduct);
            Validation.ValidateArgumentRequired("user", clientUser);
            Validation.ValidateArgumentRequired("signingCert", signingCert);
            Validation.ValidateArgumentRequired("tlsCert", tlsCert);

            this.product = clientProduct;
            this.user = clientUser;

            SoapMessages = new HIEndpointProcessor.SoapMessages();

            ProviderManageProviderDirectoryEntryPortTypeClient client = null;

            if (!string.IsNullOrEmpty(endpointUrl))
            {
                var address = new EndpointAddress(endpointUrl);
                var tlsBinding = GetBinding();

                client = new ProviderManageProviderDirectoryEntryPortTypeClient(tlsBinding, address);
            }
            else if (!string.IsNullOrEmpty(endpointConfigurationName))
            {
                client = new ProviderManageProviderDirectoryEntryPortTypeClient(endpointConfigurationName);
            }

            if (client != null)
            {
                HIEndpointProcessor.ProcessEndpoint(client.Endpoint, signingCert, SoapMessages);

                if (tlsCert != null)
                {
                    client.ClientCredentials.ClientCertificate.Certificate = tlsCert;
                }

                providerDirectoryEntryClient = client;
            }
        }


        private static CustomBinding GetBinding()
        {
            // Set up binding
            var tlsBinding = new CustomBinding();

            var tlsEncoding = new TextMessageEncodingBindingElement();
            tlsEncoding.ReaderQuotas.MaxDepth = 2147483647;
            tlsEncoding.ReaderQuotas.MaxStringContentLength = 2147483647;
            tlsEncoding.ReaderQuotas.MaxArrayLength = 2147483647;
            tlsEncoding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            tlsEncoding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

            var httpsTransport = new HttpsTransportBindingElement
            {
                RequireClientCertificate = true,
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647
            };

            tlsBinding.Elements.Add(tlsEncoding);
            tlsBinding.Elements.Add(httpsTransport);

            return tlsBinding;
        }


        public void Dispose()
        {
            if (providerDirectoryEntryClient is ClientBase<ProviderManageProviderDirectoryEntryPortType>)
            {
                ClientBase<ProviderManageProviderDirectoryEntryPortType> searchClient = 
                    (ClientBase<ProviderManageProviderDirectoryEntryPortType>)providerDirectoryEntryClient;
                if (searchClient.State != CommunicationState.Closed)
                    searchClient.Close();
            }
        }
    }
}