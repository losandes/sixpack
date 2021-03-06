﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixPack.Assets;

namespace SixPack
{
    public interface ISixPack
    {
        /// <summary>
        /// Gets all of the javascript files that are located at the paths given in the filePathArray, and bundles their code 
        /// into a single string.  The code is minifed.  The files are concatenated in the order 
        /// that they are aligned in the filePathArray. They resulting output is cached, so it can be served from memory on all 
        /// future requests.
        /// </summary>
        /// <param name="bundleName"></param>
        /// <param name="iMinifierFactoryName">The name of the IMinifier factory that is stored in SixPackServiceLocators.IMinifierCreationFacotries</param>
        /// <param name="filePathArray"></param>
        /// <param name="useCache"></param>
        /// <returns>string: the assets, minified and joined into a single string</returns>
        Task<Bundle> GetBundleContent(string bundleName, string iMinifierFactoryName, ICollection<string> filePathArray = null, bool useCache = true);

        /// <summary>
        /// Get the time that the bundle was cached (the last modified time) in an async call
        /// </summary>
        /// <param name="bundleName">the name of the bundle to check the last modified time for</param>
        /// <returns>The UTC Time that the bundle was cached, if it is found, otherwise UTCNow</returns>
        Task<DateTime> GetLastModifiedTimeAsync(string bundleName);

        /// <summary>
        /// Get the time that the bundle was cached (the last modified time).
        /// </summary>
        /// <param name="bundleName">the name of the bundle to check the last modified time for</param>
        /// <returns>The UTC Time that the bundle was cached, if it is found, otherwise UTCNow</returns>
        DateTime GetLastModifiedTime(string bundleName);
    }
}
