using NzbDrone.Common.EnvironmentInfo;

namespace NzbDrone.Common.Http
{
    public interface IUserAgentBuilder
    {
        string GetUserAgent(bool simplified = false);
    }

    public class UserAgentBuilder : IUserAgentBuilder
    {
        private readonly string _userAgentSimplified;
        private readonly string _userAgent;

        public string GetUserAgent(bool simplified)
        {
            if (simplified)
            {
                return _userAgentSimplified;
            }

            return _userAgent;
        }

        public UserAgentBuilder(IOsInfo osInfo)
        {
            var osName = OsInfo.Os.ToString();

            if (!string.IsNullOrWhiteSpace(osInfo.Name))
            {
                osName = osInfo.Name.ToLower();
            }

            var osVersion = osInfo.Version?.ToLower();

            _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
            _userAgentSimplified = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
        }
    }
}
