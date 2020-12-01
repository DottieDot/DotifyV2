using System;
using System.Net;

namespace DotifyV2.Presentation.Exceptions
{
	public class HttpException : Exception
	{
		public HttpException()
		{
			StatusCode = HttpStatusCode.InternalServerError;
		}

		public HttpException(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}

		public HttpException(HttpStatusCode statusCode, string errorPhrase) : this(statusCode)
		{
			ErrorPhrase = errorPhrase;
		}

		public HttpStatusCode StatusCode { get; private set; }

		public string ErrorPhrase { get; private set; }
	}
}
