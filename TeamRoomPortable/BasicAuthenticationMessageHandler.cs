using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamRoomPortable
{
    /// <summary>
    /// Responsible for applying basic authentication header to any HTTP client calls
    /// </summary>
	public class BasicAuthenticationMessageHandler : HttpClientHandler
	{
		private readonly string _authorizationHeaderValue;

		public BasicAuthenticationMessageHandler(string userName, string password)
		{
			if (userName == null) throw new ArgumentNullException("userName");
			if (password == null) throw new ArgumentNullException("password");

			var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(userName + ":" + password));
			_authorizationHeaderValue = "Basic " + authInfo;
		}

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Add(HttpRequestHeader.Authorization.ToString(), _authorizationHeaderValue);
			return base.SendAsync(request, cancellationToken);
		}
	}
}