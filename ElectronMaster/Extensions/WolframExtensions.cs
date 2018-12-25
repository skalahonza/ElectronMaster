using System;
using System.Collections.Generic;
using System.Linq;
using Wolfram.Alpha.Models;

namespace ElectronMaster.Extensions
{
    public static class WolframExtensions
    {
        public static IEnumerable<Pod> FilterPods(this IEnumerable<Pod> pods, params string[] prohibited)
        {
            prohibited = prohibited.Select(x => x.Trim()).ToArray();
            return pods.Where(x => prohibited.All(y => !string.Equals(x.Title.Trim(), y, StringComparison.OrdinalIgnoreCase)));
        }
    }
}