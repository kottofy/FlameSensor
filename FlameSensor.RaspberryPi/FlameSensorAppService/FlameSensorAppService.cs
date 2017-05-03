﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Net.Http;
using FlameSensor.RaspberryPi;
using Microsoft.Rest;

namespace FlameSensor.RaspberryPi
{
    public partial class FlameSensorAppService : ServiceClient<FlameSensorAppService>, IFlameSensorAppService
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IDevice _device;
        
        public virtual IDevice Device
        {
            get { return this._device; }
        }
        
        private ISensor _sensor;
        
        public virtual ISensor Sensor
        {
            get { return this._sensor; }
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        public FlameSensorAppService()
            : base()
        {
            this._device = new Device(this);
            this._sensor = new Sensor(this);
            this._baseUri = new Uri("https://flamesensorappservice.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public FlameSensorAppService(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._device = new Device(this);
            this._sensor = new Sensor(this);
            this._baseUri = new Uri("https://flamesensorappservice.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public FlameSensorAppService(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._device = new Device(this);
            this._sensor = new Sensor(this);
            this._baseUri = new Uri("https://flamesensorappservice.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public FlameSensorAppService(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public FlameSensorAppService(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the FlameSensorAppService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public FlameSensorAppService(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
    }
}
