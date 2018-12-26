using System;

namespace ElectronMaster.Exceptions
{
    public class WolframException:Exception
    {
        public WolframException(int code, string message):base($"Wolfram error occured code: {code}. {message}")
        {            
        }
    }
}