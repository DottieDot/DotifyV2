using System.Collections.Generic;
using System.Linq;
using System;

namespace DotifyV2.Common
{
	public static class TypeExtensions
	{
		public static IEnumerable<string> GetFieldNames(this Type type)
			=> type.GetFields().Select(f => f.Name);
	}
}
