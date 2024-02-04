using System;
using System.Collections.Generic;
using System.Text;

namespace SDL2
{
    internal class SdlAvailableAttribute : Attribute {
        private readonly Version _actualVersion;
        private readonly Version _expectedVersion;

        /// <summary>
        /// Initialized a new instance of the SdlAvailableAttribute
        /// </summary>
        /// <param name="major">The Major</param>
        /// <param name="minor">The Minor</param>
        /// <param name="patch">The Patch</param>
        public SdlAvailableAttribute(byte major, byte minor, byte patch) {
            _expectedVersion = new Version(major, minor, patch);
            SDL.GetVersion(out _actualVersion);
        }

        /// <summary>
        /// Initializes a new instance of the SdlAvailableAttribute
        /// </summary>
        /// <param name="version">The expected SDL Version</param>
        public SdlAvailableAttribute(string version) {

            _expectedVersion = new Version(version);
            SDL.GetVersion(out _actualVersion);
        }

        /// <summary>
        /// Is the reported version equal to the expected version?
        /// </summary>
        /// <returns><value>true</value> if the reported version is equal to the expected version</returns>
        public bool Equals() => _actualVersion == _expectedVersion;

        /// <summary>
        /// Is the reported version greater than or equal to the expected version?
        /// </summary>
        /// <returns><value>true</value> if the reported version meets or exceeds the expected version</returns>
        public bool GreaterOrEqualTo() => _actualVersion >= _expectedVersion;

        /// <summary>
        /// Is the reported version less than or equal to the expected version?
        /// </summary>
        /// <returns><value>true</value> if the reported version is less than or equal to the expected version</returns>
        public bool LessThanOrEqualTo() => _actualVersion <= _expectedVersion;
    }
}
